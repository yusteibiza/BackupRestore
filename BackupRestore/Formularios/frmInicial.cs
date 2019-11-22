using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace BackupRestore
{
    public partial class frmInicial : Form
    {
        BackgroundWorker bwHora;
        EventosApp epp;

        #region Métodos creados por mí

        private void Hora()
        {
            int hora = DateTime.Now.Hour;

            if (hora >= 7 && hora <= 12)
                stsLbl1.Text = "¡¡¡ Buenos días !!!";
            else if (hora >= 13 && hora <= 20)
                stsLbl1.Text = "¡¡¡ Buenas tardes !!!";
            else if ((hora >= 21 && hora <= 23) || (hora >= 0 && hora <= 6))
                stsLbl1.Text = "¡¡¡ Buenas noches !!!";
        }
        #endregion

        #region Constructor de la clase

        public frmInicial()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            lblHora.Location = new Point(lblHora.Left, kryptonPanel2.Height - lblHora.Height);
            bwHora = new BackgroundWorker();
            bwHora.DoWork += BwHora_DoWork;
            bwHora.RunWorkerAsync();
            btnSec.Focus();
            btnSec.Select();

        }

        private void BwHora_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                try
                {
                    lblHora.Text = DateTime.Now.ToLongTimeString();
                    Application.DoEvents();
                }
                catch (Exception)
                {
                }
            }
        }

        #endregion

        private void frmInicial_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.password == "")
            {
                Properties.Settings.Default.password = "1234";
                Properties.Settings.Default.Save();
            }

            this.Enabled = false;
            this.Opacity = 0;
            tmrEntrada.Start();
            Hora();
            epp = new EventosApp();
            epp.PonerEvento("Se ha iniciado Backup&Restore.");
            DateTime ahora = DateTime.Now;
            DateTime despues = ahora.AddSeconds(1);

            while (ahora <= despues)
            {
                ahora = DateTime.Now;
                Application.DoEvents();
            }
        }

        private void btnConfig_MouseMove(object sender, MouseEventArgs e)
        {
            stsLbl1.Text = "Configurar las copias de seguridad";
        }

        private void btnCopiar_MouseMove(object sender, MouseEventArgs e)
        {
            stsLbl1.Text = "Crear copia de seguridad";
        }

        private void btnRestaurar_MouseMove(object sender, MouseEventArgs e)
        {
            stsLbl1.Text = "Restaurar copias de seguridad";
        }

        private void lnkSalir_MouseMove(object sender, MouseEventArgs e)
        {
            stsLbl1.Text = "Salir del programa";
        }

        private void lnkSalir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void lnkSalir_MouseLeave(object sender, EventArgs e)
        {
            Hora();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            try
            {
                epp.PonerEvento("Se ha accedido a la configuración.");

                this.Visible = false;
                frmConfig frmc = new frmConfig();
                frmc.ShowDialog();
                this.Visible = true;
                btnSec.Select();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            try
            {
                epp.PonerEvento("Se ha accedido al formulario de copias.");

                this.Visible = false;
                frmCopiar fmc = new frmCopiar(false);
                fmc.ShowDialog();
                this.Visible = true;
                btnSec.Select();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmPasswd frmp = new frmPasswd();
            frmp.ShowDialog();
            this.Visible = true;
            btnSec.Select();
        }

        private void lnkAcerca_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible = false;
            frmAcerca fa = new frmAcerca();
            fa.ShowDialog();
            this.Visible = true;
            btnSec.Select();
        }

        private void lnkAcerca_MouseMove(object sender, MouseEventArgs e)
        {
            stsLbl1.Text = "Información sobre el programa";
        }

        private void lnkAcerca_MouseLeave(object sender, EventArgs e)
        {
            Hora();
        }

        private void frmInicial_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            if (MessageBox.Show("¿Salir del programa de copias?", "Salir", MessageBoxButtons.YesNo
                           , MessageBoxIcon.Question) == DialogResult.Yes)
            {
                epp.PonerEvento("Se ha finalizado Backup&Restore.");
                this.Enabled = false;
                tmrSalida.Start();
            }
        }

        private void llblLogs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible = false;
            frmLog frml = new frmLog();
            frml.ShowDialog();
            this.Visible = true;
        }

        private void tmrSalida_Tick(object sender, EventArgs e)
        {
            try
            {
                this.Opacity -= 0.1;
                Application.DoEvents();

                if (this.Opacity <= 0)
                    Environment.Exit(0);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.Opacity = 1;
            }
        }

        private void tmrEntrada_Tick(object sender, EventArgs e)
        {
            try
            {
                this.Opacity += 0.1;
                Application.DoEvents();
                if (this.Opacity >= 1)
                {
                    tmrEntrada.Stop();
                    this.Enabled = true;
                    this.BringToFront();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.Opacity = 1;
            }
        }

        private void lklblOpciones_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible = false;
            frmOpciones frmo = new frmOpciones();
            frmo.ShowDialog();
            this.Visible = true;
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            //    if (Emails.EnviarInforme(Emails.ResultadoCopia.OK, "Inicio .: 06/02/2019 23:20:00\n" +
            //                                                       "Fin .....: 06/02/2019 23:25:38") == 0)
            //        MessageBox.Show("Mensaje enviado correctamente");
            //    else
            //        MessageBox.Show("Error al enviar el mensaje");

            char[] borrar = { 'a', 'o', ' ' };
            string nombre = "                    antonio josé yuste López                       ";
            string res = nombre.Trim(borrar);
            MessageBox.Show(res);
            string resultado1 = nombre[0].ToString().ToUpper();
            string resultado2 = resultado1 + nombre.Substring(1);
            string resultado3 = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nombre);
            MessageBox.Show(resultado3);
        }

        private void llblMenus_MouseEnter(object sender, EventArgs e)
        {
            LinkLabel lnklbl = (LinkLabel)sender;
            Font fuenteNueva = new Font(lnklbl.Font.Name, lnklbl.Font.Size + (float)0.5, FontStyle.Bold);
            lnklbl.Font = fuenteNueva;
        }

        private void llblMenus_MouseLeave(object sender, EventArgs e)
        {
            LinkLabel lnklbl = (LinkLabel)sender;
            Font fuenteNueva = new Font(lnklbl.Font.Name, lnklbl.Font.Size - (float)0.5, FontStyle.Regular);
            lnklbl.Font = fuenteNueva;
        }

        private void BotonesCentrales_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Font fuenteNueva = new Font(btn.Font.Name, btn.Font.Size + (float)0.5, FontStyle.Bold);
            btn.Font = fuenteNueva;
            btn.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
        }

        private void BotonesCentrales_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Font fuenteNueva = new Font(btn.Font.Name, btn.Font.Size - (float)0.5, FontStyle.Regular);
            btn.Font = fuenteNueva;
            btn.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            Hora();
        }
    }
}