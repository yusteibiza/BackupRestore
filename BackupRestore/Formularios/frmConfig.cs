using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace BackupRestore
{
    public partial class frmConfig : Form
    {
        int archivos = 0, directorios = 0;
        ulong tamaño;
        OleDbConnection con;
        OleDbCommand com;
        frmCalculando frmc;
        EventosApp epp;
        string strcon;

        public frmConfig()
        {
            InitializeComponent();
        }

        private void FuentePulsado(Control ControlParaCambiar)
        {
            if (ControlParaCambiar != lblGuardar && ControlParaCambiar != lblDescartar)
            {
                ControlParaCambiar.ForeColor = Color.Khaki;
            }
            else
            {
                ControlParaCambiar.ForeColor = Color.DarkGray;
            }
            ControlParaCambiar.Font = new Font(ControlParaCambiar.Font.Name, 12, FontStyle.Bold | FontStyle.Underline);
        }

        private void FuenteNoPulsado(Control ControlParaCambiar)
        {
            if (ControlParaCambiar != lblGuardar && ControlParaCambiar != lblDescartar)
            {
                ControlParaCambiar.ForeColor = Color.White;
            }
            else
            {
                ControlParaCambiar.ForeColor = Color.RoyalBlue;
            }
            ControlParaCambiar.Font = new Font(ControlParaCambiar.Font.Name, 10, FontStyle.Bold);
        }

        private void FuenteMover(Control ControlParaCambiar)
        {
            ControlParaCambiar.Font = new Font(ControlParaCambiar.Font.Name, ControlParaCambiar.Font.Size, FontStyle.Bold | FontStyle.Underline);
        }

        private void FuenteSalir(Control ControlParaCambiar)
        {
            ControlParaCambiar.Font = new Font(ControlParaCambiar.Font.Name, ControlParaCambiar.Font.Size, FontStyle.Bold);
        }

        private void frmConfig_Resize(object sender, EventArgs e)
        {
            try
            {
                dgvDatos.Columns[0].Width = this.Width + (this.Width - dgvDatos.Width - 327);
                lblInfoEjecutar.Location = new Point((kryptonPanel4.Width - lblInfoEjecutar.Width) / 2, lblInfoEjecutar.Top);
                btnCalcularTam.Location = new Point((gbDatos.Width - btnCalcularTam.Width) / 2, btnCalcularTam.Top);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblAnadirArchivo_MouseUp(object sender, MouseEventArgs e)
        {
            FuenteNoPulsado(lblAnadirArchivo);
        }

        private void lblAnadirArchivo_MouseDown(object sender, MouseEventArgs e)
        {
            FuentePulsado(lblAnadirArchivo);
        }

        private void lblAnadirCarpeta_MouseDown(object sender, MouseEventArgs e)
        {
            FuentePulsado(lblAnadirCarpeta);
        }

        private void lblAnadirCarpeta_MouseUp(object sender, MouseEventArgs e)
        {
            FuenteNoPulsado(lblAnadirCarpeta);
        }

        private void lblBorrarSel_MouseDown(object sender, MouseEventArgs e)
        {
            FuentePulsado(lblBorrarSel);
        }

        private void lblBorrarSel_MouseUp(object sender, MouseEventArgs e)
        {
            FuenteNoPulsado(lblBorrarSel);
        }

        private void lblGuardar_MouseDown(object sender, MouseEventArgs e)
        {
            FuentePulsado(lblGuardar);
        }

        private void lblGuardar_MouseUp(object sender, MouseEventArgs e)
        {
            FuenteNoPulsado(lblGuardar);
        }

        private void lblDescartar_MouseDown(object sender, MouseEventArgs e)
        {
            FuentePulsado(lblDescartar);
        }

        private void lblDescartar_MouseUp(object sender, MouseEventArgs e)
        {
            FuenteNoPulsado(lblDescartar);
        }

        private void chkComprimir_MouseDown(object sender, MouseEventArgs e)
        {
            chkComprimir.ForeColor = Color.Khaki;
        }

        private void chkComprimir_MouseUp(object sender, MouseEventArgs e)
        {
            chkComprimir.ForeColor = Color.White;
        }

        private void btnDest1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.Description = "Elija la unidad o carpeta de destino para la copia...";
            dlg.SelectedPath = txtDest1.Text;
            if (dlg.ShowDialog() == DialogResult.OK)
                txtDest1.Text = dlg.SelectedPath;
        }

        private void btnDest2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.Description = "Elija la unidad o carpeta de destino para la copia...";
            dlg.SelectedPath = txtDest2.Text;
            if (dlg.ShowDialog() == DialogResult.OK)
                txtDest2.Text = dlg.SelectedPath;
        }

        private void lblAnadirArchivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = true;
            dlg.Filter = "Todos los archivos (*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string[] archivos = dlg.FileNames;
                object[] valores = new object[3];

                foreach (string archivo in archivos)
                {
                    valores[0] = archivo;
                    valores[1] = false;
                    valores[2] = false;

                    if (dgvDatos.Rows.Count >= 1)
                    {
                        bool existe = false;

                        foreach (DataGridViewRow dgr in dgvDatos.Rows)
                        {
                            if (dgr.Cells[0].Value.ToString() == archivo)
                            {
                                existe = true;
                                break;
                            }
                        }
                        if (!existe)
                        {
                            dgvDatos.Rows.Add(valores);
                            dgvDatos.Rows[0].Selected = true;
                        }
                    }
                    else
                    {
                        dgvDatos.Rows.Add(valores);
                    }
                }
            }
        }

        private void lblAnadirCarpeta_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dgvDatos.Rows.Count > 0)
                dlg.SelectedPath = dgvDatos.CurrentRow.Cells[0].Value.ToString();
            dlg.Description = "Elija la carpeta para añadir a la copia";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                object[] valores = new object[3];
                bool existe = false;

                if (dgvDatos.Rows.Count >= 1)
                {
                    foreach (DataGridViewRow dgr in dgvDatos.Rows)
                    {
                        valores[0] = dlg.SelectedPath;
                        valores[1] = dgr.Cells[1].Value;
                        valores[2] = dgr.Cells[2].Value;

                        if (dgr.Cells[0].Value.ToString() == valores[0].ToString())
                        {
                            existe = true;
                            break;
                        }

                    }
                    if (!existe)
                    {
                        AñadirFilas(dlg.SelectedPath);
                    }
                }
                else
                {
                    AñadirFilas(dlg.SelectedPath);
                }
            }
        }

        private void AñadirFilas(string Path)
        {
            object[] datos = new object[3];
            datos[0] = Path;
            datos[1] = true;
            datos[2] = false;
            dgvDatos.Rows.Add(datos);
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            lblLibre1.Text = "";
            lblLibre2.Text = "";
            txtDest1.Text = "-";
            txtDest2.Text = "-";
            txtDest1.Text = "";
            txtDest2.Text = "";
            dgvDatos.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDatos.Columns[0].Width = this.Width + (this.Width - dgvDatos.Width - 327);
            dgvDatos.Columns[0].ReadOnly = false;
            dgvDatos.Columns[1].ReadOnly = true;
            dgvDatos.Columns[2].ReadOnly = false;
            dgvDatos.AllowUserToResizeColumns = false;
            dgvDatos.RowHeadersVisible = false;
            kryptonPanel4.Width -= 10;
            lblInfoEjecutar.Left = ((kryptonPanel4.Width - lblInfoEjecutar.Width) / 2) - 2;
            kryptonPanel4.Width = dgvDatos.Width;
            txtDest1.Left -= 12;
            txtDest2.Left = txtDest1.Left;
            txtDest1.Width += 12;
            txtDest2.Width = txtDest1.Width;
            lblDest2.Left += 2;
            lblUA.Location = new Point(98, 40);
            lblFechCrea.Location = new Point(77, 25);
            lblTam.Location = new Point(129, 8);
            epp = new EventosApp();
            string dbase = Application.StartupPath + "\\Datos.mdb";
            strcon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbase + ";User Id=admin;Password=;";
            con = new OleDbConnection(strcon);
            btnCalcularTam.Location = new Point(dgvDatos.Location.X, dgvDatos.Location.Y + dgvDatos.Height+  10);

            try
            {
                con.Open();
                com = new OleDbCommand("SELECT * FROM logs;", con);
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (dgvDatos.Rows.Count != 0)
            {
                btnCalcularTam.Enabled = true;
            }
            else
            {
                btnCalcularTam.Enabled = false;
            }

            foreach (DataGridViewColumn dc in dgvDatos.Columns)
            {
                dc.HeaderCell.Style.Font = new Font("Verdana", 9, FontStyle.Bold);
            }

            try
            {
                Configuracion.LeerConfig leer = new Configuracion.LeerConfig();
                leer.CadenaConexión = strcon;
                leer.Leer();
                chkComprimir.Checked = leer.Comprimir;
                nudCiclos.Value = (int)leer.Ciclos;
                txtDest1.Text = leer.Destino1;
                txtDest2.Text = leer.Destino2;
                foreach (DataRow drow in leer.TablaDeDatos.Rows)
                {
                    dgvDatos.Rows.Add(drow.ItemArray);
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Comprobar los destinos de copia
            try
            {
                DirectoryInfo dir = new DirectoryInfo(txtDest1.Text);
                if (dir.Exists)
                {
                    DriveInfo drvi = new DriveInfo(dir.Root.Name);
                    lblLibre1.Text = "Espacio libre en: " + dir.Root.Name.ToUpper() + " (" + drvi.AvailableFreeSpace.ToString("N") + ")";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                if (txtDest1.Text.StartsWith("\\"))
                    lblLibre1.Text = "El destino no existe o es una ruta UNC...";
                else
                    lblLibre1.Text = "El destino no existe...";
            }

            try
            {
                DirectoryInfo dir = new DirectoryInfo(txtDest2.Text);
                if (dir.Exists)
                {
                    DriveInfo drvi = new DriveInfo(dir.Root.Name);
                    lblLibre2.Text = "Espacio libre en: " + dir.Root.Name.ToUpper() + " (" + drvi.AvailableFreeSpace.ToString("N") + ")";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                if (txtDest2.Text.StartsWith("\\"))
                    lblLibre2.Text = "El destino no existe o es una ruta UNC...";
                else
                    lblLibre2.Text = "El destino no existe...";
            }

            //Arreglar despliegue ventana de datos
            this.Size = new Size(this.Size.Width, this.Size.Height + 8);
        }

        private void lblBorrarSel_Click(object sender, EventArgs e)
        {
            dgvDatos.Select();
            SendKeys.Send("{del}");
        }

        private void lblDescartar_Click(object sender, EventArgs e)
        {
            epp.PonerEvento("No han habido cambios en la configuración.");
            this.Close();
        }

        private void lblGuardar_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtDest1.Text))
            {
                try
                {
                    epp.PonerEvento("Se ha guardado la nueva configuración.");

                    DataTable dt = new DataTable("Datos");
                    dt.Columns.Add("Path", Type.GetType("System.String"));
                    dt.Columns.Add("Directorio", Type.GetType("System.Boolean"));
                    dt.Columns.Add("Recursivo", Type.GetType("System.Boolean"));

                    if (dgvDatos.Rows.Count != 0)
                    {
                        foreach (DataGridViewRow drow in dgvDatos.Rows)
                        {
                            object[] dr = new object[3];
                            dr[0] = drow.Cells[0].Value.ToString();
                            dr[1] = drow.Cells[1].Value;
                            dr[2] = drow.Cells[2].Value;
                            dt.Rows.Add(dr);
                        }
                    }
                    Configuracion.GuardarConfig gc = new Configuracion.GuardarConfig(strcon, dt, this);
                    gc.Ciclos = (int)nudCiclos.Value;
                    gc.Comprimir = chkComprimir.Checked;
                    gc.Destino1 = txtDest1.Text;
                    gc.Destino2 = txtDest2.Text;
                    gc.Guardar();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                txtDest1.Text = "Debe de seleccionar una ruta válida...";
                txtDest1.Select();
                txtDest1.SelectAll();
            }
        }

        private void dgvDatos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                FileInfo fi = new FileInfo(dgvDatos.Rows[e.RowIndex].Cells[0].Value.ToString());

                float tam = fi.Length / 1000;
                if (tam != 0)
                {
                    lblTamaño.Text = tam.ToString("#,#.##") + " KB";
                }
                else
                {
                    lblTamaño.Text = "0 KB";
                }

                lblCreacion.Text = fi.CreationTime.ToLongDateString() + ", " + fi.CreationTime.ToShortTimeString();
                lblUAcceso.Text = fi.LastAccessTime.ToLongDateString() + ", " + fi.LastAccessTime.ToShortTimeString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                try
                {
                    DirectoryInfo di = new DirectoryInfo(dgvDatos.Rows[e.RowIndex].Cells[0].Value.ToString());
                    lblTamaño.Text = "??? - \"Directorio\"";
                    lblCreacion.Text = di.CreationTime.ToLongDateString() + ", " + di.CreationTime.ToShortTimeString();
                    lblUAcceso.Text = di.LastAccessTime.ToLongDateString() + ", " + di.LastAccessTime.ToShortTimeString();
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtDest1_Enter(object sender, EventArgs e)
        {
            txtDest1.SelectAll();
        }

        private void txtDest2_Enter(object sender, EventArgs e)
        {
            txtDest2.SelectAll();
        }

        private void txtDest1_MouseDown(object sender, MouseEventArgs e)
        {
            //txtDest1.SelectAll();
        }

        private void txtDest2_MouseDown(object sender, MouseEventArgs e)
        {
            //txtDest2.SelectAll();
        }

        private void frmConfig_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A & e.Modifiers == Keys.Alt)
                lblAnadirArchivo_Click(sender, new EventArgs());

            if (e.Modifiers == Keys.Alt & e.KeyCode == Keys.C)
                lblAnadirCarpeta_Click(sender, new EventArgs());

            if (e.Modifiers == Keys.Alt & e.KeyCode == Keys.B)
                lblBorrarSel_Click(sender, new EventArgs());

            if (e.Modifiers == Keys.Alt & e.KeyCode == Keys.P)
                chkComprimir.Checked = !chkComprimir.Checked;

            if (e.Modifiers == Keys.Alt & e.KeyCode == Keys.I)
                nudCiclos.Select();

            if (e.Modifiers == Keys.Alt & e.KeyCode == Keys.G)
                lblGuardar_Click(sender, new EventArgs());

            if (e.Modifiers == Keys.Alt & e.KeyCode == Keys.D)
                lblDescartar_Click(sender, new EventArgs());

            if (e.KeyCode == Keys.Escape)
                lblDescartar_Click(sender, e);
        }

        private void dgvDatos_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Modifiers == Keys.Control & e.KeyCode == Keys.Enter)
                    Process.Start(dgvDatos.CurrentRow.Cells[0].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MensajeErrorCalcular()
        {
            MessageBox.Show("La configuración de directorios y archivos es incorrecta.\n" +
                            "Revise que las rutas de los archivos y directorios se correcta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeCalcular()
        {
            tamaño /= 1024;
            MessageBox.Show("* Resumen del tamaño de los archivos añadidos...\t\n\n\t- Directorios: " + directorios.ToString("#,#") +
                             "\n\t- Archivos ..: " + archivos.ToString("#,#") + "\n\n\t- Tamaño ...: " + tamaño.ToString("N") + " KB"
                             , "Información de la copia", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCalcularTam_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                c.Enabled = false;
            }

            archivos = 0;
            directorios = 0;
            tamaño = 0;
            int errores = 0;
            frmc = new frmCalculando();
            frmc.StartPosition = FormStartPosition.CenterScreen;
            frmc.Show(this);
            Application.DoEvents();

            foreach (DataGridViewRow dr in dgvDatos.Rows)
            {
                if (frmc.Cancelar == false)
                {
                    if ((bool)dr.Cells[1].Value == true && (bool)dr.Cells[2].Value == true)
                    {
                        if (ReCalcularEnDirectorios(dr.Cells[0].Value.ToString()) == false)
                        { errores++; break; }
                    }
                    if ((bool)dr.Cells[1].Value == true && (bool)dr.Cells[2].Value == false)
                    {
                        if (CalcularDirectorios(dr.Cells[0].Value.ToString()) == false)
                        { errores++; break; }

                    }
                    if ((bool)dr.Cells[1].Value == false && (bool)dr.Cells[2].Value == false ||
                        (bool)dr.Cells[1].Value == false && (bool)dr.Cells[2].Value == true)
                    {
                        if (Calcular(dr.Cells[0].Value.ToString()) == false)
                        { errores++; break; }
                    }
                }
                else
                {
                    break;
                }
            }

            frmc.Close();

            if (!frmc.Cancelar) { if (errores == 0) { MensajeCalcular(); } else { MensajeErrorCalcular(); } }

            foreach (Control c in this.Controls)
            {
                c.Enabled = true;
            }
        }

        private bool Calcular(string Path)
        {
            try
            {
                if (File.Exists(Path))
                {
                    FileInfo fi = new FileInfo(Path);
                    tamaño += (ulong)fi.Length;
                    archivos++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (FieldAccessException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private bool CalcularDirectorios(string Path)
        {
            try
            {
                if (Directory.Exists(Path))
                {
                    DirectoryInfo di = new DirectoryInfo(Path);

                    foreach (FileInfo fi in di.GetFiles())
                    {
                        if (frmc.Cancelar == false)
                        {
                            try
                            {
                                tamaño += (ulong)fi.Length;
                                archivos++;
                                Application.DoEvents();
                            }
                            catch (FieldAccessException ex)
                            {
                                Console.WriteLine(ex.Message);
                                return false;
                            }
                        }
                    }
                    directorios++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private bool ReCalcularEnDirectorios(string Path)
        {
            try
            {
                if (Directory.Exists(Path))
                {
                    DirectoryInfo di = new DirectoryInfo(Path);
                    directorios++;
                    archivos += di.GetFiles().Length;
                    foreach (FileInfo fi in di.GetFiles())
                    {
                        if (frmc.Cancelar == false)
                        {
                            try
                            {
                                tamaño += (ulong)fi.Length;
                                Application.DoEvents();
                            }
                            catch (FieldAccessException ex)
                            {
                                Console.WriteLine(ex.Message);
                                return false;
                            }
                        }
                    }
                    foreach (DirectoryInfo dirinfo in di.GetDirectories())
                    {
                        if (frmc.Cancelar == false)
                        {
                            try
                            {
                                ReCalcularEnDirectorios(dirinfo.FullName);
                                Application.DoEvents();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                return false;
                            }
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private void dgvDatos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btnCalcularTam.Enabled = true;
        }

        private void dgvDatos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgvDatos.Rows.Count == 0)
            {
                btnCalcularTam.Enabled = false;
            }
        }

        private void txtDest1_Validating(object sender, CancelEventArgs e)
        {
          
        }

        private void frmConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (con != null)
                if (con.State == ConnectionState.Open)
                    con.Close();
        }

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Process.Start(dgvDatos.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDatos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(dgvDatos.Rows[e.RowIndex].Cells[2].Value.ToString());
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
                dgvDatos.EndEdit();
        }

        private void lblAnadirArchivo_MouseMove(object sender, MouseEventArgs e)
        {
            FuenteMover(lblAnadirArchivo);
        }

        private void lblAnadirArchivo_MouseLeave(object sender, EventArgs e)
        {
            FuenteSalir(lblAnadirArchivo);
        }

        private void lblAnadirCarpeta_MouseMove(object sender, MouseEventArgs e)
        {
            FuenteMover(lblAnadirCarpeta);
        }

        private void lblAnadirCarpeta_MouseLeave(object sender, EventArgs e)
        {
            FuenteSalir(lblAnadirCarpeta);
        }

        private void lblBorrarSel_MouseMove(object sender, MouseEventArgs e)
        {
            FuenteMover(lblBorrarSel);
        }

        private void lblBorrarSel_MouseLeave(object sender, EventArgs e)
        {
            FuenteSalir(lblBorrarSel);
        }

        private void chkComprimir_MouseMove(object sender, MouseEventArgs e)
        {
            FuenteMover(chkComprimir);
        }

        private void chkComprimir_MouseLeave(object sender, EventArgs e)
        {
            FuenteSalir(chkComprimir);
        }

        private void lblCiclos_MouseMove(object sender, MouseEventArgs e)
        {
            FuenteMover(lblCiclos);
        }

        private void lblCiclos_MouseLeave(object sender, EventArgs e)
        {
            FuenteSalir(lblCiclos);
        }

        private void lblGuardar_MouseMove(object sender, MouseEventArgs e)
        {
            FuenteMover(lblGuardar);
        }

        private void lblGuardar_MouseLeave(object sender, EventArgs e)
        {
            FuenteSalir(lblGuardar);
        }

        private void lblDescartar_MouseMove(object sender, MouseEventArgs e)
        {
            FuenteMover(lblDescartar);
        }

        private void lblDescartar_MouseLeave(object sender, EventArgs e)
        {
            FuenteSalir(lblDescartar);
        }

        private void btnDispDest1_Click(object sender, EventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDest1_TextChanged(object sender, EventArgs e)
        {
            if (txtDest1.TextLength != 0)
            {
                try
                {
                    DirectoryInfo dir = new DirectoryInfo(txtDest1.Text);
                    if (dir.Exists)
                    {
                        DriveInfo drvi = new DriveInfo(dir.Root.Name);
                        lblLibre1.Text = "Espacio libre en: " + dir.Root.Name.ToUpper() + " (" + drvi.AvailableFreeSpace.ToString("N") + ")";
                    }
                    else
                    {
                        if (txtDest1.Text.StartsWith("\\"))
                            lblLibre1.Text = "El destino no existe o es una ruta UNC...";
                        else
                            lblLibre1.Text = "El destino no existe...";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                lblLibre1.Text = "El destino no existe...";
            }
        }

        private void kbtnServicioTareas_Click(object sender, EventArgs e)
        {
            frmProgramador frmpgr = new frmProgramador();
            btnOculto.Select();
            frmpgr.ShowDialog();
        }

        private void txtDest2_TextChanged(object sender, EventArgs e)
        {
            if (txtDest2.TextLength != 0)
            {
                try
                {
                    DirectoryInfo dir = new DirectoryInfo(txtDest2.Text);
                    if (dir.Exists)
                    {
                        DriveInfo drvi = new DriveInfo(dir.Root.Name);
                        lblLibre2.Text = "Espacio libre en: " + dir.Root.Name.ToUpper() + " (" + drvi.AvailableFreeSpace.ToString("N") + ")";
                    }
                    else
                    {
                        if (txtDest2.Text.StartsWith("\\"))
                            lblLibre2.Text = "El destino no existe o es una ruta UNC...";
                        else
                            lblLibre2.Text = "El destino no existe...";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                lblLibre2.Text = "El destino no existe...";
            }
        }
    }
}