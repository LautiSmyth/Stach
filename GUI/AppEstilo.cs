using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public static class AppEstilo
    {
        public static readonly Color ColorFondo = Color.FromArgb(248, 244, 255);
        public static readonly Color ColorFondoCard = Color.White;
        public static readonly Color ColorPrimario = Color.FromArgb(126, 87, 194);
        public static readonly Color ColorPrimarioOscuro = Color.FromArgb(94, 58, 160);
        public static readonly Color ColorPrimarioClaro = Color.FromArgb(209, 196, 233);
        public static readonly Color ColorPrimarioMuyClaro = Color.FromArgb(237, 231, 249);
        public static readonly Color ColorPrimarioUltraClaro = Color.FromArgb(249, 245, 255);
        public static readonly Color ColorAccent = Color.FromArgb(171, 136, 220);
        public static readonly Color ColorAccentSuave = Color.FromArgb(225, 210, 245);
        public static readonly Color ColorTexto = Color.FromArgb(38, 20, 70);
        public static readonly Color ColorTextoSecundario = Color.FromArgb(110, 85, 150);
        public static readonly Color ColorTextoClaro = Color.White;
        public static readonly Color ColorBorde = Color.FromArgb(200, 182, 228);
        public static readonly Color ColorBordeSuave = Color.FromArgb(225, 215, 240);
        public static readonly Color ColorFilaAlterna = Color.FromArgb(244, 239, 255);
        public static readonly Color ColorBotonHover = Color.FromArgb(94, 58, 160);
        public static readonly Color ColorBotonSecHover = Color.FromArgb(220, 208, 240);
        public static readonly Color ColorExito = Color.FromArgb(129, 199, 132);
        public static readonly Color ColorPeligro = Color.FromArgb(229, 115, 115);
        public static readonly Color ColorAdvertencia = Color.FromArgb(255, 183, 77);

        public static readonly Font FuenteNormal = new Font("Segoe UI", 9.5f);
        public static readonly Font FuenteNegrita = new Font("Segoe UI", 9.5f, FontStyle.Bold);
        public static readonly Font FuenteTitulo = new Font("Segoe UI", 22f, FontStyle.Bold);
        public static readonly Font FuenteSubtitulo = new Font("Segoe UI", 11f, FontStyle.Bold);
        public static readonly Font FuenteSeccion = new Font("Segoe UI", 9.5f, FontStyle.Bold);
        public static readonly Font FuentePequena = new Font("Segoe UI", 8.5f);
        public static readonly Font FuenteMonospace = new Font("Consolas", 9f);

        public static void AplicarBotonPrimario(Button btn)
        {
            btn.BackColor = ColorPrimario;
            btn.ForeColor = ColorTextoClaro;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = ColorBotonHover;
            btn.Font = FuenteNegrita;
            btn.Cursor = Cursors.Hand;
            btn.Height = 38;
            btn.Padding = new Padding(8, 0, 8, 0);
        }

        public static void AplicarBotonSecundario(Button btn)
        {
            btn.BackColor = ColorPrimarioMuyClaro;
            btn.ForeColor = ColorPrimario;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = ColorBorde;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.MouseOverBackColor = ColorBotonSecHover;
            btn.Font = FuenteNormal;
            btn.Cursor = Cursors.Hand;
            btn.Height = 38;
            btn.Padding = new Padding(8, 0, 8, 0);
        }

        public static void AplicarBotonPeligro(Button btn)
        {
            btn.BackColor = ColorPeligro;
            btn.ForeColor = ColorTextoClaro;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(200, 80, 80);
            btn.Font = FuenteNegrita;
            btn.Cursor = Cursors.Hand;
            btn.Height = 38;
        }

        public static void AplicarGrilla(DataGridView dgv)
        {
            dgv.BackgroundColor = ColorFondo;
            dgv.BorderStyle = BorderStyle.None;
            dgv.GridColor = ColorBordeSuave;
            dgv.RowHeadersVisible = false;
            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorPrimario;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = ColorTextoClaro;
            dgv.ColumnHeadersDefaultCellStyle.Font = FuenteSeccion;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorPrimario;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            dgv.ColumnHeadersHeight = 38;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgv.DefaultCellStyle.BackColor = ColorFondoCard;
            dgv.DefaultCellStyle.ForeColor = ColorTexto;
            dgv.DefaultCellStyle.SelectionBackColor = ColorPrimarioClaro;
            dgv.DefaultCellStyle.SelectionForeColor = ColorTexto;
            dgv.DefaultCellStyle.Font = FuenteNormal;
            dgv.DefaultCellStyle.Padding = new Padding(10, 4, 10, 4);

            dgv.AlternatingRowsDefaultCellStyle.BackColor = ColorFilaAlterna;
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = ColorPrimarioClaro;

            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.RowTemplate.Height = 34;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        public static void AplicarGroupBox(GroupBox grp)
        {
            grp.ForeColor = ColorPrimario;
            grp.Font = FuenteSeccion;
            grp.BackColor = Color.Transparent;
        }

        public static void AplicarLabel(Label lbl, bool esSecundario = false)
        {
            lbl.ForeColor = esSecundario ? ColorTextoSecundario : ColorTexto;
            lbl.Font = FuenteNormal;
            lbl.BackColor = Color.Transparent;
        }

        public static void AplicarLabelNegrita(Label lbl)
        {
            lbl.ForeColor = ColorTexto;
            lbl.Font = FuenteNegrita;
            lbl.BackColor = Color.Transparent;
        }

        public static void AplicarTextBox(TextBox txt)
        {
            txt.BackColor = ColorFondoCard;
            txt.ForeColor = ColorTexto;
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Font = FuenteNormal;
            txt.Height = 30;
        }

        public static void AplicarComboBox(ComboBox cbo)
        {
            cbo.BackColor = ColorFondoCard;
            cbo.ForeColor = ColorTexto;
            cbo.FlatStyle = FlatStyle.Flat;
            cbo.Font = FuenteNormal;
        }

        public static void AplicarToolStrip(ToolStrip ts)
        {
            ts.BackColor = ColorPrimario;
            ts.ForeColor = ColorTextoClaro;
            ts.Font = FuenteNormal;
            ts.GripStyle = ToolStripGripStyle.Hidden;
            ts.Padding = new Padding(8, 0, 8, 0);
            ts.ImageScalingSize = new System.Drawing.Size(18, 18);
            ts.Renderer = new ToolStripProfessionalRenderer(new EstiloProfesional());

            foreach (ToolStripItem item in ts.Items)
            {
                item.ForeColor = ColorTextoClaro;
                item.Font = FuenteNormal;
                item.Padding = new Padding(10, 4, 10, 4);
            }
        }

        public static void AplicarStatusStrip(StatusStrip ss)
        {
            ss.BackColor = ColorPrimarioMuyClaro;
            ss.ForeColor = ColorTextoSecundario;
            ss.Font = FuentePequena;
            ss.SizingGrip = false;
        }

        public static void AplicarMdiBackground(Form mdiParent)
        {
            foreach (Control c in mdiParent.Controls)
            {
                if (c is MdiClient)
                    c.BackColor = ColorFondo;
            }
        }

        public static Panel CrearDivider()
        {
            return new Panel
            {
                Height = 1,
                BackColor = ColorBordeSuave,
                Dock = DockStyle.Top,
                Margin = new Padding(0, 8, 0, 8)
            };
        }

        private class EstiloProfesional : ProfessionalColorTable
        {
            public override Color ToolStripGradientBegin => ColorPrimario;
            public override Color ToolStripGradientMiddle => ColorPrimario;
            public override Color ToolStripGradientEnd => ColorPrimario;
            public override Color MenuItemSelected => ColorPrimarioOscuro;
            public override Color MenuItemBorder => ColorAccent;
            public override Color ButtonSelectedHighlight => ColorAccent;
            public override Color ButtonSelectedHighlightBorder => ColorAccent;
            public override Color ButtonPressedHighlight => ColorBotonHover;
            public override Color ButtonCheckedHighlight => ColorAccent;
            public override Color ToolStripDropDownBackground => ColorPrimarioMuyClaro;
            public override Color ImageMarginGradientBegin => ColorPrimarioMuyClaro;
            public override Color ImageMarginGradientMiddle => ColorPrimarioMuyClaro;
            public override Color ImageMarginGradientEnd => ColorPrimarioMuyClaro;
        }
    }
}
