using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BackupRestore
{
    public partial class frmInfoRestNoComp : Form
    {
        frmRestaurar _frmPadre;
        long tamañototal;
        long restante;

        public frmInfoRestNoComp(FileInfo Fichero, frmRestaurar FrmParent, string Origen, long TamañoTotal)
        {
            InitializeComponent();
            lvArchs.Items.Clear();
            lvArchs.Select();
            _frmPadre = FrmParent;
            lvArchs.Columns[0].Width -= 12;
            lblInfo.Text = Origen;
            tamañototal = TamañoTotal / 1024;
            restante = tamañototal;
        }

        private void frmInfoRestComp_Load(object sender, EventArgs e)
        {
        }

        public void Limpiar()
        {
            lvArchs.Items.Clear();
        }

        public void PonerDatos(FileInfo fi)
        {
            ListViewItem it = new ListViewItem(fi.Name);
            it.SubItems.Add(fi.CreationTime.ToShortDateString());
            it.SubItems.Add(fi.Length.ToString("N"));
            lvArchs.Items.Add(it);
            lvArchs.EnsureVisible(lvArchs.Items.Count - 1);
            lvArchs.FocusedItem = it;
            restante -= (fi.Length / 1024);
            lblTamaño.Text = restante.ToString("N") + " / " + tamañototal.ToString("N") + " KB";
            Application.DoEvents();
        }

        private void frmInfoRestComp_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnParar_Click(object sender, EventArgs e)
        {
            prgRest.MarqueeAnimationSpeed = 0;

            if (MessageBox.Show("¿Para el proceso de restaurar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                btnParar.Text = "Cancelando...";
                _frmPadre.Parar();
                Salir();
            }

            if (btnPausar.Text != "&Continuar")
                prgRest.MarqueeAnimationSpeed = 100;
        }

        private void Salir()
        {
            this.Dispose();
            this.Close();
        }

        private void btnPausar_Click(object sender, EventArgs e)
        {
            if (btnPausar.Text == "P&ausar")
            {
                prgRest.MarqueeAnimationSpeed = 0;
                btnPausar.Text = "&Continuar";
                btnPausar.Image = Properties.Resources.Play32x32;
                _frmPadre.Pausar(true);
                Application.DoEvents();
            }
            else if (btnPausar.Text == "&Continuar")
            {
                prgRest.MarqueeAnimationSpeed = 100;
                btnPausar.Text = "P&ausar";
                btnPausar.Image = Properties.Resources.Pause32x32;
                _frmPadre.Pausar(false);
                Application.DoEvents();
            }
        }
    }
}