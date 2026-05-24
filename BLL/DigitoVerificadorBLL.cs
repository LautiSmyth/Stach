using BE;
using DAL;
using System.Collections.Generic;

namespace BLL
{
    public class DigitoVerificadorBLL
    {
        private readonly DigitoVerificadorDAL _dal = new DigitoVerificadorDAL();
        private readonly UsuarioDAL _usuarioDal = new UsuarioDAL();

        public string CalcularDVH(Usuario usuario)
        {
            long sumTotal = 0;
            sumTotal += CalcularValorAtributo(usuario.IdUsuario.ToString(), 1);
            sumTotal += CalcularValorAtributo(usuario.Username, 2);
            sumTotal += CalcularValorAtributo(usuario.PasswordHash, 3);
            sumTotal += CalcularValorAtributo(((int)usuario.Estado).ToString(), 4);
            return Seguridad.Encriptador.HashSHA256(sumTotal.ToString());
        }

        private long CalcularValorAtributo(string valor, int posicionAtributo)
        {
            if (string.IsNullOrEmpty(valor)) return 0;
            long suma = 0;
            for (int i = 0; i < valor.Length; i++)
            {
                suma += (int)valor[i] * (i + 1) * posicionAtributo;
            }
            return suma;
        }

        public string CalcularDVV(List<Usuario> usuarios)
        {
            List<Usuario> ordenados = new List<Usuario>(usuarios);
            ordenados.Sort((a, b) => a.IdUsuario.CompareTo(b.IdUsuario));
            string concat = string.Empty;
            foreach (var u in ordenados)
            {
                concat += CalcularDVH(u);
            }
            return Seguridad.Encriptador.HashSHA256(concat);
        }

        public void InicializarDVs()
        {
            List<Usuario> usuarios = _usuarioDal.ObtenerTodos();
            Dictionary<int, string> dvhs = new Dictionary<int, string>();
            foreach (var u in usuarios)
            {
                dvhs[u.IdUsuario] = CalcularDVH(u);
            }
            string dvv = CalcularDVV(usuarios);
            _dal.GuardarDV(dvhs, dvv);
        }

        public bool VerificarIntegridad(out List<string> errores)
        {
            errores = new List<string>();
            List<Usuario> usuarios = _usuarioDal.ObtenerTodos();
            string storedDvv = _dal.ObtenerDVV();
            Dictionary<int, string> storedDvhs = _dal.ObtenerDVHs();

            if (string.IsNullOrEmpty(storedDvv) && storedDvhs.Count == 0)
            {
                InicializarDVs();
                return true;
            }

            bool todoOk = true;
            foreach (var u in usuarios)
            {
                string dvhCalculado = CalcularDVH(u);
                if (storedDvhs.TryGetValue(u.IdUsuario, out string dvhGuardado))
                {
                    if (dvhCalculado != dvhGuardado)
                    {
                        errores.Add($"Fallo de integridad en Usuario ID: {u.IdUsuario} ('{u.Username}'). DVH no coincide.");
                        todoOk = false;
                    }
                }
                else
                {
                    errores.Add($"Fallo de integridad en Usuario ID: {u.IdUsuario} ('{u.Username}'). No se encontró su DVH guardado.");
                    todoOk = false;
                }
            }

            string dvvCalculado = CalcularDVV(usuarios);
            if (dvvCalculado != storedDvv)
            {
                errores.Add("Fallo de integridad vertical (DVV) en tabla Usuario.");
                todoOk = false;
            }

            return todoOk;
        }

        public void CorromperParaPrueba()
        {
            _dal.Corromper();
        }
    }
}
