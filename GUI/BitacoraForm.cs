using BE;
using BE.Enums;
using BLL;
using Abstracciones;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class BitacoraForm : Form, IObserver
    {
        private readonly IBitacoraService _bitacoraServicio = IoCContainer.Resolver<IBitacoraService>();
        private readonly ICriticidadService _criticidadServicio = IoCContainer.Resolver<ICriticidadService>();
        private readonly UsuarioBLL _usuarioBll = IoCContainer.Resolver<UsuarioBLL>();
        private readonly IManejadorIdioma _manejadorIdioma = IoCContainer.Resolver<IManejadorIdioma>();
        private List<Bitacora> _listaCompleta = new List<Bitacora>();
        private readonly Timer _timerBusqueda = new Timer();

        public BitacoraForm()
        {
            InitializeComponent();
            _timerBusqueda.Interval = 300;
            _timerBusqueda.Tick += TimerBusqueda_Tick;
            _manejadorIdioma.Attach(this);
        }

        private void BitacoraForm_Load(object sender, EventArgs e)
        {
            try
            {
                cboLimite.Items.Clear();
                cboLimite.Items.Add("50");
                cboLimite.Items.Add("100");
                cboLimite.Items.Add("500");
                cboLimite.Items.Add("Todos");
                cboLimite.SelectedIndex = 1;

                DesuscribirFiltros();
                CargarComboCriticidad();
                CargarComboUsuarios();
                LimpiarFiltros();
                SuscribirFiltros();
                ActualizarIdioma();
                DesactivarTabStopReadOnly(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar el formulario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarComboUsuarios()
        {
            bool tienePermisoTodos = _usuarioBll.UsuarioLogueadoTienePermiso("BitacoraTodos");
            if (tienePermisoTodos)
            {
                lblFiltrarUsuario.Visible = true;
                cboFiltrarUsuario.Visible = true;
                cboFiltrarUsuario.Items.Clear();
                string todosText = _manejadorIdioma.ObtenerTexto("BitacoraForm.Todos") ?? "Todos";
                cboFiltrarUsuario.Items.Add(todosText);
                List<Usuario> usuarios = _usuarioBll.ObtenerTodos();
                foreach (Usuario u in usuarios)
                {
                    cboFiltrarUsuario.Items.Add(u.Username);
                }
                cboFiltrarUsuario.SelectedIndex = 0;
                cboFiltrarUsuario.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboFiltrarUsuario.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            else
            {
                lblFiltrarUsuario.Visible = false;
                cboFiltrarUsuario.Visible = false;
            }
        }

        private void BitacoraForm_Shown(object sender, EventArgs e)
        {
            CargarDesdeBD();
            CargarComboActividad();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _timerBusqueda.Stop();
            _timerBusqueda.Dispose();
            _manejadorIdioma.Detach(this);
            base.OnFormClosed(e);
        }

        private void SuscribirFiltros()
        {
            txtBuscar.TextChanged += TxtBuscar_TextChanged;
            chkUsername.CheckedChanged += Filtro_Changed;
            chkDetalle.CheckedChanged += Filtro_Changed;
            chkError.CheckedChanged += Filtro_Changed;
            cboCriticidad.SelectedIndexChanged += Filtro_Changed;
            cboActividad.SelectedIndexChanged += Filtro_Changed;
            chkExitoso.CheckStateChanged += Filtro_Changed;
            dtpDesde.ValueChanged += Filtro_Changed;
            dtpHasta.ValueChanged += Filtro_Changed;
            cboLimite.SelectedIndexChanged += Filtro_Changed;
            cboFiltrarUsuario.TextChanged += Filtro_Changed;
        }

        private void DesuscribirFiltros()
        {
            txtBuscar.TextChanged -= TxtBuscar_TextChanged;
            chkUsername.CheckedChanged -= Filtro_Changed;
            chkDetalle.CheckedChanged -= Filtro_Changed;
            chkError.CheckedChanged -= Filtro_Changed;
            cboCriticidad.SelectedIndexChanged -= Filtro_Changed;
            cboActividad.SelectedIndexChanged -= Filtro_Changed;
            chkExitoso.CheckStateChanged -= Filtro_Changed;
            dtpDesde.ValueChanged -= Filtro_Changed;
            dtpHasta.ValueChanged -= Filtro_Changed;
            cboLimite.SelectedIndexChanged -= Filtro_Changed;
            cboFiltrarUsuario.TextChanged -= Filtro_Changed;
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            _timerBusqueda.Stop();
            _timerBusqueda.Start();
        }

        private void TimerBusqueda_Tick(object sender, EventArgs e)
        {
            _timerBusqueda.Stop();
            AplicarFiltros();
        }

        private void CargarComboCriticidad()
        {
            cboCriticidad.Items.Clear();
            cboCriticidad.Items.Add(new CriticidadItem(null, "Todos"));
            foreach (CriticidadConfig config in _criticidadServicio.ObtenerTodos())
                cboCriticidad.Items.Add(new CriticidadItem(config.Nivel, config.Nombre));
            cboCriticidad.DisplayMember = "Nombre";
            cboCriticidad.SelectedIndex = 0;
        }

        private void CargarComboActividad()
        {
            string actual = cboActividad.Text;
            cboActividad.BeginUpdate();
            cboActividad.Items.Clear();
            cboActividad.Items.Add("Todos");
            List<string> actividades = new List<string>();
            foreach (Bitacora b in _listaCompleta)
                if (!actividades.Contains(b.Actividad))
                    actividades.Add(b.Actividad);
            actividades.Sort();
            foreach (string a in actividades)
                cboActividad.Items.Add(a);
            cboActividad.EndUpdate();
            cboActividad.Text = string.IsNullOrEmpty(actual) ? "Todos" : actual;
        }

        private void CargarDesdeBD()
        {
            try
            {
                _listaCompleta = _bitacoraServicio.ObtenerTodos();
                AplicarFiltros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la bitacora: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarFiltros()
        {
            string busqueda = txtBuscar.Text.ToLower();
            bool hayBusqueda = !string.IsNullOrEmpty(busqueda);
            bool buscarUsername = chkUsername.Checked;
            bool buscarDetalle = chkDetalle.Checked;
            bool buscarError = chkError.Checked;
            string actividadFiltro = cboActividad.Text;
            CheckState estadoExitoso = chkExitoso.CheckState;
            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date;

            NivelCriticidad? criticidadFiltro = null;
            if (cboCriticidad.SelectedItem is CriticidadItem item && item.Nivel.HasValue)
                criticidadFiltro = item.Nivel.Value;

            List<Bitacora> resultado = new List<Bitacora>();

            bool tienePermisoTodos = _usuarioBll.UsuarioLogueadoTienePermiso("BitacoraTodos");
            string filtroUsuario = "";
            if (tienePermisoTodos)
            {
                filtroUsuario = cboFiltrarUsuario.Text.Trim();
            }
            else
            {
                filtroUsuario = _usuarioBll.ObtenerUsernameEnSesion();
            }
            string todosText = _manejadorIdioma.ObtenerTexto("BitacoraForm.Todos") ?? "Todos";

            foreach (Bitacora b in _listaCompleta)
            {
                if (!string.IsNullOrEmpty(filtroUsuario) && !filtroUsuario.Equals("Todos", StringComparison.OrdinalIgnoreCase) && !filtroUsuario.Equals(todosText, StringComparison.OrdinalIgnoreCase) && !b.Username.Equals(filtroUsuario, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                if (hayBusqueda)
                {
                    bool ok = false;
                    if (buscarUsername && b.Username.ToLower().Contains(busqueda)) ok = true;
                    if (buscarDetalle && b.Detalle.ToLower().Contains(busqueda)) ok = true;
                    if (buscarError && b.Error.ToLower().Contains(busqueda)) ok = true;
                    if (!ok) continue;
                }
                if (criticidadFiltro.HasValue && b.Criticidad != criticidadFiltro.Value) continue;
                if (actividadFiltro != "Todos" && !string.IsNullOrEmpty(actividadFiltro) && b.Actividad != actividadFiltro) continue;
                if (estadoExitoso == CheckState.Checked && !b.Exitoso) continue;
                if (estadoExitoso == CheckState.Unchecked && b.Exitoso) continue;
                if (b.Fecha.Date < desde) continue;
                if (b.Fecha.Date > hasta) continue;
                resultado.Add(b);
            }

            if (cboLimite.SelectedItem != null && cboLimite.SelectedItem.ToString() != "Todos")
            {
                int limite = int.Parse(cboLimite.SelectedItem.ToString());
                if (resultado.Count > limite)
                {
                    resultado = resultado.GetRange(0, limite);
                }
            }

            MostrarEnGrilla(resultado);
        }

        private void MostrarEnGrilla(List<Bitacora> lista)
        {
            dgvBitacora.SuspendLayout();
            dgvBitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvBitacora.DataSource = null;
            dgvBitacora.DataSource = lista;

            if (dgvBitacora.Columns.Count > 0)
            {
                if (dgvBitacora.Columns["IdBitacora"] != null) dgvBitacora.Columns["IdBitacora"].Visible = false;
                if (dgvBitacora.Columns["IdUsuario"] != null) dgvBitacora.Columns["IdUsuario"].Visible = false;
                if (dgvBitacora.Columns["Detalle"] != null) dgvBitacora.Columns["Detalle"].Visible = false;
                if (dgvBitacora.Columns["Error"] != null) dgvBitacora.Columns["Error"].Visible = false;

                if (dgvBitacora.Columns["Username"] != null) dgvBitacora.Columns["Username"].HeaderText = "Usuario";
                if (dgvBitacora.Columns["Modulo"] != null) dgvBitacora.Columns["Modulo"].HeaderText = "Módulo";
                if (dgvBitacora.Columns["Actividad"] != null) dgvBitacora.Columns["Actividad"].HeaderText = "Actividad";
                if (dgvBitacora.Columns["Criticidad"] != null) dgvBitacora.Columns["Criticidad"].HeaderText = "Criticidad";
                if (dgvBitacora.Columns["Fecha"] != null) dgvBitacora.Columns["Fecha"].HeaderText = "Fecha y Hora";
                if (dgvBitacora.Columns["Exitoso"] != null) dgvBitacora.Columns["Exitoso"].HeaderText = "Resultado";
            }

            foreach (DataGridViewRow fila in dgvBitacora.Rows)
            {
                if (fila.DataBoundItem == null) continue;
                NivelCriticidad criticidad = ((Bitacora)fila.DataBoundItem).Criticidad;
                CriticidadConfig config = _criticidadServicio.ObtenerConfig(criticidad);
                if (config == null) continue;
                Color colorFondo;
                try { colorFondo = ColorTranslator.FromHtml(config.ColorHex); }
                catch { continue; }
                fila.DefaultCellStyle.BackColor = colorFondo;
                fila.DefaultCellStyle.SelectionBackColor = ControlPaint.Dark(colorFondo, 0.1f);
            }

            dgvBitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            if (dgvBitacora.Columns["Modulo"] != null)
            {
                dgvBitacora.Columns["Modulo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dgvBitacora.ResumeLayout();
            lblContador.Text = $"  Mostrando {lista.Count} de {_listaCompleta.Count} registros";
        }

        private void LimpiarFiltros()
        {
            txtBuscar.Text = "";
            chkUsername.Checked = true;
            chkDetalle.Checked = true;
            chkError.Checked = false;
            if (cboCriticidad.Items.Count > 0) cboCriticidad.SelectedIndex = 0;
            cboActividad.Text = "Todos";
            chkExitoso.CheckState = CheckState.Indeterminate;
            dtpHasta.MinDate = DateTime.Today.AddMonths(-1);
            dtpDesde.Value = DateTime.Today.AddMonths(-1);
            dtpHasta.Value = DateTime.Today;
            if (cboLimite.Items.Count > 0) cboLimite.SelectedIndex = 1;
            if (cboFiltrarUsuario.Visible && cboFiltrarUsuario.Items.Count > 0)
            {
                cboFiltrarUsuario.SelectedIndex = 0;
            }
        }

        private void Filtro_Changed(object sender, EventArgs e)
        {
            if (sender == dtpDesde)
            {
                dtpHasta.MinDate = dtpDesde.Value;
                if (dtpHasta.Value < dtpDesde.Value)
                    dtpHasta.Value = dtpDesde.Value;
            }
            AplicarFiltros();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            CargarDesdeBD();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            _timerBusqueda.Stop();
            DesuscribirFiltros();
            LimpiarFiltros();
            SuscribirFiltros();
            AplicarFiltros();
        }

        private void DgvBitacora_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBitacora.SelectedRows.Count > 0 && dgvBitacora.SelectedRows[0].DataBoundItem is Bitacora b)
            {
                txtDetFecha.Text = b.Fecha.ToString();
                txtDetUsuario.Text = b.Username;
                txtDetModulo.Text = b.Modulo;
                txtDetActividad.Text = b.Actividad;
                txtDetCriticidad.Text = b.Criticidad.ToString();
                txtDetResultado.Text = b.Exitoso ? "Exitoso" : "Fallido";
                txtDetDetalle.Text = b.Detalle;
                txtDetError.Text = b.Error;
            }
            else
            {
                txtDetFecha.Clear();
                txtDetUsuario.Clear();
                txtDetModulo.Clear();
                txtDetActividad.Clear();
                txtDetCriticidad.Clear();
                txtDetResultado.Clear();
                txtDetDetalle.Clear();
                txtDetError.Clear();
            }
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            if (dgvBitacora.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivos CSV (*.csv)|*.csv";
                sfd.FileName = "Bitacora_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        List<string> lineas = new List<string>();
                        lineas.Add("Fecha y Hora;Usuario;Módulo;Actividad;Criticidad;Resultado;Detalle;Detalle del Error");
                        foreach (DataGridViewRow fila in dgvBitacora.Rows)
                        {
                            if (fila.DataBoundItem is Bitacora b)
                            {
                                string linea = $"\"{b.Fecha}\";\"{b.Username}\";\"{b.Modulo}\";\"{b.Actividad}\";\"{b.Criticidad}\";\"{(b.Exitoso ? "Exitoso" : "Fallido")}\";\"{b.Detalle.Replace("\"", "\"\"")}\";\"{b.Error.Replace("\"", "\"\"")}\"";
                                lineas.Add(linea);
                            }
                        }
                        System.IO.File.WriteAllLines(sfd.FileName, lineas, System.Text.Encoding.UTF8);
                        MessageBox.Show("Datos exportados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void ActualizarIdioma()
        {
            lblBuscar.Text = _manejadorIdioma.ObtenerTexto("BitacoraForm.lblBuscar");
            lblCriticidad.Text = _manejadorIdioma.ObtenerTexto("BitacoraForm.lblCriticidad");
            lblActividad.Text = _manejadorIdioma.ObtenerTexto("BitacoraForm.lblActividad");
            lblLimite.Text = _manejadorIdioma.ObtenerTexto("BitacoraForm.lblLimite");
            btnBuscar.Text = _manejadorIdioma.ObtenerTexto("BitacoraForm.btnBuscar");
            btnLimpiar.Text = _manejadorIdioma.ObtenerTexto("BitacoraForm.btnLimpiar");
            btnExportar.Text = _manejadorIdioma.ObtenerTexto("BitacoraForm.btnExportar");
            grpDetalle.Text = _manejadorIdioma.ObtenerTexto("BitacoraForm.grpDetalle");
            lblDetFecha.Text = _manejadorIdioma.ObtenerTexto("BitacoraForm.lblDetFecha");
            lblDetUsuario.Text = _manejadorIdioma.ObtenerTexto("BitacoraForm.lblDetUsuario");
            lblDetModulo.Text = _manejadorIdioma.ObtenerTexto("BitacoraForm.lblDetModulo");
            lblDetActividad.Text = _manejadorIdioma.ObtenerTexto("BitacoraForm.lblDetActividad");
            lblDetCriticidad.Text = _manejadorIdioma.ObtenerTexto("BitacoraForm.lblDetCriticidad");
            lblDetResultado.Text = _manejadorIdioma.ObtenerTexto("BitacoraForm.lblDetResultado");
            lblDetDetalle.Text = _manejadorIdioma.ObtenerTexto("BitacoraForm.lblDetDetalle");
            lblDetError.Text = _manejadorIdioma.ObtenerTexto("BitacoraForm.lblDetError");
            lblFiltrarUsuario.Text = _manejadorIdioma.ObtenerTexto("BitacoraForm.lblFiltrarUsuario") ?? "Usuario:";
        }

        private void DesactivarTabStopReadOnly(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox txt && txt.ReadOnly)
                {
                    txt.TabStop = false;
                }
                if (c.HasChildren)
                {
                    DesactivarTabStopReadOnly(c);
                }
            }
        }
    }

    internal class CriticidadItem
    {
        public NivelCriticidad? Nivel { get; }
        public string Nombre { get; }

        public CriticidadItem(NivelCriticidad? nivel, string nombre)
        { Nivel = nivel; Nombre = nombre; }

        public override string ToString()
        { return Nombre; }
    }
}