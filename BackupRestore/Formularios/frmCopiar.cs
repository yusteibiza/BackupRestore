using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace BackupRestore
{
    public partial class frmCopiar : Form
    {
        bool vistaerrores = false; //controla la ocultación o aparición de la ventana de errores.
        bool copiando = false; //variable que controla si se puede cerrar el formulario al pulsar el botón 'salir'
        CopiaComprimida copc = null;
        CopiaSinComprimir cops = null;
        OleDbCommand com = null;
        OleDbConnection con = null;
        OleDbDataReader dr;
        EventosApp epp = null;
        bool comprimir = false;
        Size tamañoForm;
        private bool segundoPlano;

        //Función para cerrar el formulario
        private void Salir()
        {
            if (copiando == false)
            {
                epp.PonerEvento("Se ha salido del formulario de copias.");
                this.Visible = false;
                this.Dispose();
                this.Close();
            }
        }

        public frmCopiar(bool SegundoPlano)
        {
            string dbase = Application.StartupPath + "\\Datos.mdb";

            try
            {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbase + ";User Id=admin;Password=;");
                con.Open();
                com = new OleDbCommand("SELECT * FROM Opciones;", con);
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            epp = new EventosApp();
            InitializeComponent();

            segundoPlano = SegundoPlano;
        }

        private void frmCopiar_Load(object sender, EventArgs e)
        {
            //Se crea el objeto cop de la clase 'copiar.cs' y se le pasan todos los objetos del constructor
            copc = new CopiaComprimida(lblCiclo, lvErrores, tsslblNumErrores, lblContador, progressBar1, lblObjeto, btnConfigurar, btnEmpezar, btnParar, btnSalir, chkApagar, lblDirCopias, lblXciento);
            cops = new CopiaSinComprimir(lblCiclo, lvErrores, tsslblNumErrores, lblContador, progressBar1, lblObjeto, btnConfigurar, btnEmpezar, btnParar, btnSalir, chkApagar, lblDirCopias, lblXciento);
            copc.CopiaIniciada += Copc_CopiaIniciada;
            copc.CopiaFinalizada += Copc_CopiaFinalizada;
            cops.CopiaIniciada += Cops_CopiaIniciada;
            cops.CopiaFinalizada += Cops_CopiaFinalizada;
            copc.PonerDestinos();
            this.Size = new Size(698, 290);
            this.Location = new Point(this.Location.X, this.Location.Y + 50);
            btnEmpezar.Select();
            lblObjeto.Location = new Point(149, lblCopiando.Top);
            lblObjeto.Width += 10;
            chkApagar.Location = new Point(363, lblDirCopias.Top);
            lblContador.Left -= 2;
            lblDirCopias.Left = lblProgreso.Left + 1;
            lblCiclo.Left += 5;
            PonerValores();
            this.Size = new Size(698, 293);
            if (Environment.OSVersion.Version.ToString().Substring(0, 1) != "5")
                this.Size = new Size(this.Size.Width, this.Size.Height - 5);
            tamañoForm = this.Size;
        }

        private void ControlBarraErrores()
        {
            if (Properties.Settings.Default.control_errores == false & copc.ArchivoActual != copc.ArchivosTotales & copiando == true)
            {
                try
                {
                    progressBar1.Value = progressBar1.Maximum;
                    lblXciento.Text = "100%";
                    lblContador.Text = copc.ArchivosTotales.ToString("#,#") + " / " + copc.ArchivosTotales.ToString("#,#") + " archivos";
                    lvErrores.BackColor = Color.LightSalmon;
                    Application.DoEvents();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void Cops_CopiaFinalizada()
        {
            try
            {
                if (cops.HayErrores() == false)
                {
                    //Si hay alguna tarea que ejecutar despues se ejecuta
                    if (File.Exists(Properties.Settings.Default.ejecutarDespues))
                    {
                        if (btnParar.Text != "Finalizando")
                        {
                            frmPost frmpost = new frmPost(segundoPlano);
                            frmpost.Posicionar(this);
                            frmpost.Show();
                            frmpost.Focus();
                            Application.DoEvents();
                            ProcessStartInfo psi = new ProcessStartInfo(Properties.Settings.Default.ejecutarDespues);
                            FileInfo fi = new FileInfo(Properties.Settings.Default.ejecutarDespues);
                            epp.PonerEvento("Ejecutar tarea post respaldo >> " + fi.FullName);
                            psi.WorkingDirectory = fi.Directory.FullName;
                            psi.UseShellExecute = true;
                            psi.CreateNoWindow = true;
                            psi.WindowStyle = ProcessWindowStyle.Hidden;
                            Process p = Process.Start(psi);
                            p.WaitForExit();
                            Thread.Sleep(1000);
                            frmpost.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Application.DoEvents();
                this.Enabled = true;
                this.Focus();
            }
        }

        private void Cops_CopiaIniciada()
        {
            try
            {
                Application.DoEvents();

                //Si hay alguna tarea que ejecutar antes se ejecuta
                if (File.Exists(Properties.Settings.Default.ejecutarAntes))
                {
                    lblObjeto.Text = "Ejecutando tarea pre respaldo...";
                    this.Enabled = false;
                    frmPre frmpre = new frmPre(segundoPlano);
                    frmpre.Posicionar(this);
                    frmpre.Show();
                    frmpre.Focus();
                    Application.DoEvents();
                    ProcessStartInfo psi = new ProcessStartInfo(Properties.Settings.Default.ejecutarAntes);
                    FileInfo fi = new FileInfo(Properties.Settings.Default.ejecutarAntes);
                    epp.PonerEvento("Ejecutar tarea pre respaldo >> " + fi.FullName);
                    psi.WorkingDirectory = fi.Directory.FullName;
                    psi.UseShellExecute = true;
                    psi.CreateNoWindow = true;
                    psi.WindowStyle = ProcessWindowStyle.Hidden;
                    Process p = Process.Start(psi);
                    p.WaitForExit();
                    Thread.Sleep(1000);
                    frmpre.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Enabled = true;
                this.Focus();
            }
        }

        private void Copc_CopiaFinalizada()
        {
            try
            {
                if (copc.ArchivosTotales == 0)
                    lblContador.Text = "0 / 0 archivos";

                if (copc.HayErrores() == false)
                {
                    //Si hay alguna tarea que ejecutar despues se ejecuta
                    if (File.Exists(Properties.Settings.Default.ejecutarDespues))
                    {
                        if (btnParar.Text != "Finalizando")
                        {
                            this.Enabled = false;
                            frmPost frmpost = new frmPost(segundoPlano);
                            frmpost.Posicionar(this);
                            frmpost.Show();
                            frmpost.Focus();
                            Application.DoEvents();
                            ProcessStartInfo psi = new ProcessStartInfo(Properties.Settings.Default.ejecutarDespues);
                            FileInfo fi = new FileInfo(Properties.Settings.Default.ejecutarDespues);
                            epp.PonerEvento("Ejecutar tarea post respaldo >> " + fi.FullName);
                            psi.WorkingDirectory = fi.Directory.FullName;
                            psi.UseShellExecute = true;
                            psi.CreateNoWindow = true;
                            psi.WindowStyle = ProcessWindowStyle.Hidden;
                            Process p = Process.Start(psi);
                            p.WaitForExit();
                            Thread.Sleep(1000);
                            frmpost.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Application.DoEvents();
                this.Enabled = true;
                this.Focus();
            }
        }

        private void Copc_CopiaIniciada()
        {
            try
            {
                Application.DoEvents();

                //Si hay alguna tarea que ejecutar antes se ejecuta
                if (File.Exists(Properties.Settings.Default.ejecutarAntes))
                {
                    lblObjeto.Text = "Ejecutando tarea pre respaldo...";
                    this.Enabled = false;
                    frmPre frmpre = new frmPre(segundoPlano);
                    frmpre.Posicionar(this);
                    frmpre.Show();
                    frmpre.Focus();
                    Application.DoEvents();
                    ProcessStartInfo psi = new ProcessStartInfo(Properties.Settings.Default.ejecutarAntes);
                    FileInfo fi = new FileInfo(Properties.Settings.Default.ejecutarAntes);
                    epp.PonerEvento("Ejecutar tarea pre respaldo >> " + fi.FullName);
                    psi.WorkingDirectory = fi.Directory.FullName;
                    psi.UseShellExecute = true;
                    psi.CreateNoWindow = true;
                    psi.WindowStyle = ProcessWindowStyle.Hidden;
                    Process p = Process.Start(psi);
                    p.WaitForExit();
                    Thread.Sleep(1000);
                    frmpre.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Enabled = true;
                this.Focus();
            }
        }

        public void PonerValores()
        {
            com.CommandText = "SELECT * FROM Opciones;";
            dr = com.ExecuteReader();

            try
            {
                while (dr.Read())
                {
                    comprimir = dr.GetBoolean(1);
                }

                dr.Close();

                com.CommandText = "SELECT * FROM destinos;";
                dr = com.ExecuteReader();

                while (dr.Read())
                {
                    if (System.IO.Directory.Exists(dr.GetString(1)))
                        chkApagar.Checked = Properties.Settings.Default.apagar;
                    else
                        chkApagar.Checked = false;
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con != null)
                    if (con.State == ConnectionState.Open)
                        con.Close();
            }

            if (comprimir)
            {
                this.Text = "Copias de seguridad... (Comprimidas)";
            }
            else
            {
                this.Text = "Copias de seguridad... (Sin Comprimir)";
            }
        }

        /*Función para mostrar u ocultar la ventana de errores
        La variable 'vistaerrores' se pone a true o false para determinar el estado de mostrar u ocultar la ventana de errores*/
        private void btnErrores_Click(object sender, EventArgs e)
        {
            if (vistaerrores == false)
            {
                vistaerrores = true;
                VerErrores();
                btnErrores.Image = Properties.Resources.Arriba;
                lblErrores.Text = "Ocultar errores...";
            }
            else
            {
                vistaerrores = false;
                OcultarErrorers();
                btnErrores.Image = Properties.Resources.Abajo;
                lblErrores.Text = "Mostrar errores...";
            }
        }

        //Muestra la ventana de errores
        private void VerErrores()
        {
            kpnlErrores.Visible = true;
            int y = this.Height;
            while (this.Height <= 591)
            {
                y += 20;
                this.Size = new Size(698, y);
                Application.DoEvents();
            }
            this.Size = new Size(698, 591);
        }

        //Oculta la ventana de errores
        private void OcultarErrorers()
        {
            int y = this.Height;
            while (this.Size.Height >= tamañoForm.Height)
            {
                y -= 10;
                this.Size = new Size(698, y);
                Application.DoEvents();
            }

            if (Environment.OSVersion.Version.ToString().Substring(0, 1) != "5")
                this.Size = new Size(this.Size.Width, this.Size.Height - 5);

            this.Size = new Size(tamañoForm.Width, tamañoForm.Height);

            kpnlErrores.Visible = false;
        }

        private void frmCopiar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Alt & e.KeyCode == Keys.F4 || e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                Salir();
            }
        }

        private void btnConfigurar_Click(object sender, EventArgs e)
        {
            epp.PonerEvento("Se ha accedido a la configuración.");
            frmConfig frmc = new frmConfig();
            this.Visible = false;
            frmc.ShowDialog();
            this.Visible = true;
            PonerValores();
        }

        private void krpnlabajo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnErrores_Click(sender, new EventArgs());
        }

        private void lblErrores_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnErrores_Click(sender, new EventArgs());
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (!copiando)
            {
                Salir();
            }
        }

        private void frmCopiar_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnEmpezar_Click(object sender, EventArgs e)
        {
            btnConfigurar.Enabled = false;
            btnEmpezar.Enabled = false;
            btnParar.Enabled = false;
            btnSalir.Enabled = false;
            tmrCopiando.Enabled = true;
            lvErrores.BackColor = Color.White;
            lblXciento.Text = "0%";
            lblContador.Text = "0 / 0 archivos";
            progressBar1.Value = 0;
            Application.DoEvents();
            EmpezarCopia();
            btnParar.Enabled = false;
            tmrCopiando.Enabled = false;
        }

        private void btnParar_Click(object sender, EventArgs e)
        {
            if (copiando)
            {
                if (btnParar.Text != "Finalizando")
                {
                    if (MessageBox.Show("¿Está seguro de interrumpir la copia?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                                              DialogResult.Yes)
                    {
                        if (comprimir)
                        {
                            copc.Parar();
                            copc.CerrarArchivoZip();
                        }
                        else
                        {
                            cops.Parar();
                        }

                        btnParar.Text = "Finalizando";
                        copiando = false;
                        btnParar.Enabled = false;
                    }
                }
            }
        }

        //Se ha pulsado el botón 'empezar' y se llama a la función EmpezarCopia() del objeto cop
        public void EmpezarCopia()
        {
            this.Visible = !segundoPlano;
            notifyIcon1.BalloonTipText = "Efectuando copia de seguridad...";
            notifyIcon1.Text = notifyIcon1.BalloonTipText;
            notifyIcon1.Visible = !this.Visible;
            notifyIcon1.ShowBalloonTip(3000);
            ctxEstado.Text = "[ Efectuando copia ]";
            Application.DoEvents();
            DateTime despues = DateTime.Now.AddSeconds(2);

            while (despues >= DateTime.Now)
            {
                Application.DoEvents();
            }

            copiando = true;
            lblObjeto.Text = "Se ha iniciado el proceso de copias...";
            btnEmpezar.Enabled = false;
            btnConfigurar.Enabled = false;
            btnParar.Enabled = true;
            btnSalir.Enabled = false;

            if (comprimir)
            {
                epp.PonerEvento("Se ha iniciado el proceso de copias comprimidas.");
                //Thread.Sleep(1000);
                btnParar.Enabled = true;
                Application.DoEvents();
                copc.EmpezarCopia();
                copc.CerrarArchivoZip();
            }
            else
            {
                epp.PonerEvento("Se ha iniciado el proceso de copias no comprimidas.");
                //Thread.Sleep(1000);
                btnParar.Enabled = true;
                Application.DoEvents();
                cops.EmpezarCopia();
            }

            copiando = false;
            btnEmpezar.Enabled = true;
            btnConfigurar.Enabled = true;
            btnParar.Enabled = false;
            btnSalir.Enabled = true;
            btnParar.Text = "Parar";
            if (ctxEstado.Text != "[ Cancelando copia ]")
                notifyIcon1.Text = "[ Copia finalizada ]";
            else
                notifyIcon1.Text = "[ Copia cancelada ]";

            notifyIcon1.BalloonTipText = notifyIcon1.Text;
            notifyIcon1.ShowBalloonTip(3000);

            notifyIcon1.Visible = false;
        }

        //Se guarda el valor del checkbox apagar en la variable del objeto propiedades de la aplicación
        private void chkApagar_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.apagar = chkApagar.Checked;

            if (chkApagar.Checked)
                epp.PonerEvento("Se ha activado apagar al finalizar la copia.");
            else
                epp.PonerEvento("Se ha desactivado apagar al finalizar la copia.");
        }

        private void tmrCopiando_Tick(object sender, EventArgs e)
        {
            Image img = pbCopiando.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pbCopiando.Image = img;
            Application.DoEvents();
            //pbCopiando.Image.RotateFlip(RotateFlipType.RotateNoneFlipXY);
        }

        private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ctxEstado.Text = "[ Cancelando copia ]";
            copiando = false;
            notifyIcon1.Text = ctxEstado.Text;
            notifyIcon1.BalloonTipText = notifyIcon1.Text;
            notifyIcon1.ShowBalloonTip(3000);
            cancelarToolStripMenuItem.Visible = false;
            toolStripSeparator1.Visible = false;
        }
    }
}