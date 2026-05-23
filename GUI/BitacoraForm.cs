using Aplicacion;
using BE;
using BE.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class BitacoraForm : Form
    {
        private readonly BitacoraServicio _bitacoraServicio = new BitacoraServicio();
        private readonly CriticidadServicio _criticidadServicio = new CriticidadServicio();
        private List<Bitacora> _listaCompleta = new List<Bitacora>();
        private bool _columnasConfiguradas = false;
        private readonly Timer _timerBusqueda = new Timer();

        public BitacoraForm()
        {
            InitializeComponent();
            _timerBusqueda.Interval = 300;
            _timerBusqueda.Tick += TimerBusqueda_Tick;
        }

        private void BitacoraForm_Load(object sender, EventArgs e)
        {
            AplicarEstilo();
            DesuscribirFiltros();
            CargarComboCriticidad();
            LimpiarFiltros();
            SuscribirFiltros();
        }

        private void AplicarEstilo()
        {
            this.BackColor = AppEstilo.ColorFondo;
            pnlFiltros.BackColor = AppEstilo.ColorPrimarioMuyClaro;
            pnlEstado.BackColor = AppEstilo.ColorPrimarioMuyClaro;
            AppEstilo.AplicarGrilla(dgvBitacora);
            AppEstilo.AplicarTextBox(txtBuscar);
            AppEstilo.AplicarComboBox(cboCriticidad);
            AppEstilo.AplicarComboBox(cboActividad);
            AppEstilo.AplicarBotonPrimario(btnBuscar);
            AppEstilo.AplicarBotonSecundario(btnLimpiar);

            foreach (Control c in flpFila1.Controls)
            {
                if (c is Label lbl) { lbl.ForeColor = AppEstilo.ColorTexto; lbl.Font = AppEstilo.FuenteNormal; }
                if (c is CheckBox chk) { chk.ForeColor = AppEstilo.ColorTexto; chk.Font = AppEstilo.FuenteNormal; chk.BackColor = Color.Transparent; }
            }
            foreach (Control c in flpFila2.Controls)
            {
                if (c is Label lbl) { lbl.ForeColor = AppEstilo.ColorTexto; lbl.Font = AppEstilo.FuenteNormal; }
                if (c is CheckBox chk) { chk.ForeColor = AppEstilo.ColorTexto; chk.Font = AppEstilo.FuenteNormal; chk.BackColor = Color.Transparent; }
            }

            lblContador.ForeColor = AppEstilo.ColorTexto;
            lblContador.Font = AppEstilo.FuenteNormal;
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

            foreach (Bitacora b in _listaCompleta)
            {
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

            MostrarEnGrilla(resultado);
        }

        private void MostrarEnGrilla(List<Bitacora> lista)
        {
            dgvBitacora.SuspendLayout();
            dgvBitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvBitacora.DataSource = lista;

            if (!_columnasConfiguradas && dgvBitacora.Columns.Count > 0)
            {
                dgvBitacora.Columns["IdBitacora"].Visible = false;
                dgvBitacora.Columns["IdUsuario"].Visible = false;
                dgvBitacora.Columns["Detalle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvBitacora.Columns["Error"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                _columnasConfiguradas = true;
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
            if (_columnasConfiguradas)
            {
                dgvBitacora.Columns["Detalle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvBitacora.Columns["Error"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
    }

    internal class CriticidadItem
    {
        public NivelCriticidad? Nivel { get; }
        public string Nombre { get; }
        public CriticidadItem(NivelCriticidad? nivel, string nombre) { Nivel = nivel; Nombre = nombre; }
        public override string ToString() { return Nombre; }
    }
}
