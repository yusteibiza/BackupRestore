using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace BackupRestore
{
    public partial class frmPre : Form
    {
        BackgroundWorker bw;
        bool saliendo;

        const int WM_SYSCOMMAND = 0x112;
        const int MOUSE_MOVE = 0xF012;

        // Declaraciones del API 
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        //

        public frmPre(bool SegundoPlano)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.Visible = !SegundoPlano;
            if (SegundoPlano == true)
                this.WindowState = FormWindowState.Minimized;
            saliendo = false;
            lblEfecto1.Left = 10;
            lblEfecto2.Left = this.Width - lblEfecto2.Width - 10;
            bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerAsync();
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (saliendo)
                {
                    e.Cancel = true;
                    break;
                }

                try
                {
                    
                    if (lblEfecto1.Left <= (this.Width - 10) - lblEfecto1.Width)
                    {
                        lblEfecto1.Left += 3;
                        lblEfecto2.Left -= 3;
                        Thread.Sleep(10);
                    }
                    else
                    {
                        while (lblEfecto1.Left >= 10)
                        {
                            lblEfecto1.Left -= 3;
                            lblEfecto2.Left += 3;
                            Thread.Sleep(10);
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        public void Posicionar(Form formularioPadre)
        {
            int diferenciaX = formularioPadre.Width - this.Width;
            int diferenciaY = formularioPadre.Height - this.Height;
            Point loc = new Point(((formularioPadre.Width + formularioPadre.Left) - (diferenciaX + this.Width) + (diferenciaX / 2)),
                (((formularioPadre.Height + formularioPadre.Top) - (diferenciaY + this.Height) + diferenciaY / 2)));
            this.Location = loc;
            Application.DoEvents();
        }

        private void frmPre_FormClosing(object sender, FormClosingEventArgs e)
        {
            saliendo = true;
        }

        private void frmPre_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                moverForm();
        }

        private void moverForm()
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, MOUSE_MOVE, 0);
        }
    }
}
