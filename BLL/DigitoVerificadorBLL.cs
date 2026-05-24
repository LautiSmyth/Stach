using BE;
using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class DigitoVerificadorBLL
    {
        private readonly DigitoVerificadorDAL _dal = new DigitoVerificadorDAL();
        private readonly UsuarioDAL _usuarioDal = new UsuarioDAL();

        public string CalcularDVH(Usuario usuario)
        {
            string data = usuario.IdUsuario.ToString() + usuario.Username + usuario.PasswordHash + ((int)usuario.Estado).ToString();
            return Seguridad.Encriptador.HashSHA256(data);
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
