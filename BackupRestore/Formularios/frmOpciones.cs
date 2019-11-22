using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Data.OleDb;
using System.Collections;

namespace BackupRestore
{
    public partial class frmOpciones : Form
    {
        EventosApp ea = new EventosApp();
        string textoLabel5;

        public frmOpciones()
        {
            InitializeComponent();
            textoLabel5 = label5.Text;
            label5.Text = "";

            ttHelp.Active = false;
            txtAnterior.Enter += new EventHandler(CuadrosDeTexto_Enter);
            txtAnterior.Leave += new EventHandler(CuadrosDeTexto_Leave);
            txtNueva.Enter += new EventHandler(this.CuadrosDeTexto_Enter);
            txtNueva.Leave += new EventHandler(this.CuadrosDeTexto_Leave);
            txtRepetir.Enter += new EventHandler(this.CuadrosDeTexto_Enter);
            txtRepetir.Leave += new EventHandler(this.CuadrosDeTexto_Leave);
            txtExclusiones.Enter += new EventHandler(this.CuadrosDeTexto_Enter);
            txtExclusiones.Leave += new EventHandler(this.CuadrosDeTexto_Leave);
            txtLabel.Enter += new EventHandler(this.CuadrosDeTexto_Enter);
            txtLabel.Leave += new EventHandler(this.CuadrosDeTexto_Leave);
            txtExclusiones.Text = Properties.Settings.Default.exclusiones;
            txtLabel.Text = Properties.Settings.Default.label_disco;
            cmbTipo.Text = Properties.Settings.Default.tipo_disco;
            cmbCompresion.Text = Properties.Settings.Default.compresion;
            txtPre.Text = Properties.Settings.Default.ejecutarAntes;
            txtPost.Text = Properties.Settings.Default.ejecutarDespues;

            if (Properties.Settings.Default.control_errores == true)
                cmbControlErrores.SelectedIndex = 0;
            else
                cmbControlErrores.SelectedIndex = 1;

            cmbControlErrores.BackColor = Color.LemonChiffon;
            txtAnterior.Select();
        }

        private void CuadrosDeTexto_Enter(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            t.BackColor = Color.LemonChiffon;
        }

        private void CuadrosDeTexto_Leave(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            t.BackColor = Color.White;
        }

        private void btnCambiarClave_Click(object sender, EventArgs e)
        {
            if (txtAnterior.Text == Properties.Settings.Default.password & txtAnterior.TextLength != 0)
            {
                if (txtNueva.TextLength != 0 | txtRepetir.TextLength != 0)
                {
                    if (txtRepetir.Text == txtNueva.Text)
                    {
                        Properties.Settings.Default.password = txtNueva.Text;
                        Properties.Settings.Default.Save();
                        MessageBox.Show("Clave cambiada.", "Aviso",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ea.PonerEvento("Se ha cambiado la clave para restaurar copias.");
                    }
                    else
                    {
                        MessageBox.Show("Las claves no coinciden.", "Aviso",
                                             MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNueva.SelectAll();
                        txtNueva.Select();
                    }
                }
                else
                {
                    txtNueva.Select();
                }
            }
            else
            {
                MessageBox.Show("La clave anterior no coincide.", "Aviso"
                            , MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAnterior.SelectAll();
                txtAnterior.Select();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.exclusiones = txtExclusiones.Text;
            Properties.Settings.Default.label_disco = txtLabel.Text;
            Properties.Settings.Default.tipo_disco = cmbTipo.Text;
            Properties.Settings.Default.compresion = cmbCompresion.Text;
            Properties.Settings.Default.ejecutarAntes = txtPre.Text;
            Properties.Settings.Default.ejecutarDespues = txtPost.Text;

            if (cmbControlErrores.SelectedIndex == 0)
                Properties.Settings.Default.control_errores = true;
            else
                Properties.Settings.Default.control_errores = false;

            if (txtPre.TextLength != 0)
            {
                if (!File.Exists(txtPre.Text))
                {
                    txtPre.Focus();
                    txtPre.SelectAll();
                    return;
                }
            }

            if (txtPost.TextLength != 0)
            {
                if (!File.Exists(txtPost.Text))
                {
                    txtPost.Focus();
                    txtPost.SelectAll();
                    return;
                }
            }

            Properties.Settings.Default.Save();
            this.Close();
        }

        private void chkMostrarClaves_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkMostrarClaves.Checked)
            {
                foreach (Control txt in grpbPassword.Controls)
                {
                    if (txt is TextBox)
                    {
                        TextBox txtBox = (TextBox)txt;
                        txtBox.PasswordChar = '●';
                    }
                }
            }
            else
            {
                TextBox txtAnterior2 = new TextBox();
                TextBox txtNueva2 = new TextBox();
                TextBox txtRepetir2 = new TextBox();

                foreach (Control c in grpbPassword.Controls)
                {
                    if (c is TextBox)
                    {
                        TextBox txtBox = (TextBox)c;

                        if (txtBox.Name.Contains("Anterior"))
                        {
                            txtAnterior2.Location = txtBox.Location;
                            txtAnterior2.Size = txtBox.Size;
                            txtAnterior2.Text = txtBox.Text;
                            grpbPassword.Controls.Add(txtAnterior2);
                            txtBox.Dispose();
                        }
                        else if (txtBox.Name.Contains("Nueva"))
                        {
                            txtNueva2.Location = txtBox.Location;
                            txtNueva2.Size = txtBox.Size;
                            txtNueva2.Text = txtBox.Text;
                            grpbPassword.Controls.Add(txtNueva2);
                            txtBox.Dispose();
                        }
                        else if (txtBox.Name.Contains("Repetir"))
                        {
                            txtRepetir2.Location = txtBox.Location;
                            txtRepetir2.Size = txtBox.Size;
                            txtRepetir2.Text = txtBox.Text;
                            grpbPassword.Controls.Add(txtRepetir2);
                            txtBox.Dispose();
                        }
                    }
                }

                txtAnterior2.Enter += new EventHandler(CuadrosDeTexto_Enter);
                txtAnterior2.Leave += new EventHandler(CuadrosDeTexto_Leave);
                txtNueva2.Enter += new EventHandler(this.CuadrosDeTexto_Enter);
                txtNueva2.Leave += new EventHandler(this.CuadrosDeTexto_Leave);
                txtRepetir2.Enter += new EventHandler(this.CuadrosDeTexto_Enter);
                txtRepetir2.Leave += new EventHandler(this.CuadrosDeTexto_Leave);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbTipo_Enter(object sender, EventArgs e)
        {
            cmbTipo.BackColor = Color.LemonChiffon;
        }

        private void cmbTipo_Leave(object sender, EventArgs e)
        {
            cmbTipo.BackColor = Color.White;
        }

        private void pbHelpPassword_MouseEnter(object sender, EventArgs e)
        {
            ttHelp.Active = true;
            ttHelp.SetToolTip(pbHelpPassword, "Desde aquí puede cambiar la clave\nque le permitirá poder restaurar las\ncopias." +
                                    "\nTiene que saber la clave inicial\npara poder cambiarla.");
        }

        private void pbHelpExclusiones_MouseEnter(object sender, EventArgs e)
        {
            ttHelp.Active = true;
            ttHelp.SetToolTip(pbHelpExclusiones, "Aquí se se especifican los tipos de archivos\nque no se quieren incluir en la copia.");
        }

        private void pbHelpOpciones_MouseEnter(object sender, EventArgs e)
        {
            ttHelp.Active = true;
            ttHelp.SetToolTip(pbHelpOpciones, "En el campo nombre del disco tiene que\nespecificar la etiqueta (LABEL) del disco\ndestino de copias." +
                        "\nEn el segundo campo tiene que especificar\nel tipo disco de copias.");
        }

        private void pbHelpPassword_MouseLeave(object sender, EventArgs e)
        {
            ttHelp.Active = false;
        }

        private void pbHelpExclusiones_MouseLeave(object sender, EventArgs e)
        {
            ttHelp.Active = false;
        }

        private void pbHelpOpciones_MouseLeave(object sender, EventArgs e)
        {
            ttHelp.Active = false;
        }

        private void cmbCompresion_Enter(object sender, EventArgs e)
        {
            cmbCompresion.BackColor = Color.LemonChiffon;
        }

        private void cmbCompresion_Leave(object sender, EventArgs e)
        {
            cmbCompresion.BackColor = Color.White;
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            ttHelp.Active = true;
            ttHelp.SetToolTip(pbHelpCompresion, "Cuanto mayor sea el nivel de compresión\nmás tiempo se tardará en hacer la copia.");
        }

        private void pbHelpCompresion_MouseLeave(object sender, EventArgs e)
        {
            ttHelp.Active = false;
        }

        private void cmbCompresion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            byte[] numeros = { 8, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59 };

            foreach (byte byt in numeros)
            {
                if ((byte)e.KeyChar == byt)
                {
                    e.Handled = false;
                    break;
                }
            }
        }

        private void pbHelpControlErrores_MouseEnter(object sender, EventArgs e)
        {
            ttHelp.Active = true;
            ttHelp.SetToolTip(pbHelpControlErrores, "Especifica si los errores en las copias deben de mostrarse\n" +
                                "en los mensajes al hacer una copia y si deben de ser\n" +
                                "registrados en el visor de eventos.");
        }

        private void pbHelpControlErrores_MouseLeave(object sender, EventArgs e)
        {
            ttHelp.Active = false;
        }

        private void pbHelpPrePost_MouseEnter(object sender, EventArgs e)
        {
            ttHelp.Active = true;
            ttHelp.SetToolTip(pbHelpPrePost, "Especifica las tareas a ejecutar antes y después\n" +
                                "de hacer y terminar la copia de seguridad.");
        }

        private void pbHelpPrePost_MouseLeave(object sender, EventArgs e)
        {
            ttHelp.Active = false;
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdlg = new OpenFileDialog();
            ofdlg.Title = "Abrir tarea pre respaldo";
            ofdlg.FileName = txtPre.Text;
            if (ofdlg.ShowDialog() == DialogResult.OK)
                txtPre.Text = ofdlg.FileName;
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdlg = new OpenFileDialog();
            ofdlg.Title = "Abrir tarea post respaldo";
            ofdlg.FileName = txtPost.Text;
            if (ofdlg.ShowDialog() == DialogResult.OK)
                txtPost.Text = ofdlg.FileName;
        }

        private void lklblMostrarErrores_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string dbase = Application.StartupPath + "\\Datos.mdb";
            ArrayList arr = new ArrayList();

            try
            {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbase + ";User Id=admin;Password=;");
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM Logs WHERE Evento LIKE 'Error%';", con);
                con.Open();
                OleDbDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        arr.Add("Fecha: " + dr[1].ToString() + " / Evento: " + dr[2].ToString() +
                                " / Equipo: " + dr[3].ToString() + " / Usuario: " + dr[4].ToString());
                    }

                    frmErroresRest frmErrores = new frmErroresRest(arr, "[ Listado de errores producidos durante el proceso de copias ]...");
                    frmErrores.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No se encuentran errores", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dr.Close();
                con.Close();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmOpciones_Load(object sender, EventArgs e)
        {
            cmbCompresion.DropDownHeight = 105;
            btnPre.Location = new Point(txtPre.Location.X + txtPre.Width + 5, btnPre.Location.Y);
            btnPost.Location = new Point(txtPost.Location.X + txtPost.Width + 5, btnPost.Location.Y);
            cmbControlErrores.Left = label12.Left + label12.Width + 5;
            lklblMostrarErrores.Left = cmbControlErrores.Left + cmbControlErrores.Width + 5;
            // cmbCompresion.DropDownWidth = 50;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = panel2.ClientRectangle;
            LinearGradientBrush lgb = new LinearGradientBrush(rect, Color.White, Color.LightGray, 90);
            g.FillRectangle(lgb, rect);
            Pen linea = new Pen(Brushes.Black, 1);
            g.DrawLine(linea, new Point(0, 0), new Point(rect.Width, 0));
            g.DrawLine(linea, new Point(0, rect.Height - 1), new Point(rect.Width, rect.Height - 1));
        }

        private void pnlAbajo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = pnlAbajo.ClientRectangle;
            LinearGradientBrush lgb = new LinearGradientBrush(rect, Color.Silver, Color.White, 90);
            g.FillRectangle(lgb, rect);
            Pen linea = new Pen(Brushes.Black, 1);
            g.DrawLine(linea, new Point(0, 0), new Point(rect.Width, 0));
            g.DrawLine(linea, new Point(0, rect.Height - 1), new Point(rect.Width, rect.Height - 1));
        }

        private void btnAceptar_Cancelar_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.FlatAppearance.BorderSize = 1;
        }

        private void btnAceptar_Cancelar_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.FlatAppearance.BorderSize = 0;
        }

        private void frmOpciones_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void label5_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            StringFormat sf = new StringFormat();
            sf.Trimming = StringTrimming.EllipsisCharacter;
            Font fuente = new Font(label5.Font, label5.Font.Style);
            g.DrawString(textoLabel5, fuente, Brushes.Black, g.ClipBounds, sf);
        }
    }
}
