using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace BackupRestore
{
    public partial class frmPasswd : Form
    {
        int intentos = 3;

        public frmPasswd()
        {
            InitializeComponent();
            pbVerPasswordSMTP.Height = txtPasswd.Height;
        }

        private void frmPasswd_Load(object sender, EventArgs e)
        {
            txtPasswd.Select();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtPasswd.Text == Properties.Settings.Default.password)
            {
                this.Visible = false;
                frmRestaurar frmr = new frmRestaurar();
                frmr.ShowDialog();
                this.Close();
            }
            else
            {
                intentos--;

                if (intentos != 0)
                {
                    MessageBox.Show("Clave incorrecta.", "Error",
                                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPasswd.Select();
                    txtPasswd.SelectAll();
                }
                else
                {
                    this.Close();
                }

                lblIntentos.Text = intentos.ToString() + " intentos restantes";

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPasswd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEntrar_Click(sender, e);
            }
        }

        private void frmPasswd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)e.KeyChar == 13)
                e.Handled = true;
        }

        private void pbVerPasswordSMTP_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                txtPasswd.UseSystemPasswordChar = false;
        }

        private void frmPasswd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void pbVerPasswordSMTP_MouseUp(object sender, MouseEventArgs e)
        {
            txtPasswd.UseSystemPasswordChar = true;
        }

        private void txtPasswd_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnEntrar_Click(sender, e);
        }
    }
}