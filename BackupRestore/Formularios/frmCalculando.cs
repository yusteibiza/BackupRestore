using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BackupRestore
{
    public partial class frmCalculando : Form
    {
        private bool mCancelar=false;

        public frmCalculando()
        {
            mCancelar = false;
            InitializeComponent();
            btnOculto.Select();
        }

        private void frmCalculando_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Alt & e.KeyCode == Keys.F4)
                e.Handled = true;
        }

        private void frmCalculando_Load(object sender, EventArgs e)
        {
            prgb.MarqueeAnimationSpeed = 20;
            this.Activate();
        }

        private void frmCalculando_Leave(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            mCancelar = true;
            btnOculto.Select();
            btnCancelar.Text = "Cancelando...";
        }

        public bool Cancelar
        {
            get
            {
                return mCancelar;
            }
            set
            {
                mCancelar = value;
            }
        }
    }
}