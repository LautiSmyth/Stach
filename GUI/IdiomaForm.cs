using BE;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class IdiomaForm : Form, IObserver
    {
        private List<FilaTraduccion> _traduccionesBindeables;
        List<Idioma> idiomas = new List<Idioma>();

        public IdiomaForm()
        {
            InitializeComponent();
            ManejadorIdioma.Instancia.Attach(this);
        }

        private void IdiomaForm_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarGrilla();
                CargarIdiomas();
                CargarTraduccionesGrilla();
                ActualizarIdioma();

                txtNombre.MaxLength = 100;
                txtCodigo.MaxLength = 10;
                txtCodigo.KeyPress += TxtCodigo_KeyPress;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            ManejadorIdioma.Instancia.Detach(this);
            base.OnFormClosed(e);
        }

        private void CargarIdiomas()
        {
            idiomas = ManejadorIdioma.Instancia.ObtenerIdiomas();
            if (idiomas == null || idiomas.Count == 0)
            {
                MessageBox.Show("La lista de idiomas en la base de datos está vacía. Verifique la base de datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lstIdiomas.DataSource = null;
            lstIdiomas.DisplayMember = "Nombre";
            lstIdiomas.DataSource = idiomas;

            cboIdiomaDestino.DataSource = null;
            cboIdiomaDestino.DisplayMember = "Nombre";
            cboIdiomaDestino.DataSource = new List<Idioma>(idiomas);

            if (idiomas.Count > 0)
            {
                lstIdiomas.SelectedIndex = 0;
                cboIdiomaDestino.SelectedIndex = 0;
            }
        }

        private void ConfigurarGrilla()
        {
            dgvTraducciones.AutoGenerateColumns = false;
            dgvTraducciones.AllowUserToAddRows = false;
            dgvTraducciones.AllowUserToDeleteRows = false;
            dgvTraducciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTraducciones.RowHeadersVisible = false;

            dgvTraducciones.Columns.Clear();

            var colNombre = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreComponente",
                HeaderText = "Componente",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgvTraducciones.Columns.Add(colNombre);

            var colReferencia = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TextoDefault",
                HeaderText = "Referencia (Default)",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgvTraducciones.Columns.Add(colReferencia);

            var colTexto = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Texto",
                HeaderText = "Texto / Traducción",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgvTraducciones.Columns.Add(colTexto);
        }

        private void LstIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstIdiomas.SelectedItem is Idioma idioma)
            {
                txtNombre.Text = idioma.Nombre;
                txtCodigo.Text = idioma.Codigo;
                chkDefault.Checked = idioma.Default;
                btnEliminarIdioma.Enabled = !idioma.Default;
            }
        }

        private void CboIdiomaDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarTraduccionesGrilla();
        }

        private void CargarTraduccionesGrilla()
        {
            if (cboIdiomaDestino.SelectedItem is Idioma idioma)
            {
                List<Componente> componentes = ManejadorIdioma.Instancia.ObtenerComponentes();
                List<Traduccion> traducciones = ManejadorIdioma.Instancia.ObtenerTraduccionesPorIdioma(idioma.IdIdioma);

                var defaultLang = idiomas.FirstOrDefault(i => i.Default);
                List<Traduccion> traduccionesDefault = defaultLang != null
                    ? ManejadorIdioma.Instancia.ObtenerTraduccionesPorIdioma(defaultLang.IdIdioma)
                    : new List<Traduccion>();

                _traduccionesBindeables = new List<FilaTraduccion>();

                foreach (Componente comp in componentes)
                {
                    Traduccion trad = traducciones.FirstOrDefault(t => t.IdComponente == comp.IdComponente);
                    Traduccion tradDef = traduccionesDefault.FirstOrDefault(t => t.IdComponente == comp.IdComponente);
                    _traduccionesBindeables.Add(new FilaTraduccion
                    {
                        IdComponente = comp.IdComponente,
                        NombreComponente = comp.Nombre,
                        TextoDefault = tradDef != null ? tradDef.Texto : string.Empty,
                        Texto = trad != null ? trad.Texto : string.Empty
                    });
                }

                dgvTraducciones.DataSource = null;
                dgvTraducciones.DataSource = _traduccionesBindeables;
            }
        }

        private void BtnAgregarIdioma_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string codigo = txtCodigo.Text.Trim().ToLower();
            bool esDefault = chkDefault.Checked;

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(codigo))
            {
                MessageBox.Show("Por favor, ingrese el nombre y código del idioma.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (idiomas.Any(idioma => idioma.Codigo == codigo || idioma.Nombre == nombre))
            {
                MessageBox.Show("El nombre y/o codigo de idioma ya existe");
                return;
            }

            try
            {
                var nuevo = new Idioma { Nombre = nombre, Codigo = codigo, Default = esDefault };
                ManejadorIdioma.Instancia.InsertarIdioma(nuevo);

                CargarIdiomas();
                txtNombre.Clear();
                txtCodigo.Clear();
                chkDefault.Checked = false;

                MessageBox.Show("Idioma agregado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminarIdioma_Click(object sender, EventArgs e)
        {
            if (lstIdiomas.SelectedItem is Idioma idioma)
            {
                if (idioma.Default)
                {
                    MessageBox.Show("No se puede eliminar el idioma por defecto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show($"¿Está seguro de eliminar el idioma '{idioma.Nombre}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        ManejadorIdioma.Instancia.EliminarIdioma(idioma.IdIdioma);
                        CargarIdiomas();
                        MessageBox.Show("Idioma eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnGuardarTraducciones_Click(object sender, EventArgs e)
        {
            if (cboIdiomaDestino.SelectedItem is Idioma idioma)
            {
                dgvTraducciones.EndEdit();

                var listado = new List<Traduccion>();
                foreach (var fila in _traduccionesBindeables)
                {
                    listado.Add(new Traduccion
                    {
                        IdIdioma = idioma.IdIdioma,
                        IdComponente = fila.IdComponente,
                        Texto = fila.Texto
                    });
                }

                try
                {
                    ManejadorIdioma.Instancia.GuardarTraducciones(listado);
                    MessageBox.Show("Traducciones guardadas con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void ActualizarIdioma()
        {
            this.Text = ManejadorIdioma.Instancia.ObtenerTexto("IdiomaForm.Text");
            lblIdiomasTitulo.Text = ManejadorIdioma.Instancia.ObtenerTexto("IdiomaForm.lblIdiomasTitulo");
            lblNombre.Text = ManejadorIdioma.Instancia.ObtenerTexto("IdiomaForm.lblNombre");
            lblCodigo.Text = ManejadorIdioma.Instancia.ObtenerTexto("IdiomaForm.lblCodigo");
            chkDefault.Text = ManejadorIdioma.Instancia.ObtenerTexto("IdiomaForm.chkDefault");
            btnAgregarIdioma.Text = ManejadorIdioma.Instancia.ObtenerTexto("IdiomaForm.btnAgregarIdioma");
            btnEliminarIdioma.Text = ManejadorIdioma.Instancia.ObtenerTexto("IdiomaForm.btnEliminarIdioma");
            lblTraduccionesTitulo.Text = ManejadorIdioma.Instancia.ObtenerTexto("IdiomaForm.lblTraduccionesTitulo");
            lblIdiomaDestino.Text = ManejadorIdioma.Instancia.ObtenerTexto("IdiomaForm.lblIdiomaDestino");
            btnGuardarTraducciones.Text = ManejadorIdioma.Instancia.ObtenerTexto("IdiomaForm.btnGuardarTraducciones");

            if (dgvTraducciones.Columns.Count >= 3)
            {
                dgvTraducciones.Columns[0].HeaderText = ManejadorIdioma.Instancia.ObtenerTexto("IdiomaForm.colComponente") ?? "Componente";
                dgvTraducciones.Columns[1].HeaderText = ManejadorIdioma.Instancia.ObtenerTexto("IdiomaForm.colReferencia") ?? "Referencia (Default)";
                dgvTraducciones.Columns[2].HeaderText = ManejadorIdioma.Instancia.ObtenerTexto("IdiomaForm.colTexto") ?? "Texto / Traducción";
            }
        }

        private class FilaTraduccion
        {
            public int IdComponente { get; set; }
            public string NombreComponente { get; set; }
            public string TextoDefault { get; set; }
            public string Texto { get; set; }
        }
    }
}