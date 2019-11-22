using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Drawing.Drawing2D;

namespace BackupRestore
{
    public partial class frmRestaurar : Form
    {
        OleDbConnection con = null;
        OleDbCommand cmd = null;
        string _origen1, _origen2;
        int _ciclos, _ultimociclo;
        bool _comprimir = false;
        bool pulsadoParar = false;
        bool pulsadoPausar = false;
        frmInfoRestNoComp frmrnc;
        long tamaño;
        int errores;
        ArrayList aerrores;
        frmCalculando frmcalc;
        EventosApp epp;
        bool acabado = false;

        public frmRestaurar()
        {
            InitializeComponent();
        }

        private void frmRestaurar_Load(object sender, EventArgs e)
        {
            foreach (Control c in gbRestaurar.Controls)
            {
                c.Font = new Font("Verdana", 10);
            }

            aerrores = new ArrayList();
            pbInfo.Left = chkRutasOrig.Left + chkRutasOrig.Width + 20;
            pbInfo.Top = chkRutasOrig.Top - 5;
            chkRutasOrig.Left += 4;
            pbInfo.Left -= 14;
            pbInfo.Top += 2;
            Conectar();
            CargarDatos();
            LeerCopias();
            pulsadoParar = false;
            pulsadoPausar = false;
            epp = new EventosApp();
        }

        private void Conectar()
        {
            string dbase = Application.StartupPath + "\\Datos.mdb";
            string strcon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbase + ";User Id=admin;Password=;";
            try
            {
                // Se crea la conexión
                if (con != null)
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                }
                else
                {
                    con = new OleDbConnection(strcon);
                    con.Open();
                }

                cmd = new OleDbCommand("", con);
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Desconectar()
        {
            if (con != null)
                if (con.State == ConnectionState.Open)
                    con.Close();
        }

        private void CargarDatos()
        {
            try
            {
                OleDbDataReader dr;
                cmd.CommandText = "SELECT * FROM destinos;";
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    _origen1 = dr.GetString(1);
                    _origen2 = dr.GetString(2);
                }
                dr.Close();

                cmd.CommandText = "SELECT * FROM opciones;";
                dr = cmd.ExecuteReader();

                // Se puebla la variable mCiclos para saber cuantos ciclos
                while (dr.Read())
                {
                    _comprimir = dr.GetBoolean(1);
                    _ciclos = dr.GetInt32(2);
                }
                dr.Close();

                // Se lee el último Destino de copia:
                cmd.CommandText = "SELECT * FROM ciclocopias;";
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    _ultimociclo = dr.GetInt32(0);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LeerCopias()
        {
            string ruta;

            if (Directory.Exists(_origen1))
            {
                for (int x = 1; x <= _ciclos; x++)
                {
                    ruta = _origen1 + "\\Ciclo" + x.ToString();
                    if (Directory.Exists(ruta))
                    {
                        DirectoryInfo dir = new DirectoryInfo(ruta);
                        TreeNode nodoDirComp = new TreeNode(dir.Name, 3, 3);
                        tvCopias.Nodes[0].Nodes["nodoComprimir"].Nodes.Add(nodoDirComp);
                        TreeNode nodoDirNoComp = new TreeNode(dir.Name, 3, 3);
                        nodoDirNoComp.Tag = dir.FullName;

                        if (dir.GetDirectories().Length != 0)
                        {
                            tvCopias.Nodes[0].Nodes["nodoSinComprimir"].Nodes.Add(nodoDirNoComp);
                        }

                        foreach (FileInfo fi in dir.GetFiles())
                        {
                            // Para considerar el archivo de copia tiene que empezar por "BR-Copia"
                            if (fi.Name.Contains("BR-Copia"))
                            {
                                TreeNode nodoFile = new TreeNode(fi.Name, 4, 4);
                                nodoFile.Tag = fi.FullName;
                                nodoDirComp.Nodes.Add(nodoFile);
                            }
                            Application.DoEvents();
                        }
                    }
                }
            }
            else
            {
            }

            tvCopias.Nodes[0].Expand();
        }

        private void tvCopias_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null && e.Node.Tag.ToString().ToLower() != "comprimidas" &&
                e.Node.Tag != null && e.Node.Tag.ToString().ToLower() != "sincomprimir")
            {
                btnRestaurarTodo.Enabled = true;
                btnRestIndividual.Enabled = true;
            }
            else
            {
                btnRestIndividual.Enabled = false;
                btnRestaurarTodo.Enabled = false;
            }

            if (e.Node.Name != "nodoSinComprimir" && e.Node.Name != "nodoComprimir")
            {
                if (e.Node.Tag != null && e.Node.Parent.Name != "nodoSinComprimir")
                {
                    FileInfo fi = new FileInfo(e.Node.Tag.ToString());
                    double tam = fi.Length / 1024;
                    lblPath.Text = fi.FullName;
                    lblFecha.Text = fi.LastWriteTime.ToLongDateString();
                    lblHora.Text = fi.LastWriteTime.ToLongTimeString();
                    lblTamaño.Text = tam.ToString("n") + " KB";
                }
                else if (e.Node.Tag != null && e.Node.Name != "nodoComprimir")
                {
                    DirectoryInfo di = new DirectoryInfo(e.Node.Tag.ToString());
                    double tam = di.GetFiles().Length / 1024;
                    lblPath.Text = di.FullName;
                    lblFecha.Text = di.LastWriteTime.ToLongDateString();
                    lblHora.Text = di.LastWriteTime.ToLongTimeString();
                    lblTamaño.Text = "Directorio";
                }
                else
                {
                    lblFecha.Text = "";
                    lblTamaño.Text = "";
                    lblHora.Text = "";
                    lblPath.Text = "";
                }
            }
            else
            {
                lblFecha.Text = "";
                lblTamaño.Text = "";
                lblHora.Text = "";
                lblPath.Text = "";
            }
        }

        private void tvCopias_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                if (e.Node.Name != "nodoSinComprimir" && e.Node.Name != "nodoComprimir" && e.Node.Name != "nodoRaiz" &&
                        e.Node.Parent.Text != "Sin Comprimir" & e.Node.Parent.Text != "Comprimidas")
                {
                    btnRestIndividual.Enabled = true;
                    btnRestaurarTodo.Enabled = true;
                }
                else
                {
                    btnRestIndividual.Enabled = false;
                    btnRestaurarTodo.Enabled = false;
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRestaurar_Resize(object sender, EventArgs e)
        {
            Application.DoEvents();
        }

        private void btnDestino_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
                txtDestino.Text = dlg.SelectedPath;

        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            errores = 0;
            aerrores.Clear();
            acabado = false;

            if (tvCopias.SelectedNode.Name != "nodoSinComprimir" && tvCopias.SelectedNode.Name != "nodoComprimir" &&
                                        tvCopias.SelectedNode.Name != "nodoRaiz" && tvCopias.SelectedNode.Tag != null)
            {
                if (chkRutasOrig.Checked == false)
                {
                    if (!Directory.Exists(txtDestino.Text))
                    {
                        MessageBox.Show("El destino para restaurar no existe.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDestino.SelectAll();
                        txtDestino.Select();
                        return;
                    }
                }

                this.Visible = false;

                if (tvCopias.SelectedNode.Tag != null && tvCopias.SelectedNode.Parent.Name != "nodoSinComprimir")
                {
                    epp.PonerEvento("Se ha iniciado la restauración de copias comprimidas -> " + tvCopias.SelectedNode.Tag.ToString());
                    RestaurarComprimidas(tvCopias.SelectedNode.Tag.ToString());
                }
                else if (tvCopias.SelectedNode.Tag != null && tvCopias.SelectedNode.Parent.Name != "nodoComprimir")
                {
                    tamaño = 0;
                    epp.PonerEvento("Se ha iniciado la restauración de copias sin comprimir -> " + tvCopias.SelectedNode.Tag.ToString());
                    RestaurarNoComprimidas(tvCopias.SelectedNode.Tag.ToString());
                }

                this.Visible = true;
                this.Enabled = true;
                this.BringToFront();
                pulsadoParar = true;
                pulsadoPausar = true;

                if (errores > 0)
                {
                    if (MessageBox.Show("El proceso de restauración a generado errores.\n\t¿Ver lista de errores?", "Aviso",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        frmErroresRest frmer = new frmErroresRest(aerrores, "[ Listado de errores producidos durante el proceso de restauración ]...");
                        frmer.ShowDialog();
                    }
                    epp.PonerEvento("Error: El proceso de restauración de copias a finalizado con errores.");
                }
                else
                {
                    if (acabado)
                    {
                        MessageBox.Show("Restauración de copias finalizada correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        epp.PonerEvento("El proceso de restauración de copias ha finalizado correctamente.");
                    }
                }
            }
        }

        private void btnRestIndividual_Click(object sender, EventArgs e)
        {
            if (tvCopias.SelectedNode.Name != "nodoSinComprimir" && tvCopias.SelectedNode.Name != "nodoComprimir" &&
                                       tvCopias.SelectedNode.Name != "nodoRaiz" && tvCopias.SelectedNode.Tag != null)
            {
                if (chkRutasOrig.Checked == false)
                {
                    if (!Directory.Exists(txtDestino.Text))
                    {
                        MessageBox.Show("El destino para restaurar no existe.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDestino.SelectAll();
                        txtDestino.Select();
                        return;
                    }
                }

                while (this.Opacity != 0)
                {
                    this.Opacity -= 0.05;
                    System.Threading.Thread.Sleep(5);
                }

                this.Visible = false;

                //epp.PonerEvento("Se ha iniciado la restauración de copias comprimidas -> " + tvCopias.SelectedNode.Tag.ToString());
                frmRestIndiComp frmrestcomp = new frmRestIndiComp(tvCopias.SelectedNode.Tag.ToString(), txtDestino.Text, chkRutasOrig.Checked);
                frmrestcomp.ShowDialog();

                this.Visible = true;

                while (this.Opacity != 1)
                {
                    this.Opacity += 0.05;
                    System.Threading.Thread.Sleep(5);
                }

                this.Enabled = true;
                this.BringToFront();
                pulsadoParar = true;
                pulsadoPausar = true;
                frmrestcomp.Close();
            }
        }
        #region Función para restaurar copias comprimidas

        private void RestaurarComprimidas(string Path_Origen)
        {
            if (chkRutasOrig.Checked)
            {
                if (MessageBox.Show("Ha decidido restaurar la copia en sus lugares originales.\nSi en las rutas de destino existe otro archivo con el\n" +
                                                "mismo nombre, éste será reemplazado por el de la copia.\n\n\t¿Continuar con la restauración?"
                                                , "¡¡¡Cuidado!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    acabado = false;
                    return;
                }
            }

            acabado = true;
            this.Enabled = false;
            pulsadoPausar = false;
            pulsadoParar = false;

            //Se pone la constante del objeto zip a la página de códigos actual para el tema de acentos y demás
            ICSharpCode.SharpZipLib.Zip.ZipConstants.DefaultCodePage = System.Globalization.CultureInfo.CurrentCulture.TextInfo.OEMCodePage;

            ICSharpCode.SharpZipLib.Zip.ZipInputStream zip = new ICSharpCode.SharpZipLib.Zip.ZipInputStream(File.OpenRead(Path_Origen));
            ICSharpCode.SharpZipLib.Zip.ZipEntry entrada = null;

            frmInfoRestComp frmrc = new frmInfoRestComp(entrada, Path_Origen, this);
            frmrc.Show();

            string nombre = string.Empty;
            string unidad = string.Empty;
            FileInfo fi = null;

            while ((entrada = zip.GetNextEntry()) != null)
            {
                if (pulsadoParar == false)
                {
                    while (pulsadoPausar)
                    {
                        Application.DoEvents();
                    }

                    try
                    {
                        if (chkRutasOrig.Checked == false)
                        {
                            if (!Directory.Exists(txtDestino.Text))
                                Directory.CreateDirectory(txtDestino.Text);

                            unidad = entrada.Name.Substring(0, 1);

                            if (unidad != "\\")
                            {
                                nombre = txtDestino.Text + "\\Disco_" + unidad + entrada.Name.Remove(0, 2);
                            }
                            else
                            {
                                nombre = txtDestino.Text + "\\Red\\" + entrada.Name.Remove(0, 2);
                            }

                            fi = new FileInfo(nombre);
                            if (!Directory.Exists(fi.DirectoryName))
                                Directory.CreateDirectory(fi.DirectoryName);
                        }
                        else
                        {
                            nombre = entrada.Name;
                            fi = new FileInfo(nombre);
                            if (!Directory.Exists(fi.DirectoryName))
                                Directory.CreateDirectory(fi.DirectoryName);
                        }

                        FileStream sw = File.Create(nombre);
                        frmrc.PonerDatos(entrada);
                        Application.DoEvents();

                        long tamañoArch = entrada.Size;
                        int datos;
                        byte[] buffer = new byte[64000];
                        while (tamañoArch > 0)
                        {
                            datos = zip.Read(buffer, 0, 64000);
                            sw.Write(buffer, 0, 64000);
                            tamañoArch -= datos;
                        }
                        sw.Close();
                        Application.DoEvents();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Origen .: " + ex.Source + "\n" + ex.Message);
                        errores++;
                        aerrores.Add("Error: " + ex.Message + " -> " + nombre);
                    }
                }
                else
                {
                    break;
                }
            }
            zip.Close();
            frmrc.Dispose();
            frmrc.Close();
        }

        #endregion


        #region Función para restaurar copias sin comprimir

        private long CalcularTamaño(string Path_Inicial)
        {
            frmcalc = new frmCalculando();
            frmcalc.Show();
            frmcalc.BringToFront();
            Application.DoEvents();
            long tamaño = RecursivoCalcularTamaño(Path_Inicial);
            frmcalc.Close();
            return tamaño;
        }

        private long RecursivoCalcularTamaño(string DirectorioInicial)
        {
            if (frmcalc.Cancelar == false)
            {
                DirectoryInfo Dir = new DirectoryInfo(DirectorioInicial);

                foreach (FileInfo fi in Dir.GetFiles())
                {
                    try
                    {
                        if (!fi.Name.Contains("BR-Copia"))
                        {
                            tamaño += fi.Length;
                            Application.DoEvents();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        errores++;
                        aerrores.Add(ex.Message);
                    }
                }

                foreach (DirectoryInfo SubDir in Dir.GetDirectories())
                {
                    RecursivoCalcularTamaño(SubDir.FullName);
                    Application.DoEvents();
                }

                return tamaño;
            }
            else
            {
                return 0;
            }
        }

        private void RestaurarNoComprimidas(string Path_Origen)
        {
            if (chkRutasOrig.Checked)
            {
                if (MessageBox.Show("Ha decidido restaurar la copia en sus lugares originales.\nSi en las rutas de destino existe otro archivo con el\n" +
                                                "mismo nombre, éste será reemplazado por el de la copia.\n\n\t¿Continuar con la restauración?"
                                                , "¡¡¡Cuidado!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    acabado = false;
                    return;
                }
            }

            acabado = true;
            this.Enabled = false;
            pulsadoPausar = false;
            pulsadoParar = false;

            long tamaño = CalcularTamaño(Path_Origen);

            if (frmcalc.Cancelar == false)
            {
                frmrnc = new frmInfoRestNoComp(null, this, Path_Origen, tamaño);
                frmrnc.Show();

                if (chkRutasOrig.Checked == false)
                {
                    RecursivoNoComp(new DirectoryInfo(Path_Origen), new DirectoryInfo(txtDestino.Text));
                }
                else
                {
                    DirectoryInfo diro = new DirectoryInfo(Path_Origen);

                    foreach (DirectoryInfo DirOrigen in diro.GetDirectories())
                    {
                        try
                        {
                            string ddestino = string.Empty;

                            if (DirOrigen.Name.ToLower() != "red")
                            {
                                int quitar = DirOrigen.FullName.IndexOf("Disco_");
                                ddestino = DirOrigen.FullName.Remove(0, quitar);
                                ddestino = ddestino.Remove(0, 6);
                                ddestino += ":\\";
                                RecursivoNoComp(DirOrigen, new DirectoryInfo(ddestino));
                            }
                            else if (DirOrigen.Name.ToLower() == "red")
                            {
                                foreach (DirectoryInfo equipo in DirOrigen.GetDirectories())
                                {
                                    foreach (DirectoryInfo recurso in equipo.GetDirectories())
                                    {
                                        DirectoryInfo dirorig = new DirectoryInfo(DirOrigen.FullName + "\\" + equipo.Name + "\\" + recurso.Name);
                                        ddestino = @"\\" + equipo.Name + "\\" + recurso.Name;
                                        RecursivoNoComp(dirorig, new DirectoryInfo(ddestino));
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Source +"\n" + ex.Message);
                            errores++;
                            aerrores.Add(ex.Message);
                        }
                    }
                }

                frmrnc.Dispose();
                frmrnc.Close();
            }
        }

        private void RecursivoNoComp(DirectoryInfo DirOrigen, DirectoryInfo DirDestino)
        {
            try
            {
                if (Directory.Exists(DirDestino.FullName) == false)
                {
                    Directory.CreateDirectory(DirDestino.FullName);
                }
                if (pulsadoParar == false)
                {
                    while (pulsadoPausar)
                    {
                        Application.DoEvents();
                    }
                    // Copiar todos los ficheros en el nuevo directorio.
                    foreach (FileInfo fi in DirOrigen.GetFiles())
                    {
                        try
                        {
                            if (!fi.Name.Contains("BR-Copia"))
                            {
                                frmrnc.PonerDatos(fi);
                                File.Copy(fi.FullName, DirDestino.FullName + "\\" + fi.Name, true);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            errores++;
                            aerrores.Add(ex.Message);
                        }
                    }
                    // Copiar todos los subdirectorios usando recursividad.
                    foreach (DirectoryInfo diOrigenSubDir in DirOrigen.GetDirectories())
                    {
                        DirectoryInfo siguienteSubdirectorio = DirDestino.CreateSubdirectory(diOrigenSubDir.Name);
                        RecursivoNoComp(diOrigenSubDir, siguienteSubdirectorio);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                errores++;
                aerrores.Add(ex.Message);
            }
        }

        #endregion


        public void Parar()
        {
            pulsadoPausar = false;
            pulsadoParar = true;

        }

        public void Pausar(bool EstadoPausar)
        {
            pulsadoPausar = EstadoPausar;
        }

        private void chkRutasOrig_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRutasOrig.Checked)
            {
                txtDestino.Enabled = false;
                btnDestino.Enabled = false;
            }
            else
            {
                txtDestino.Enabled = true;
                btnDestino.Enabled = true;
            }
        }

        private void chkRutasOrig_MouseEnter(object sender, EventArgs e)
        {
            ttInfo.Active = true;
            ttInfo.ToolTipTitle = "Información";
            ttInfo.SetToolTip(chkRutasOrig, "Marcar para restaurar los archivos\nde las copias en sus lugares\nde origen.\nCuidado" +
                        " porque se reemplazarán\nlos archivos que ya existan.");
        }

        private void chkRutasOrig_MouseLeave(object sender, EventArgs e)
        {
            ttInfo.Active = false;
        }

        private void pbInfo_MouseEnter(object sender, EventArgs e)
        {
            ttInfo.Active = true;
            ttInfo.ToolTipTitle = "Información";
            ttInfo.SetToolTip(pbInfo, "Marcar para restaurar los archivos\nde las copias en sus lugares\nde origen.\nCuidado" +
                        " porque se reemplazarán\nlos archivos que ya existan.");
        }

        private void pbInfo_MouseLeave(object sender, EventArgs e)
        {
            ttInfo.Active = false;
        }

        private void btnColapsarIzquierdo_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = panel1.ClientRectangle;
            LinearGradientBrush lgb = new LinearGradientBrush(rect, Color.White, Color.Gray, 90);
            g.FillRectangle(lgb, rect);
            Pen linea = new Pen(Brushes.Black, 1);
            /*g.DrawLine(linea, new Point(0, 0), new Point(rect.Width, 0));
            g.DrawLine(linea, new Point(0, rect.Height - 1), new Point(rect.Width, rect.Height - 1));*/
        }

        private void Acciones_Mouse_Enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.BorderSize = 1;
        }

        private void Acciones_Enter(object sender, EventArgs e)
        {
            Acciones_Mouse_Enter(sender, e);
        }

        private void Acciones_Mouse_Leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.BorderSize = 0;
        }

        private void Etiquietas_Paint(object sender, PaintEventArgs e)
        {
            /*
            Label lbl = (Label)sender;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            Rectangle rect = lbl.ClientRectangle;
            LinearGradientBrush lgb = new LinearGradientBrush(rect, Color.White, Color.Black, 180);
            g.FillRectangle(lgb, rect);

            g = lblRuta.CreateGraphics();
            g.DrawString(lblRuta.Text, lblRuta.Font, Brushes.White, rect);

            g = lblFechaCreacion.CreateGraphics();
            g.DrawString(lblFechaCreacion.Text, lblFechaCreacion.Font , Brushes.White, rect);

            g = lblHoraCreacion.CreateGraphics();
            g.DrawString(lblHoraCreacion.Text, lblHoraCreacion.Font, Brushes.White, rect);

            g = lblTamanyo.CreateGraphics();
            g.DrawString(lblTamanyo.Text, lblTamanyo.Font, Brushes.White, rect);
           
            g = lblCopias.CreateGraphics();
            g.DrawString(lblCopias.Text, lblCopias.Font, Brushes.White, rect);
            */
        }

        private void frmRestaurar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnColapsarDerecho_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = true;
        }

        private void btnMostrarTodoPaneles_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = false;
            splitContainer1.Panel2Collapsed = false;
        }
    }
}