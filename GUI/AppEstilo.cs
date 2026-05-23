using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public static class AppEstilo
    {
        public static readonly Color ColorFondo = Color.FromArgb(245, 240, 255);
        public static readonly Color ColorPrimario = Color.FromArgb(123, 94, 167);
        public static readonly Color ColorPrimarioClaro = Color.FromArgb(201, 184, 232);
        public static readonly Color ColorPrimarioMuyClaro = Color.FromArgb(237, 228, 252);
        public static readonly Color ColorAccent = Color.FromArgb(155, 127, 190);
        public static readonly Color ColorTexto = Color.FromArgb(45, 28, 74);
        public static readonly Color ColorTextoClaro = Color.White;
        public static readonly Color ColorBorde = Color.FromArgb(190, 170, 220);
        public static readonly Color ColorFilaAlterna = Color.FromArgb(240, 233, 252);
        public static readonly Color ColorBotonHover = Color.FromArgb(100, 72, 145);

        public static readonly Font FuenteNormal = new Font("Segoe UI", 9.5f);
        public static readonly Font FuenteNegrita = new Font("Segoe UI", 9.5f, FontStyle.Bold);
        public static readonly Font FuenteTitulo = new Font("Segoe UI", 14f, FontStyle.Bold);
        public static readonly Font FuenteSubtitulo = new Font("Segoe UI", 10f, FontStyle.Bold);

        public static void AplicarBotonPrimario(Button btn)
        {
            btn.BackColor = ColorPrimario;
            btn.ForeColor = ColorTextoClaro;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = ColorBotonHover;
            btn.Font = FuenteNegrita;
            btn.Cursor = Cursors.Hand;
        }

        public static void AplicarBotonSecundario(Button btn)
        {
            btn.BackColor = ColorPrimarioMuyClaro;
            btn.ForeColor = ColorTexto;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = ColorBorde;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.MouseOverBackColor = ColorPrimarioClaro;
            btn.Font = FuenteNormal;
            btn.Cursor = Cursors.Hand;
        }

        public static void AplicarGrilla(DataGridView dgv)
        {
            dgv.BackgroundColor = ColorFondo;
            dgv.BorderStyle = BorderStyle.None;
            dgv.GridColor = ColorBorde;
            dgv.RowHeadersVisible = false;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorPrimario;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = ColorTextoClaro;
            dgv.ColumnHeadersDefaultCellStyle.Font = FuenteNegrita;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = ColorPrimario;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 0, 0);
            dgv.ColumnHeadersHeight = 34;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.DefaultCellStyle.BackColor = ColorFondo;
            dgv.DefaultCellStyle.ForeColor = ColorTexto;
            dgv.DefaultCellStyle.SelectionBackColor = ColorPrimarioClaro;
            dgv.DefaultCellStyle.SelectionForeColor = ColorTexto;
            dgv.DefaultCellStyle.Font = FuenteNormal;
            dgv.DefaultCellStyle.Padding = new Padding(4, 0, 4, 0);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = ColorFilaAlterna;
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = ColorPrimarioClaro;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.RowTemplate.Height = 30;
        }

        public static void AplicarGroupBox(GroupBox grp)
        {
            grp.ForeColor = ColorPrimario;
            grp.Font = FuenteSubtitulo;
            grp.BackColor = Color.Transparent;
        }

        public static void AplicarTextBox(TextBox txt)
        {
            txt.BackColor = Color.White;
            txt.ForeColor = ColorTexto;
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Font = FuenteNormal;
        }

        public static void AplicarComboBox(ComboBox cbo)
        {
            cbo.BackColor = Color.White;
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
            ts.Padding = new Padding(4, 0, 4, 0);
            ts.Renderer = new ToolStripProfessionalRenderer(new EstiloProfesional());

            foreach (ToolStripItem item in ts.Items)
            {
                item.ForeColor = ColorTextoClaro;
                item.Font = FuenteNormal;
            }
        }

        public static void AplicarStatusStrip(StatusStrip ss)
        {
            ss.BackColor = ColorPrimarioClaro;
            ss.ForeColor = ColorTexto;
            ss.Font = FuenteNormal;
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

        private class EstiloProfesional : ProfessionalColorTable
        {
            public override Color ToolStripGradientBegin => ColorPrimario;
            public override Color ToolStripGradientMiddle => ColorPrimario;
            public override Color ToolStripGradientEnd => ColorPrimario;
            public override Color MenuItemSelected => ColorAccent;
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
