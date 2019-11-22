using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using System.Collections;

namespace BackupRestore
{
    public partial class frmRestIndiComp : Form
    {
        string _origen, _destino;
        bool _restRutasOriginales;
        bool pulsadoParar = true;
        int errores = 0;
        EventosApp eapp;
        System.Threading.Thread hiloCargar;
        bool buscarSiguiente = false;
        ListViewItem itemExtra;
        CompararListView ordenarlvArchivos;

        public frmRestIndiComp()
        {
            InitializeComponent();
        }

        public frmRestIndiComp(string Origen, string Destino, bool RestRutasOriginales)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            _origen = Origen; _destino = Destino;
            _restRutasOriginales = RestRutasOriginales;
            if (_restRutasOriginales == true)
            {
                txtDestino.Text = "Rutas originales";
                txtDestino.Enabled = false;
            }
        }

        private void frmRestIndiComp_Load(object sender, EventArgs e)
        {
            ordenarlvArchivos = new CompararListView();
            lvArchivos.ListViewItemSorter = ordenarlvArchivos;
            pulsadoParar = false;
            lblCargando.Text = "Cargando archivo comprimido\nEspere por favor...";
            this.Text = "Restauración de archivos (Copia Comprimida)";
            txtDestino.Text = _destino;
            tsslblArchivo.Text = "Restaurando de: " + _origen;
            pnlAbajo.Invalidate();
            pnlArriba.Invalidate();
            llblRestaurar.Enabled = false;
            llblDestino.Enabled = false;
            txtDestino.Enabled = false;
            lvArchivos.Visible = false;
            txtBuscar.Enabled = false;
            pbBorrarBuscar.Enabled = false;
            pbBuscarSiguiente.Enabled = false;
            CentrarCargando();
            hiloCargar = new System.Threading.Thread(CargarArchivo);
            hiloCargar.Start();
            PintarFondo();
            eapp = new EventosApp();
        }

        private void CargarArchivo()
        {
            try
            {
                ICSharpCode.SharpZipLib.Zip.ZipConstants.DefaultCodePage = System.Globalization.CultureInfo.CurrentCulture.TextInfo.OEMCodePage;
                ICSharpCode.SharpZipLib.Zip.ZipInputStream zip = new ICSharpCode.SharpZipLib.Zip.ZipInputStream(File.OpenRead(_origen));
                ICSharpCode.SharpZipLib.Zip.ZipEntry entrada;

                while ((entrada = zip.GetNextEntry()) != null)
                {
                    if (pulsadoParar == false)
                    {
                        try
                        {
                            long tamaño, tamañoComp, compresion;

                            if (entrada.Size > 0 & entrada.Size < 1000)
                                tamaño = 1;
                            else
                                tamaño = entrada.Size / 1000;

                            if (entrada.CompressedSize > 0 & entrada.CompressedSize < 1000)
                                tamañoComp = 1;
                            else
                                tamañoComp = entrada.CompressedSize / 1000;

                            if (tamaño == tamañoComp)
                                compresion = 0;
                            else
                                compresion = (((entrada.CompressedSize * 100) / entrada.Size) - 100) * -1;

                            ListViewItem it = new ListViewItem(entrada.Name);
                            it.SubItems.Add(tamaño.ToString("#,0.0") + " KB");
                            it.SubItems.Add(tamañoComp.ToString("#,0.0") + " KB");
                            it.SubItems.Add(compresion.ToString() + "%");
                            it.SubItems.Add(entrada.Crc.ToString());
                            lvArchivos.Items.Add(it);
                            tslblSel.Text = "[ Seleccionados: 0 / " + lvArchivos.Items.Count.ToString("#,0") + " ]";
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                zip.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Mostrar();
            }
        }

        private void Mostrar()
        {
            llblRestaurar.Enabled = true;
            lblCargando.Visible = false;
            lvArchivos.Visible = true;
            txtBuscar.Enabled = true;
            pbBorrarBuscar.Enabled = true;
            pbBuscarSiguiente.Enabled = true;
            if (lvArchivos.Items.Count != 0)
            {
                lvArchivos.Items[0].Focused = true;
                lvArchivos.Items[0].Selected = true;
            }
            if (_restRutasOriginales == true)
            {
                llblDestino.Enabled = false;
                txtDestino.Text = "Restaurando en rutas originales";
                txtDestino.Enabled = false;
            }
            else
            {
                llblDestino.Enabled = true;
                txtDestino.Enabled = true;
            }
        }

        private void PintarFondo()
        {
            foreach (ListViewItem it in lvArchivos.Items)
            {
                if (it.Index % 2 == 0)
                {
                    it.BackColor = Color.Ivory;
                    it.SubItems[1].BackColor = it.BackColor;
                }
                else
                {
                    it.BackColor = Color.AliceBlue;
                    it.SubItems[1].BackColor = it.BackColor;
                }
            }

            Application.DoEvents();
        }

        private void CentrarCargando()
        {
            lblCargando.Location = new Point((pnlCentro.Width - lblCargando.Width) / 2, ((pnlCentro.Height - lblCargando.Height) / 2) - 30);
        }

        private void llblSalir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                hiloCargar.Abort();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            this.Close();
        }

        private void PanelesPaint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            Graphics g = e.Graphics;
            LinearGradientBrush lgb = new LinearGradientBrush(new Rectangle(0, 0, pnl.Width, pnl.Height),
                                        Color.WhiteSmoke, Color.LightGray, LinearGradientMode.Vertical);
            g.FillRectangle(lgb, lgb.Rectangle);
        }

        private void frmRestIndiComp_Resize(object sender, EventArgs e)
        {
            pnlArriba.Invalidate();
            pnlAbajo.Invalidate();
            CentrarCargando();
        }

        private void lvArchivos_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            tslblSel.Text = "[ Seleccionados: " + lvArchivos.CheckedItems.Count.ToString() + " / " + lvArchivos.Items.Count.ToString() + " ]";
        }

        private void mnuDesSelTodo_Click(object sender, EventArgs e)
        {
            lblEspere.Visible = true;
            pbRestaurando.Visible = true;
            Application.DoEvents();

            if (lvArchivos.Items.Count != 0)
            {
                foreach (ListViewItem it in lvArchivos.CheckedItems)
                {
                    it.Checked = false;
                    tslblSel.Text = "[ Seleccionados: " + lvArchivos.CheckedItems.Count.ToString() + " / " + lvArchivos.Items.Count.ToString() + " ]";
                    Application.DoEvents();
                }
            }
            lblEspere.Visible = false;
            pbRestaurando.Visible = false;
        }

        private void mnuSelTodo_Click(object sender, EventArgs e)
        {
            lblEspere.Visible = true;
            pbRestaurando.Visible = true;
            Application.DoEvents();

            if (lvArchivos.Items.Count != 0)
            {
                foreach (ListViewItem it in lvArchivos.Items)
                {
                    it.Checked = true;
                    tslblSel.Text = "[ Seleccionados: " + lvArchivos.CheckedItems.Count.ToString() + " / " + lvArchivos.Items.Count.ToString() + " ]";
                    Application.DoEvents();
                }
            }
            lblEspere.Visible = false;
            pbRestaurando.Visible = false;
        }

        private void frmRestIndiComp_SizeChanged(object sender, EventArgs e)
        {
            CentrarCargando();
        }

        private void llblDestino_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog fbdlg = new FolderBrowserDialog();

            if (Directory.Exists(txtDestino.Text))
            {
                fbdlg.SelectedPath = txtDestino.Text;
            }
            else
            {
                fbdlg.SelectedPath = Application.StartupPath;
            }

            if (fbdlg.ShowDialog() == DialogResult.OK)
            {
                txtDestino.Text = fbdlg.SelectedPath;
            }
        }

        private void llblRestaurar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lvArchivos.CheckedItems.Count != 0)
            {
                pulsadoParar = false;

                prgRestaurado.Value = 0;
                prgRestaurado.Maximum = lvArchivos.CheckedItems.Count;
                prgRestaurado.Visible = true;
                lblRestaurado.Visible = true;
                pbRestaurando.Visible = true;
                llblRestaurar.Enabled = false;
                llblSalir.Enabled = false;
                Application.DoEvents();

                ICSharpCode.SharpZipLib.Zip.ZipConstants.DefaultCodePage = System.Globalization.CultureInfo.CurrentCulture.TextInfo.OEMCodePage;
                ICSharpCode.SharpZipLib.Zip.ZipInputStream zip = new ICSharpCode.SharpZipLib.Zip.ZipInputStream(File.OpenRead(_origen));
                ICSharpCode.SharpZipLib.Zip.ZipEntry entrada = null;

                string nombre = string.Empty;
                string unidad = string.Empty;
                FileInfo fi = null;
                int _archivosrestaurados = 0;

                while ((entrada = zip.GetNextEntry()) != null)
                {
                    foreach (ListViewItem it in lvArchivos.CheckedItems)
                    {
                        if (pulsadoParar == false)
                        {
                            if (it.Text == entrada.Name)
                            {
                                try
                                {
                                    if (_restRutasOriginales == false)
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
                                    _archivosrestaurados++;
                                    prgRestaurado.Value++;
                                    Application.DoEvents();
                                    lblRestaurado.Text = prgRestaurado.Value.ToString() + " / " + lvArchivos.CheckedItems.Count.ToString() + " restaurado, (espere).";
                                    Application.DoEvents();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    errores++;
                                    eapp.PonerEvento("Error restaurando: " + ex.Message);
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                zip.Close();
                prgRestaurado.Visible = false;
                lblRestaurado.Visible = false;
                pbRestaurando.Visible = false;
                llblRestaurar.Enabled = true;
                llblSalir.Enabled = true;
                pulsadoParar = true;

                lblRestaurado.Text = "0 / 0 restaurado";
                if (errores != 0)
                {
                    MessageBox.Show("La restauración ha tenido errores.\nConsulte el visor de eventos.", "Aviso"
                                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Restauración finalizada sin errores.\nSe han restaurado " + _archivosrestaurados.ToString("#,#") + " archivos.",
                                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void llblParar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (pulsadoParar == false)
            {
                if (hiloCargar.ThreadState == System.Threading.ThreadState.Running)
                {
                    hiloCargar.Suspend();
                }

                if (MessageBox.Show("¿Está seguro de cancelar la operación?", "Aviso",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    pulsadoParar = true;

                if (hiloCargar.ThreadState == System.Threading.ThreadState.Suspended)
                {
                    hiloCargar.Resume();
                }
            }
        }

        private void lvArchivos_ItemChecked_1(object sender, ItemCheckedEventArgs e)
        {
            tslblSel.Text = "[ Seleccionados: " + lvArchivos.CheckedItems.Count.ToString() + " / " + lvArchivos.Items.Count.ToString() + " ]";
        }

        private void frmRestIndiComp_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                hiloCargar.Abort();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            txtBuscar.BackColor = Color.LightYellow;
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            txtBuscar.BackColor = Color.White;
        }

        private void pbBorrarBuscar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            buscarSiguiente = false;

            if (txtBuscar.TextLength != 0)
            {
                if (lvArchivos.Items.Count != 0)
                {
                    if (lvArchivos.FocusedItem == null)
                        BuscarSiguiente(0);
                    else
                        BuscarSiguiente(lvArchivos.FocusedItem.Index);
                }
            }
            else
            {
                foreach (ListViewItem it in lvArchivos.SelectedItems)
                {
                    it.Selected = false;
                }

                lvArchivos.Items[0].Focused = true;
                lvArchivos.Items[lvArchivos.FocusedItem.Index].Selected = true;
                lvArchivos.EnsureVisible(0);
            }
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                pbBuscarSiguiente.BackColor = Color.Transparent;
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                pbBuscarSiguiente.BackColor = Color.White;
                buscarSiguiente = true;
            }
            else
                buscarSiguiente = false;

            if (lvArchivos.Items.Count != 0 & e.KeyCode == Keys.Return)
            {
                if (lvArchivos.FocusedItem == null)
                    BuscarSiguiente(0);
                else
                    BuscarSiguiente(lvArchivos.FocusedItem.Index);
            }

            if (e.Modifiers == Keys.Control & e.KeyCode == Keys.M)
            {
                if (lvArchivos.Items.Count != 0)
                {
                    if (lvArchivos.FocusedItem != null)
                    {
                        lvArchivos.FocusedItem.Checked = !lvArchivos.FocusedItem.Checked;
                    }
                }
            }
        }

        private void pbBuscarSiguiente_Click(object sender, EventArgs e)
        {
            buscarSiguiente = true;

            if (lvArchivos.Items.Count != 0)
            {
                if (lvArchivos.FocusedItem == null)
                    BuscarSiguiente(0);
                else
                    BuscarSiguiente(lvArchivos.FocusedItem.Index);
            }
        }

        private void BuscarSiguiente(int Indice)
        {
            ListViewItem itemAnterior = lvArchivos.FocusedItem;

            if (lvArchivos.Items.Count != 0)
            {
                foreach (ListViewItem it in lvArchivos.Items)
                {
                    it.Selected = false;
                }
            }

            try
            {
                bool encontrado = false;

                if (lvArchivos.FocusedItem.Index <= lvArchivos.Items.Count)
                {
                    if (buscarSiguiente)
                    {
                        for (int x = Indice + 1; x < lvArchivos.Items.Count; x++)
                        {
                            if (lvArchivos.Items[x].Text.ToUpper().Contains(txtBuscar.Text.ToUpper()))
                            {
                                lvArchivos.Items[x].Selected = true;
                                lvArchivos.Items[x].Focused = true;
                                lvArchivos.EnsureVisible(lvArchivos.FocusedItem.Index);
                                encontrado = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int x = 0; x <= lvArchivos.Items.Count - 1; x++)
                        {
                            if (lvArchivos.FocusedItem.Index != lvArchivos.Items.Count)
                            {
                                if (lvArchivos.Items[x].Text.ToUpper().Contains(txtBuscar.Text.ToUpper()))
                                {
                                    lvArchivos.Items[x].Selected = true;
                                    lvArchivos.Items[x].Focused = true;
                                    lvArchivos.EnsureVisible(lvArchivos.FocusedItem.Index);
                                    encontrado = true;
                                    break;
                                }
                            }
                        }
                    }

                    if (encontrado == false)
                    {
                        itemAnterior.Focused = true;
                        itemAnterior.Selected = true;
                        MessageBox.Show("No hay más coincidencias.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void PictureBoxBuscarMouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.BackColor = Color.White;
        }

        private void PictureBoxBuscarMouseUp(object sender, MouseEventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.BackColor = Color.Transparent;
        }

        private void tmrRestaurando_Tick(object sender, EventArgs e)
        {
            Image img = pbRestaurando.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pbRestaurando.Image = img;
            Application.DoEvents();
        }

        private void lvArchivos_MouseDown(object sender, MouseEventArgs e)
        {
            if (lvArchivos.Items.Count != 0)
                itemExtra = lvArchivos.GetItemAt(e.X, e.Y);

            if (e.Button == MouseButtons.Right)
                ctxMenuStripItems.Show(lvArchivos, e.X, e.Y);
        }

        private void mnuMarcar_Click(object sender, EventArgs e)
        {
            if (itemExtra != null)
            {
                itemExtra.Checked = true;
            }
        }

        private void mnuDesmarcar_Click(object sender, EventArgs e)
        {
            if (itemExtra != null)
            {
                itemExtra.Checked = false;
            }
        }

        private void mnuAbrir_Click(object sender, EventArgs e)
        {
            if (itemExtra != null)
            {
                try
                {
                    int slash = itemExtra.Text.LastIndexOf("\\");
                    string path = itemExtra.Text.Remove(slash, itemExtra.Text.Length - slash);
                    System.Diagnostics.Process.Start("Explorer.exe", path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void mnuEjecutar_Click(object sender, EventArgs e)
        {
            if (itemExtra != null)
            {
                try
                {
                    System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(itemExtra.Text);
                    //psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
                    System.Diagnostics.Process.Start(psi);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void mnuMarcarTodo_Click(object sender, EventArgs e)
        {
            lblEspere.Visible = true;
            pbRestaurando.Visible = true;
            Application.DoEvents();

            if (lvArchivos.Items.Count != 0)
            {
                foreach (ListViewItem it in lvArchivos.Items)
                {
                    it.Checked = true;
                    tslblSel.Text = "[ Seleccionados: " + lvArchivos.CheckedItems.Count.ToString() + " / " + lvArchivos.Items.Count.ToString() + " ]";
                    Application.DoEvents();
                }
            }
            lblEspere.Visible = false;
            pbRestaurando.Visible = false;
        }

        private void mnuDesmarcartodo_Click(object sender, EventArgs e)
        {
            lblEspere.Visible = true;
            pbRestaurando.Visible = true;
            Application.DoEvents();

            if (lvArchivos.Items.Count != 0)
            {
                foreach (ListViewItem it in lvArchivos.CheckedItems)
                {
                    it.Checked = false;
                    tslblSel.Text = "[ Seleccionados: " + lvArchivos.CheckedItems.Count.ToString() + " / " + lvArchivos.Items.Count.ToString() + " ]";
                    Application.DoEvents();
                }
            }
            lblEspere.Visible = false;
            pbRestaurando.Visible = false;
        }

        private void pbInfoBuscar_MouseEnter(object sender, EventArgs e)
        {
            ttAyudaBuscar.Active = true;
            ttAyudaBuscar.SetToolTip(pbInfoBuscar, "\nPara buscar un archivo teclee en la barra de búsqueda.\n" +
                                    "El cursor se irá desplazando automáticamente en los archivos que\n" +
                                    "concuerden con algún valor del cuadro de búsqueda.\n\n" +
                                    "Con el botón derecho del ratón obtiene un menú con las opciones\n" +
                                    "más prácticas para operar con el archivo.\n\n" +
                                    "Teclas rápidas:\n" +
                                    "Enter = Buscar siguiente.\n" +
                                    "CTRL + M = Marcar / desmarcar item seleccionado.\n");
        }

        private void pbInfoBuscar_MouseLeave(object sender, EventArgs e)
        {
            ttAyudaBuscar.Active = false;
        }

        private void lvArchivos_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ordenarlvArchivos.Ascendente = !ordenarlvArchivos.Ascendente;
            ordenarlvArchivos.columna = e.Column;
            lvArchivos.Sort();
        }
    }

    public class CompararListView : IComparer
    {
        public int columna = 0;
        public bool Ascendente = false;

        public int Compare(object x, object y)
        {
            ListViewItem rowA = (ListViewItem)x;
            ListViewItem rowB = (ListViewItem)y;

            if (Ascendente)
            {
                return String.Compare(rowA.SubItems[columna].Text, rowB.SubItems[columna].Text);
            }
            else
            {
                return String.Compare(rowB.SubItems[columna].Text, rowA.SubItems[columna].Text);
            }
        }
    }
}

