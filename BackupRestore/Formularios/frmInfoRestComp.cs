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
    public partial class frmInfoRestComp : Form
    {
        ICSharpCode.SharpZipLib.Zip.ZipEntry _entrada;
        long _tamañoZip;
        string _nombrezip;
        frmRestaurar _frmPadre;
        long _restante;

        public frmInfoRestComp(ICSharpCode.SharpZipLib.Zip.ZipEntry EntradaZip, string NombreArchivoZip, frmRestaurar FrmParent)
        {
            InitializeComponent();
            _entrada = EntradaZip;
            _nombrezip = NombreArchivoZip;
            _frmPadre = FrmParent;
            lblInfo.Text = _nombrezip;
            lvZips.Items.Clear();
            lvZips.Select();
            FileInfo f = new FileInfo(NombreArchivoZip);
            _tamañoZip = f.Length / 1024;
            _restante = _tamañoZip;
            lvZips.Columns[0].Width -= 16;
        }

        private void frmInfoRestComp_Load(object sender, EventArgs e)
        {
            lblTamaño.Text = _tamañoZip.ToString("N") + " / " + _tamañoZip.ToString("N") + " KB";
        }

        public void Limpiar()
        {
            lvZips.Items.Clear();
        }

        public string NombreArchivoZip
        {
            get
            {
                return _nombrezip;
            }
            set
            {
                _nombrezip = value;
                lblInfo.Text = _nombrezip;
            }
        }

        public void PonerDatos(ICSharpCode.SharpZipLib.Zip.ZipEntry entrada)
        {
            FileInfo fi = new FileInfo(entrada.Name);
            ListViewItem it = new ListViewItem(fi.Name);
            it.SubItems.Add(entrada.DateTime.ToShortDateString());
            it.SubItems.Add(entrada.Size.ToString("N"));
            it.SubItems.Add(entrada.Crc.ToString());
            lvZips.Items.Add(it);
            lvZips.EnsureVisible(lvZips.Items.Count - 1);
            lvZips.FocusedItem = it;
            _restante -= entrada.CompressedSize / 1024;
            lblTamaño.Text = _restante.ToString("N") + " / " + _tamañoZip.ToString("N") + " KB";
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