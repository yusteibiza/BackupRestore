using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using Microsoft.Win32.TaskScheduler;
using System.Threading;
using System.Net;

namespace BackupRestore
{
    public partial class frmProgramador : Form
    {
        string horaAnterior = string.Empty;
        TaskService ts;
        BackgroundWorker bw;
        bool saliendo;

        public frmProgramador()
        {
            InitializeComponent();
            /* pnlInfoUsuario.Location = new Point(387, 73);
               pnlInfoUsuario.Size=new Size(171, 178);
            */
            CheckForIllegalCrossThreadCalls = false;
            saliendo = false;
            ts = new TaskService(Environment.MachineName);
            cmbDias.SelectedIndex = 3;
            CargarConfiguracion();
            bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerAsync();
            bw.WorkerSupportsCancellation = true;

            if (!ExisteServicio(txtNombreServicio.Text))
            {
                MessageBox.Show("El servicio <" + txtNombreServicio.Text + "> no se ha creado todavía,\n" +
                    "revise la configuración y pulse el botón <Crear>", "Aviso"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRutaEjecutable.Text = Application.StartupPath + "\\" +
                    System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe";

                btnCrearServicio.Enabled = true;
                txtNombreServicio.ReadOnly = false;
            }
            else
            {
                btnCrearServicio.Enabled = false;
                txtNombreServicio.ReadOnly = true;
            }
        }

        private void hiloRefrescarNotaUsuario()
        {
            pnlInfoUsuario.Refresh();
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

                if (ExisteServicio(txtNombreServicio.Text))
                {
                    try
                    {
                        foreach (Task t in ts.AllTasks)
                        {
                            if (t.Name.ToLower() == txtNombreServicio.Text.ToLower())
                            {
                                switch (t.State)
                                {
                                    case TaskState.Disabled:
                                        btnEstadoServicio.BackColor = Color.Red;
                                        btnEstadoServicio.Text = "Desactivado";
                                        break;
                                    case TaskState.Ready:
                                        btnEstadoServicio.BackColor = Color.Green;
                                        btnEstadoServicio.Text = "Activado";
                                        break;
                                    default:
                                        break;
                                }
                            }

                            Application.DoEvents();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    btnEstadoServicio.BackColor = Color.Gray;
                    btnEstadoServicio.Text = "?";
                }
            }
        }

        #region Configuración
        private void CargarConfiguracion()
        {
            try
            {
                txtNombreServicio.Text = Properties.Settings.Default.prgNombreServicio;
                txtRutaEjecutable.Text = Properties.Settings.Default.prgRutaEjecutable;
                txtUsuario.Text = Properties.Settings.Default.prgUsuario;
                txtPassword.Text = Properties.Settings.Default.prgPassword;
                chkEjecutarSinIniciarSesion.Checked = Properties.Settings.Default.prgEjecutarSinIniciarSesion;
                chkRegistrarErrores.Checked = Properties.Settings.Default.prgRegistrarErrores;
                dtpkrHora.Text = Properties.Settings.Default.prgHora;
                chkApagarAlFinalizar.Checked = Properties.Settings.Default.prgApagarAlFinalizar;
                chkSegundoPlano.Checked = Properties.Settings.Default.prgSegundoPlano;
                chkEnviarInforme.Checked = Properties.Settings.Default.prgEnviarInforme;
                txtDestinatario.Text = Properties.Settings.Default.prgDestinatario;
                txtServSMTP.Text = Properties.Settings.Default.prgServSMTP;
                txtUsuarioSMTP.Text = Properties.Settings.Default.prgUsuarioSMTP;
                txtPasswordSMTP.Text = Properties.Settings.Default.prgPasswordSMTP;
                nudPuertoSMTP.Value = Properties.Settings.Default.prgPuertoSMTP;
                chkConexiónSSL.Checked = Properties.Settings.Default.prgConexionSSL;

                string[] dias = Properties.Settings.Default.prgDias.Split(',');

                int valorDia = 0;

                for (int x = 0; x < dias.Length; x++)
                {
                    valorDia = Convert.ToInt16(dias[x]);
                    lbDias.SetSelected(valorDia, true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void GuardarConfiguracion()
        {
            if (lbDias.SelectedItems.Count != 0)
            {
                Properties.Settings.Default.prgNombreServicio = txtNombreServicio.Text;
                Properties.Settings.Default.prgRutaEjecutable = txtRutaEjecutable.Text;
                Properties.Settings.Default.prgUsuario = txtUsuario.Text;
                Properties.Settings.Default.prgPassword = txtPassword.Text;
                Properties.Settings.Default.prgEjecutarSinIniciarSesion = chkEjecutarSinIniciarSesion.Checked;
                Properties.Settings.Default.prgRegistrarErrores = chkRegistrarErrores.Checked;
                Properties.Settings.Default.prgHora = dtpkrHora.Text;
                Properties.Settings.Default.prgApagarAlFinalizar = chkApagarAlFinalizar.Checked;
                Properties.Settings.Default.prgSegundoPlano = chkSegundoPlano.Checked;
                Properties.Settings.Default.prgEnviarInforme = chkEnviarInforme.Checked;
                Properties.Settings.Default.prgDestinatario = txtDestinatario.Text;
                Properties.Settings.Default.prgUsuarioSMTP = txtUsuarioSMTP.Text;
                Properties.Settings.Default.prgServSMTP = txtServSMTP.Text;
                Properties.Settings.Default.prgPuertoSMTP = (int)nudPuertoSMTP.Value;
                Properties.Settings.Default.prgUsuarioSMTP = txtUsuarioSMTP.Text;
                Properties.Settings.Default.prgPasswordSMTP = txtPasswordSMTP.Text;
                Properties.Settings.Default.prgConexionSSL = chkConexiónSSL.Checked;

                string dias = string.Empty;

                for (int x = 0; x < lbDias.Items.Count; x++)
                {
                    if (lbDias.GetSelected(x))
                        dias += x + ",";
                }

                string diasFinal = dias.Remove(dias.Length - 1, 1);
                Properties.Settings.Default.prgDias = diasFinal;

                Properties.Settings.Default.Save();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún día, se quiere un día al menos", "Aviso",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        private void cmbDias_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbDias.SelectedIndex)
            {
                case 0:
                    lbDias.SetSelected(0, true);
                    lbDias.SetSelected(1, true);
                    lbDias.SetSelected(2, true);
                    lbDias.SetSelected(3, true);
                    lbDias.SetSelected(4, true);
                    lbDias.SetSelected(5, true);
                    lbDias.SetSelected(6, true);
                    break;
                case 1:
                    lbDias.SetSelected(0, false);
                    lbDias.SetSelected(1, false);
                    lbDias.SetSelected(2, false);
                    lbDias.SetSelected(3, false);
                    lbDias.SetSelected(4, false);
                    lbDias.SetSelected(5, true);
                    lbDias.SetSelected(6, true);
                    break;
                case 2:
                    lbDias.SetSelected(0, true);
                    lbDias.SetSelected(1, true);
                    lbDias.SetSelected(2, true);
                    lbDias.SetSelected(3, true);
                    lbDias.SetSelected(4, true);
                    lbDias.SetSelected(5, false);
                    lbDias.SetSelected(6, false);
                    break;
                default:
                    break;
            }
        }

        private void lbDias_Click(object sender, EventArgs e)
        {
            cmbDias.SelectedIndex = cmbDias.Items.Count - 1;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (File.Exists(txtRutaEjecutable.Text))
            {
                GuardarConfiguracion();

                if (ExisteServicio(Properties.Settings.Default.prgNombreServicio))
                {
                    ModificarServicio();
                }
            }
            else
            {
                MessageBox.Show("La ruta del ejecutable no es correcta", "Aviso", MessageBoxButtons.OK
                     , MessageBoxIcon.Information);
                txtRutaEjecutable.Focus();
                txtRutaEjecutable.Select();
            }
        }

        private void pbBuscarEjecutable_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdlg = new OpenFileDialog();
            ofdlg.FileName = txtRutaEjecutable.Text;

            if (ofdlg.ShowDialog() == DialogResult.OK)
                txtRutaEjecutable.Text = ofdlg.FileName;
        }

        private void pbVerPassword_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                txtPassword.UseSystemPasswordChar = false;
        }

        private void pbVerPassword_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                txtPassword.UseSystemPasswordChar = true;
        }

        #region Funciones para controlar el Servicio
        private bool ExisteServicio(string NombreDeServicio)
        {
            bool existe = false;

            try
            {
                foreach (Task t in ts.AllTasks)
                {
                    if (t.Name.ToLower() == NombreDeServicio.ToLower())
                        existe = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return existe;
        }

        private void CrearServicio()
        {
            CrearTareaSemanal();
        }

        private void CrearTareaSemanal()
        {
            try
            {
                if (ExisteServicio(Properties.Settings.Default.prgNombreServicio) == false)
                {
                    if (File.Exists(txtRutaEjecutable.Text))
                    {
                        // Crear una definición de la tarea
                        TaskDefinition td = ts.NewTask();

                        // Poner propiedades a la definición
                        EstablecerOpciones(td);

                        // Registrar la tarea en la carpeta raíz
                        if (Properties.Settings.Default.prgEjecutarSinIniciarSesion)
                        {
                            ts.RootFolder.RegisterTaskDefinition(txtNombreServicio.Text, td,
                                                            TaskCreation.Create,
                                                            txtUsuario.Text,
                                                            txtPassword.Text, TaskLogonType.S4U, null);
                        }
                        else
                        {
                            ts.RootFolder.RegisterTaskDefinition(txtNombreServicio.Text, td);
                        }

                        MessageBox.Show("Servcicio <" + txtNombreServicio.Text + "" +
                            "> creado correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnCrearServicio.Enabled = false;
                        txtNombreServicio.ReadOnly = true;
                    }
                    else
                    {
                        MessageBox.Show("La ruta del ejecutable no es correcta", "Aviso", MessageBoxButtons.OK
                             , MessageBoxIcon.Information);
                        txtRutaEjecutable.Focus();
                        txtRutaEjecutable.Select();
                    }
                }
                else
                {
                    MessageBox.Show("El servicio <" + Properties.Settings.Default.prgNombreServicio + "> ya ha existe\n" +
                        "se anula la operación...", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EstablecerOpciones(TaskDefinition td)
        {
            td.RegistrationInfo.Description = "Copia de seguridad automática de Backup&Restore";
            td.RegistrationInfo.Author = "Backup&Restore";
            td.Principal.UserId = txtUsuario.Text;

            // Ejecutar con los privilegios más altos
            td.Principal.RunLevel = TaskRunLevel.Highest;

            // Detener la tarea si se ejecuta durante más de un día
            td.Settings.ExecutionTimeLimit = new TimeSpan(24, 0, 0);

            // Crear el desencadenador diario
            // DailyTrigger dt = new DailyTrigger();

            // Crear el desencadenador semanal
            WeeklyTrigger wt = new WeeklyTrigger();

            // La fecha y hora que empieza
            DateTime fechaHora = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                 dtpkrHora.Value.Hour, dtpkrHora.Value.Minute, dtpkrHora.Value.Second);
            wt.StartBoundary = fechaHora;

            // Los días para hacer la copia
            string dias = Properties.Settings.Default.prgDias;
            string[] diasCopias = dias.Split(',');
            wt.DaysOfWeek = 0;

            for (int x = 0; x <= diasCopias.Length - 1; x++)
            {
                if (diasCopias[x].ToString() == "0")
                {
                    wt.DaysOfWeek |= DaysOfTheWeek.Monday;
                }
                if (diasCopias[x].ToString() == "1")
                {
                    wt.DaysOfWeek |= DaysOfTheWeek.Tuesday;
                }
                if (diasCopias[x].ToString() == "2")
                {
                    wt.DaysOfWeek |= DaysOfTheWeek.Wednesday;
                }
                if (diasCopias[x].ToString() == "3")
                {
                    wt.DaysOfWeek |= DaysOfTheWeek.Thursday;
                }
                if (diasCopias[x].ToString() == "4")
                {
                    wt.DaysOfWeek |= DaysOfTheWeek.Friday;
                }
                if (diasCopias[x].ToString() == "5")
                {
                    wt.DaysOfWeek |= DaysOfTheWeek.Saturday;
                }
                if (diasCopias[x].ToString() == "6")
                {
                    wt.DaysOfWeek |= DaysOfTheWeek.Sunday;
                }
            }

            // Añadir el desencadenador
            td.Triggers.Add(wt);

            // Crear la acción, el ejecutable y sus parámetros
            string parametros = "/copiar";

            if (Properties.Settings.Default.prgApagarAlFinalizar)
                parametros += " /apagar";

            if (Properties.Settings.Default.prgSegundoPlano)
                parametros += " /ocultar";

            td.Actions.Add(new ExecAction("\"" + Properties.Settings.Default.prgRutaEjecutable + "\"", parametros,
                    Application.StartupPath));
        }

        private void BorrarServicio()
        {
            try
            {
                if (ExisteServicio(Properties.Settings.Default.prgNombreServicio))
                {
                    if (ts.GetTask(Properties.Settings.Default.prgNombreServicio) != null)
                    {
                        if (MessageBox.Show("¿Borrar el servicio <" + txtNombreServicio.Text + ">?", "Aviso",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            // Borrar
                            ts.RootFolder.DeleteTask(Properties.Settings.Default.prgNombreServicio, true);

                            btnCrearServicio.Enabled = true;
                            txtNombreServicio.ReadOnly = false;

                            MessageBox.Show("Servicio <" + txtNombreServicio.Text + "> borrado correctamente",
                                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El servicio <" + txtNombreServicio.Text + "> no existe\n" +
                        "se anula la operación...", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ModificarServicio()
        {
            try
            {
                Task task = ts.GetTask(Properties.Settings.Default.prgNombreServicio);

                if (task != null)
                {
                    TaskDefinition td = task.Definition;
                    td.Triggers.Clear();
                    td.Actions.Clear();
                    EstablecerOpciones(td);

                    // Registrar la tarea en la carpeta raíz
                    if (Properties.Settings.Default.prgEjecutarSinIniciarSesion)
                    {
                        ts.RootFolder.RegisterTaskDefinition(task.Name, td,
                                            TaskCreation.Update,
                                            Properties.Settings.Default.prgUsuario,
                                            Properties.Settings.Default.prgPassword,
                                            TaskLogonType.S4U, null);
                    }
                    else
                    {
                        ts.RootFolder.RegisterTaskDefinition(txtNombreServicio.Text, td,
                                            TaskCreation.Update,
                                            Properties.Settings.Default.prgUsuario,
                                            Properties.Settings.Default.prgPassword,
                                            TaskLogonType.InteractiveToken, null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Usuario o password incorrectos\n" +
                            ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ActivarServicio()
        {
            try
            {
                if (ExisteServicio(txtNombreServicio.Text))
                {
                    Task tarea = ts.GetTask(Properties.Settings.Default.prgNombreServicio);

                    if (tarea != null)
                        if (tarea.Enabled == true)
                            MessageBox.Show("El servicio <" + tarea.Name + "> ya ha sido iniciado", "Aviso"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            tarea.Enabled = true;
                        }
                }
                else
                {
                    MessageBox.Show("El servicio <" + txtNombreServicio.Text + "> no existe\n" +
                        "se anula la operación...", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DesactivarServicio()
        {
            try
            {
                if (ExisteServicio(txtNombreServicio.Text))
                {
                    Task tarea = ts.GetTask(Properties.Settings.Default.prgNombreServicio);

                    if (tarea != null)
                        if (tarea.Enabled == false)
                            MessageBox.Show("El servicio <" + tarea.Name + "> ya ha sido desactivado", "Aviso"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            tarea.Enabled = false;
                        }
                }
                else
                {
                    MessageBox.Show("El servicio <" + txtNombreServicio.Text + "> no existe\n" +
                        "se anula la operación...", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void btnCrearServicio_Click(object sender, EventArgs e)
        {
            CrearTareaSemanal();
        }

        private void btnBorrarServicio_Click(object sender, EventArgs e)
        {
            BorrarServicio();
        }

        private void btnActivarServicio_Click(object sender, EventArgs e)
        {
            ActivarServicio();
        }

        private void btnDesactivarServicio_Click(object sender, EventArgs e)
        {
            DesactivarServicio();
        }

        private void frmProgramador_FormClosing(object sender, FormClosingEventArgs e)
        {
            saliendo = true;
            bw.CancelAsync();
            bw.Dispose();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pnlInfoUsuario.Visible = !pnlInfoUsuario.Visible;
        }

        private void pnlInfoUsuario_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            StringFormat sf = new StringFormat();
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.RotateTransform(-5);
            sf.Alignment = StringAlignment.Center; ;
            sf.LineAlignment = StringAlignment.Center; ;

            Rectangle rec = new Rectangle(0, 0, (int)g.ClipBounds.Width - 20, (int)g.ClipBounds.Height);
            g.DrawString("El usuario ha de ser\n\run usuario de\r\nWindows con una contraseña.", new Font("Tahoma", 9),
                         Brushes.Black, rec, sf);
        }

        private void frmProgramador_Activated(object sender, EventArgs e)
        {
            pnlInfoUsuario.Refresh();
        }

        private void frmProgramador_Deactivate(object sender, EventArgs e)
        {
            pnlInfoUsuario.Refresh();
        }

        private void frmProgramador_LocationChanged(object sender, EventArgs e)
        {
            pnlInfoUsuario.Refresh();
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pnlInfoUsuario.Visible = false;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pnlInfoUsuario.Visible = true;
        }

        private void txtNombreServicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtNombreServicio.ReadOnly)
                MessageBox.Show("El servicio ya ha sido creado, para poder dar otro nombre\n" +
                        "tiene que borrar y crearlo de nuevo con el nuevo nombre", "Aviso",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void chkInforme_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnviarInforme.Checked == false)
            {
                txtDestinatario.Enabled = false;
                txtServSMTP.Enabled = false;
                txtUsuarioSMTP.Enabled = false;
                txtPasswordSMTP.Enabled = false;
                nudPuertoSMTP.Enabled = false;
                chkConexiónSSL.Enabled = false;
                pbVerPasswordSMTP.Enabled = false;
                pbVerPasswordSMTP.BackColor = Color.WhiteSmoke;
            }
            else
            {
                txtDestinatario.Enabled = true;
                txtServSMTP.Enabled = true;
                txtUsuarioSMTP.Enabled = true;
                txtPasswordSMTP.Enabled = true;
                nudPuertoSMTP.Enabled = true;
                chkConexiónSSL.Enabled = true;
                pbVerPasswordSMTP.Enabled = true;
                pbVerPasswordSMTP.BackColor = Color.White;
            }



        }

        private void btnProbar_Click(object sender, EventArgs e)
        {
            pnlInforme.Visible = true;
            Application.DoEvents();

            if (Emails.Probar(txtDestinatario.Text, txtServSMTP.Text, (int)nudPuertoSMTP.Value,
                              txtUsuarioSMTP.Text, txtPasswordSMTP.Text, chkConexiónSSL.Checked) == true)
                MessageBox.Show("Mensaje enviado sin errores", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Mensaje enviado con errores\nRevise la configuración y pruebe de nuevo",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

            pnlInforme.Visible = false;
        }

        private void pbVerPasswordSMTP_MouseDown(object sender, MouseEventArgs e)
        {
            txtPasswordSMTP.UseSystemPasswordChar = false;
        }

        private void pbVerPasswordSMTP_MouseUp(object sender, MouseEventArgs e)
        {
            txtPasswordSMTP.UseSystemPasswordChar = true;
        }

        private void frmProgramador_Load(object sender, EventArgs e)
        {
            pbVerPassword.Size = new Size(pbVerPassword.Size.Width, txtPassword.Size.Height);
            pbVerPasswordSMTP.Size = new Size(pbVerPasswordSMTP.Size.Width, txtPasswordSMTP.Size.Height);
            chkConexiónSSL.Left = label14.Left - 7;
            chkConexiónSSL.Top = label15.Top + 3;
        }

        private void frmProgramador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCerrar_Click(sender, e);
        }

        private void txts_Enter(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.SelectAll();
        }

        private void txts_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.SelectAll();
        }
    }
}
