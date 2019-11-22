using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BackupRestore
{
    public partial class frmGuardando : Form
    {
        public frmGuardando()
        {
            InitializeComponent();
        }

        private void frmGuardando_Load(object sender, EventArgs e)
        {
            this.Location = new Point(this.Location.X, this.Location.Y - 50);
        }

        public int ValorMaxProgreso
        {
            set
            {
                prgb.Maximum = value;
                lblTotal.Text = "0%";
            }
        }

        public int ValorActualProgreso
        {
            set
            {
                prgb.Value = value;
                Application.DoEvents();
                System.Threading.Thread.Sleep(250);
                int porcentajeHecho = (prgb.Value * 100) / prgb.Maximum;
                lblTotal.Text = porcentajeHecho.ToString() + "%";
                PrimerPlano();
            }
        }

        private void frmGuardando_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Alt & e.KeyCode == Keys.F4)
                e.Handled = true;
        }

        private void frmGuardando_Leave(object sender, EventArgs e)
        {
            PrimerPlano();
        }

        private void PrimerPlano()
        {
            this.Activate();
        }
    }
}