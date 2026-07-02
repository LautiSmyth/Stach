﻿using BE;
using BLL;
using Abstracciones;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class MenuForm : Form, IObserver
    {
        private readonly IConexionService _conexionService = IoCContainer.Resolver<IConexionService>();
        private readonly IManejadorSeguridad _manejadorSeguridad = IoCContainer.Resolver<IManejadorSeguridad>();
        private readonly ISessionManager _sessionManager = IoCContainer.Resolver<ISessionManager>();
        private readonly UsuarioBLL _usuarioBll = IoCContainer.Resolver<UsuarioBLL>();
        private readonly IManejadorIdioma _manejadorIdioma = IoCContainer.Resolver<IManejadorIdioma>();
        private readonly IDigitoVerificadorService _dvServicio = IoCContainer.Resolver<IDigitoVerificadorService>();
        private bool _cargandoIdioma = false;
        private bool _timerDisposed = false;
        private System.Windows.Forms.Timer _timerIntegridad;

        public MenuForm()
        {
            InitializeComponent();
            _manejadorIdioma.Attach(this);
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is MdiClient)
                    c.BackColor = System.Drawing.Color.FromArgb(248, 244, 255);
            }

            ActualizarIdioma();
            _manejadorSeguridad.AplicarSeguridad(this, _sessionManager.Usuario);

            _timer.Interval = 1000;
            _timer.Start();
            ActualizarHora();

            _timerIntegridad = new System.Windows.Forms.Timer();
            _timerIntegridad.Interval = 300000;
            _timerIntegridad.Tick += TimerIntegridad_Tick;
            _timerIntegridad.Start();
        }

        private void CboIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cargandoIdioma) return;
            if (cboIdioma.SelectedItem is Idioma idioma)
            {
                _manejadorIdioma.CambiarIdioma(idioma);
            }
        }

        private void CargarComboIdioma()
        {
            _cargandoIdioma = true;
            try
            {
                List<Idioma> idiomas = _manejadorIdioma.ObtenerIdiomas();
                Idioma actual = _manejadorIdioma.IdiomaActual;

                cboIdioma.ComboBox.DataSource = null;
                cboIdioma.ComboBox.DisplayMember = "Nombre";
                cboIdioma.ComboBox.DataSource = idiomas;

                if (actual != null)
                {
                    for (int i = 0; i < cboIdioma.Items.Count; i++)
                    {
                        if (cboIdioma.Items[i] is Idioma id && id.IdIdioma == actual.IdIdioma)
                        {
                            cboIdioma.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
            finally
            {
                _cargandoIdioma = false;
            }
        }

        private void BtnIdiomas_Click(object sender, EventArgs e)
        {
            AbrirOActivar<IdiomaForm>();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ActualizarHora();
        }

        private void TimerIntegridad_Tick(object sender, EventArgs e)
        {
            _timerIntegridad.Stop();
            System.Collections.Generic.List<string> errores;
            bool ok = _dvServicio.VerificarIntegridad(out errores);
            if (!ok)
            {
                MessageBox.Show(
                    "Se detectó una alteración en los datos del sistema. La sesión será cerrada por seguridad.",
                    "Integridad comprometida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                _usuarioBll.Logout(this.Text);
                _timer.Stop();
                if (!_timerDisposed) { _timer.Dispose(); _timerDisposed = true; }
                _timerIntegridad.Dispose();
                Application.Restart();
                return;
            }
            _timerIntegridad.Start();
        }

        private void ActualizarHora()
        {
            lblHora.Text = "ðŸ•’ " + DateTime.Now.ToString("HH:mm:ss") + "  ";
        }

        private void BtnBitacora_Click(object sender, EventArgs e)
        {
            AbrirOActivar<BitacoraForm>();
        }

        private void BtnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirOActivar<UsuariosForm>();
        }

        private void BtnPermisos_Click(object sender, EventArgs e)
        {
            AbrirOActivar<PermisosForm>();
        }

        private void BtnCambios_Click(object sender, EventArgs e)
        {
            AbrirOActivar<ControlCambiosForm>();
        }

        private void BtnBackup_Click(object sender, EventArgs e)
        {
            AbrirOActivar<BackupForm>();
        }

        private void LblUsuario_Click(object sender, EventArgs e)
        {
            MisPermisosForm form = new MisPermisosForm();
            form.ShowDialog();
        }

        private void AbrirOActivar<T>() where T : Form, new()
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is T)
                {
                    form.Activate();
                    return;
                }
            }
            T nuevoForm = new T();
            nuevoForm.MdiParent = this;
            nuevoForm.StartPosition = FormStartPosition.Manual;
            nuevoForm.Location = new Point((this.ClientSize.Width - nuevoForm.Width) / 2, (this.ClientSize.Height - nuevoForm.Height - toolStrip.Height - statusStrip.Height - 40) / 2);
            nuevoForm.Show();
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            CerrarSesion();
        }

        private void MenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("¿Esta seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
                _usuarioBll.Logout(this.Text);
                _timer.Stop();
                if (!_timerDisposed) { _timer.Dispose(); _timerDisposed = true; }
                _timerIntegridad?.Stop();
                _timerIntegridad?.Dispose();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _manejadorIdioma.Detach(this);
            base.OnFormClosed(e);
            Application.Exit();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.U))
            {
                if (btnUsuarios.Enabled)
                {
                    BtnUsuarios_Click(this, EventArgs.Empty);
                    return true;
                }
            }
            else if (keyData == (Keys.Control | Keys.B))
            {
                if (btnBitacora.Enabled)
                {
                    BtnBitacora_Click(this, EventArgs.Empty);
                    return true;
                }
            }
            else if (keyData == (Keys.Control | Keys.K))
            {
                if (btnBackup.Enabled)
                {
                    BtnBackup_Click(this, EventArgs.Empty);
                    return true;
                }
            }
            else if (keyData == (Keys.Control | Keys.P))
            {
                if (btnPermisos.Enabled)
                {
                    BtnPermisos_Click(this, EventArgs.Empty);
                    return true;
                }
            }
            else if (keyData == (Keys.Control | Keys.I))
            {
                if (btnIdiomas.Enabled)
                {
                    BtnIdiomas_Click(this, EventArgs.Empty);
                    return true;
                }
            }
            else if (keyData == (Keys.Control | Keys.H))
            {
                if (btnCambios.Enabled)
                {
                    BtnCambios_Click(this, EventArgs.Empty);
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void CerrarSesion()
        {
            if (MessageBox.Show("¿Esta seguro que desea cerrar la sesion?", "Cerrar sesion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _usuarioBll.Logout(this.Text);
                _timer.Stop();
                if (!_timerDisposed) { _timer.Dispose(); _timerDisposed = true; }
                _timerIntegridad?.Stop();
                _timerIntegridad?.Dispose();
                Application.Restart();
            }
        }

        public void ActualizarIdioma()
        {
            btnUsuarios.Text = _manejadorIdioma.ObtenerTexto("MenuForm.btnUsuarios");
            btnBitacora.Text = _manejadorIdioma.ObtenerTexto("MenuForm.btnBitacora");
            btnPermisos.Text = _manejadorIdioma.ObtenerTexto("MenuForm.btnPermisos") ?? "ðŸ”‘ Permisos";
            btnCambios.Text = _manejadorIdioma.ObtenerTexto("MenuForm.btnCambios") ?? "ðŸ“œ Cambios";
            btnBackup.Text = _manejadorIdioma.ObtenerTexto("MenuForm.btnBackup") ?? "ðŸ’¾ Backup";
            btnIdiomas.Text = _manejadorIdioma.ObtenerTexto("MenuForm.btnIdiomas") ?? "ðŸŒ Idiomas";
            btnCerrarSesion.Text = _manejadorIdioma.ObtenerTexto("MenuForm.btnCerrarSesion");
            lblUsuario.Text = $"{_manejadorIdioma.ObtenerTexto("MenuForm.lblSesionInfo")} {_usuarioBll.ObtenerUsernameEnSesion()}";
            lblBaseDatos.Text = $"{_manejadorIdioma.ObtenerTexto("MenuForm.lblServidorInfo")} {_conexionService.ObtenerNombreBaseDatos()}";
            CargarComboIdioma();
        }

        private class EstiloProfesionalMenu : ProfessionalColorTable
        {
            public override System.Drawing.Color ToolStripGradientBegin => System.Drawing.Color.FromArgb(126, 87, 194);
            public override System.Drawing.Color ToolStripGradientMiddle => System.Drawing.Color.FromArgb(126, 87, 194);
            public override System.Drawing.Color ToolStripGradientEnd => System.Drawing.Color.FromArgb(126, 87, 194);
            public override System.Drawing.Color MenuItemSelected => System.Drawing.Color.FromArgb(94, 58, 160);
            public override System.Drawing.Color MenuItemBorder => System.Drawing.Color.FromArgb(171, 136, 220);
            public override System.Drawing.Color ButtonSelectedHighlight => System.Drawing.Color.FromArgb(171, 136, 220);
            public override System.Drawing.Color ButtonSelectedHighlightBorder => System.Drawing.Color.FromArgb(171, 136, 220);
            public override System.Drawing.Color ButtonPressedHighlight => System.Drawing.Color.FromArgb(94, 58, 160);
            public override System.Drawing.Color ButtonCheckedHighlight => System.Drawing.Color.FromArgb(171, 136, 220);
            public override System.Drawing.Color ToolStripDropDownBackground => System.Drawing.Color.FromArgb(237, 231, 249);
            public override System.Drawing.Color ImageMarginGradientBegin => System.Drawing.Color.FromArgb(237, 231, 249);
            public override System.Drawing.Color ImageMarginGradientMiddle => System.Drawing.Color.FromArgb(237, 231, 249);
            public override System.Drawing.Color ImageMarginGradientEnd => System.Drawing.Color.FromArgb(237, 231, 249);
        }
    }
}