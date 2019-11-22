using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace BackupRestore
{


    public partial class frmLog : Form
    {
        private enum Consulta
        {
            Fecha,
            FechaHora,
            Equipo,
            Usuario,
            Todo,
            Errores
        }

        private enum TipoBoton
        {
            Consultar,
            Eliminiar
        }

        private OleDbConnection con;
        private OleDbCommand com;
        private TipoBoton tp;
        private int indiceimpresion, numPag;
        frmLogBuscar frmlb;

        public frmLog()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                if (con != null)
                    if (con.State == ConnectionState.Open)
                        con.Close();

                this.Dispose();
                this.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void frmLog_Load(object sender, EventArgs e)
        {
            this.Enabled = false;
            dtpFechaDesde.Value = DateTime.Now;
            dtpFechaHasta.Value = DateTime.Now;
            dtpHoraDesde.Text = "00:00";
            dtpHoraHasta.Text = "23:59";
            lblEventos.Left -= 4;
            lvInfo.Columns[1].Width -= 12;
            lvInfo.Columns[3].Width += 5;
            lvInfo.Columns[0].TextAlign = HorizontalAlignment.Center;
            lvInfo.Select();
            lvInfo.AllowColumnReorder = true;
            lvInfo.MultiSelect = false;
            string dbase = Application.StartupPath + "\\Datos.mdb";
            string strcon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbase + ";User Id=admin;Password=;";
            con = new OleDbConnection(strcon);
            tp = TipoBoton.Consultar;

            try
            {
                con.Open();
                com = new OleDbCommand("", con);
                Consultas(Consulta.Todo); // Llamada a la función que carga todos los eventos el el listview
                NumEventos();  // LLamada a la función para saber el número de eventos que hay
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BloquearDesbloquearBotones()
        {
            btnConsultar.Enabled = false;
            btnEliminarTodos.Enabled = false;
            btnBorrarEventos.Enabled = false;
            btnImprimir.Enabled = false;
            btnGuardar.Enabled = false;
        }

        private void DesBloquearBotones()
        {
            btnConsultar.Enabled = true;
            btnEliminarTodos.Enabled = true;
            btnBorrarEventos.Enabled = true;
            btnImprimir.Enabled = true;
            btnGuardar.Enabled = true;
        }

        // Cargar todos los eventos en el listview
        private void CargarDatos(string CadenaSelect)
        {
            try
            {
                com.CommandText = CadenaSelect;
                OleDbDataReader drCargar = com.ExecuteReader();
                lvInfo.Items.Clear();

                if (drCargar.HasRows)
                {
                    this.Enabled = false;

                    while (drCargar.Read())
                    {
                        try
                        {
                            ListViewItem it = new ListViewItem(drCargar.GetDateTime(1).ToShortDateString());
                            it.SubItems.Add(drCargar.GetDateTime(1).ToShortTimeString());
                            it.SubItems.Add(drCargar.GetString(2));
                            it.SubItems.Add(drCargar.GetValue(3).ToString());
                            it.SubItems.Add(drCargar.GetValue(4).ToString());
                            lvInfo.Items.Add(it);
                            if (it.SubItems[2].Text.Contains("Error"))
                            {
                                for (int x = 0; x <= it.SubItems.Count - 1; x++)
                                {
                                    it.SubItems[x].BackColor = Color.Red;
                                }
                            }
                            NumEventos();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            drCargar.Close();
                            drCargar.Dispose();
                            break;
                        }
                    }
                }

                drCargar.Close();
                drCargar.Dispose();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Enabled = true;
                if (lvInfo.Items.Count > 0)
                {
                    lvInfo.Items[lvInfo.Items.Count - 1].Selected = true;
                    lvInfo.EnsureVisible(lvInfo.Items.Count - 1);
                }
                lvInfo.Select();
            }
        }

        private void btnEliminarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvInfo.Items.Count > 0)
                {
                    if (MessageBox.Show("¿Borrar todos los eventos?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CargarDatos("DELETE FROM Logs;");
                        NumEventos();
                    }
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Lee el número de eventos del listview
        private void NumEventos()
        {
            lblEventos.Text = lvInfo.Items.Count.ToString() + " eventos";
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            tp = TipoBoton.Consultar;
            tsmnuBuscar.Visible = true;
            toolStripSeparator3.Visible = true;
            tsmnuFechaErrores.Visible = true;
            cmStripConsultas.Show(btnConsultar, new Point(0, btnConsultar.Size.Height));
        }

        private void btnBorrarEventos_Click(object sender, EventArgs e)
        {
            tp = TipoBoton.Eliminiar;
            tsmnuBuscar.Visible = false;
            toolStripSeparator3.Visible = false;
            tsmnuFechaErrores.Visible = false;
            cmStripConsultas.Show(btnBorrarEventos, new Point(0, btnBorrarEventos.Size.Height));
        }

        private void tsmnuFecha_Click(object sender, EventArgs e)
        {
            if (tp == TipoBoton.Consultar)
                Consultas(Consulta.Fecha);
            else if (tp == TipoBoton.Eliminiar)
                Borrados(Consulta.Fecha);
        }

        private void tsmnuHoras_Click(object sender, EventArgs e)
        {
            if (tp == TipoBoton.Consultar)
                Consultas(Consulta.FechaHora);
            else if (tp == TipoBoton.Eliminiar)
                Borrados(Consulta.FechaHora);
        }

        private void tsmnuEquipos_Click(object sender, EventArgs e)
        {
            if (tp == TipoBoton.Consultar)
                Consultas(Consulta.Equipo);
            else if (tp == TipoBoton.Eliminiar)
                Borrados(Consulta.Equipo);
        }

        private void tsmnuUsuarios_Click(object sender, EventArgs e)
        {
            if (tp == TipoBoton.Consultar)
                Consultas(Consulta.Usuario);
            else if (tp == TipoBoton.Eliminiar)
                Borrados(Consulta.Usuario);
        }

        private void tsmnuTodo_Click(object sender, EventArgs e)
        {
            if (tp == TipoBoton.Consultar)
                Consultas(Consulta.Todo);
            else if (tp == TipoBoton.Eliminiar)
            {
                if (lvInfo.Items.Count != 0)
                {
                    if (MessageBox.Show("¿Borrar todos los eventos?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        Borrados(Consulta.Todo);
                }
            }
        }

        private void tsmnuFechaErrores_Click(object sender, EventArgs e)
        {
            Consultas(Consulta.Errores);
        }

        private string[] CambiarFechasFormatoAmericano
        {
            get
            {
                string diadesde = dtpFechaDesde.Value.Day.ToString();
                string mesdesde = dtpFechaDesde.Value.Month.ToString();
                string añodesde = dtpFechaDesde.Value.Year.ToString();
                string diahasta = dtpFechaHasta.Value.Day.ToString();
                string meshasta = dtpFechaHasta.Value.Month.ToString();
                string añohasta = dtpFechaHasta.Value.Year.ToString();
                string horadesde = dtpHoraDesde.Value.Hour.ToString();
                string minutodesde = dtpHoraDesde.Value.Minute.ToString();
                string segundodesde = dtpHoraDesde.Value.Second.ToString();
                string horahasta = dtpHoraHasta.Value.Hour.ToString();
                string minutohasta = dtpHoraHasta.Value.Minute.ToString();
                string segundohasta = dtpHoraHasta.Value.Second.ToString();

                string fechadesde = mesdesde + "/" + diadesde + "/" + añodesde;
                string fechahasta = meshasta + "/" + diahasta + "/" + añohasta;
                string fechahoradesde = fechadesde + " " + horadesde + ":" + minutodesde + ":00";
                string fechahorahasta = fechahasta + " " + horahasta + ":" + minutohasta + ":59";

                string[] Fechas = new string[4] { fechadesde, fechahasta, fechahoradesde, fechahorahasta };

                return Fechas;
            }
        }

        private void Consultas(Consulta TipoConsulta)
        {
            switch (TipoConsulta)
            {
                case Consulta.Fecha:
                    CargarDatos("SELECT * FROM Logs WHERE fecha BETWEEN #" + CambiarFechasFormatoAmericano[0] + " 23:59:59# AND #" +
                                 CambiarFechasFormatoAmericano[1] + " 00:00:00#;");
                    break;

                case Consulta.FechaHora:
                    CargarDatos("SELECT * FROM Logs WHERE fecha BETWEEN #" + CambiarFechasFormatoAmericano[2] + "# AND #" +
                                 CambiarFechasFormatoAmericano[3] + "#;");
                    break;

                case Consulta.Equipo:
                    CargarDatos("SELECT * FROM Logs WHERE equipo>='" + txtEquipoDesde.Text + "' AND equipo <='" + txtEquipoHasta.Text + "';");
                    break;

                case Consulta.Usuario:
                    CargarDatos("SELECT * FROM Logs WHERE usuario>='" + txtUsuarioDesde.Text + "' AND usuario <='" + txtUsuarioHasta.Text + "';");
                    break;

                case Consulta.Errores:
                    CargarDatos("SELECT * FROM Logs WHERE fecha BETWEEN #" + CambiarFechasFormatoAmericano[0] + " 23:59:59# AND #" +
                                CambiarFechasFormatoAmericano[1] + " 00:00:00# AND evento LIKE 'Error%';");
                    break;

                case Consulta.Todo:
                    CargarDatos("SELECT * FROM Logs ORDER BY fecha;");
                    break;

                default:
                    break;
            }
        }

        private void Borrados(Consulta TipoConsulta)
        {
            switch (TipoConsulta)
            {
                case Consulta.Fecha:
                    CargarDatos("DELETE FROM Logs WHERE fecha BETWEEN #" + CambiarFechasFormatoAmericano[0] + " 23:59:59# AND #" +
                                 CambiarFechasFormatoAmericano[1] + " 00:00:00#;");
                    break;

                case Consulta.FechaHora:
                    CargarDatos("DELETE FROM Logs WHERE fecha BETWEEN #" + CambiarFechasFormatoAmericano[2] + "# AND #" +
                                 CambiarFechasFormatoAmericano[3] + "#;");
                    break;

                case Consulta.Equipo:
                    CargarDatos("DELETE FROM Logs WHERE equipo>='" + txtEquipoDesde.Text + "' AND equipo <='" + txtEquipoHasta.Text + "';");
                    break;

                case Consulta.Usuario:
                    CargarDatos("DELETE FROM Logs WHERE usuario>='" + txtUsuarioDesde.Text + "' AND usuario <='" + txtUsuarioHasta.Text + "';");
                    break;

                case Consulta.Todo:

                    CargarDatos("DELETE FROM Logs;");
                    break;

                default:
                    break;
            }
        }

        private void frmLog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            if (frmlb != null)
                frmlb.Dispose();

            btnSalir_Click(sender, new EventArgs());
        }

        private void lvInfo_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                cmStripListView.Show(Control.MousePosition.X, Control.MousePosition.Y);
        }

        private void tsmnuCopiar_Click(object sender, EventArgs e)
        {
            string seltext = lvInfo.FocusedItem.SubItems[0].Text + " - " + lvInfo.FocusedItem.SubItems[1].Text +
                             " - " + lvInfo.FocusedItem.SubItems[2].Text + " - " + lvInfo.FocusedItem.SubItems[3].Text +
                             " - " + lvInfo.FocusedItem.SubItems[4].Text;
            Clipboard.SetText(seltext);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (lvInfo.Items.Count > 0)
            {

                SaveFileDialog sdlg = new SaveFileDialog();
                sdlg.Filter = "Archivo de texto (*.txt)|*.txt|Archivo de información (*.log)|*.log";
                sdlg.ShowHelp = true;
                sdlg.FileName = "BR-Eventos.txt";
                if (sdlg.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = new FileStream(sdlg.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine("---------------------------------------");
                    sw.WriteLine("Listado de eventos de Backup&Restore...");
                    sw.WriteLine("---------------------------------------");
                    sw.WriteLine("Fecha: " + DateTime.Now.ToLongDateString());
                    sw.WriteLine("---------------------------------------");
                    sw.WriteLine("");
                    sw.WriteLine("");
                    for (int x = 0; x <= lvInfo.Items.Count - 1; x++)
                    {
                        sw.WriteLine("[Evento: " + Convert.ToString(x + 1) + "]");
                        sw.WriteLine("\t- Fecha .: " + lvInfo.Items[x].SubItems[0].Text + " " + lvInfo.Items[x].SubItems[1].Text);
                        sw.WriteLine("\t- Evento : " + lvInfo.Items[x].SubItems[2].Text);
                        sw.WriteLine("\t- Equipo : " + lvInfo.Items[x].SubItems[3].Text);
                        sw.WriteLine("\t- Usuario: " + lvInfo.Items[x].SubItems[4].Text);
                        sw.WriteLine();
                    }
                    sw.WriteLine("");
                    sw.Write("-=[Fin del archivo]=- Eventos: " + lvInfo.Items.Count.ToString());
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                }
            }
            else
            {
                MessageBox.Show("No hay nada que guardar...", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (lvInfo.Items.Count != 0)
            {
                if (pdlg.ShowDialog() == DialogResult.OK)
                {
                    indiceimpresion = 0;
                    numPag = 0;
                    pdoc.Print();
                }
            }
            else
            {
                MessageBox.Show("No hay nada que imprimir...", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pdoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float lineasPorHoja = 0;
            numPag++;
            float yPos = 0;
            int contador = 0;
            float margenIzquierdo = e.MarginBounds.Left;
            float margenSuperior = e.MarginBounds.Top - 30;
            Font fuente = new Font("Arial", 10);
            Font fuenteCabecera = new Font("Arial", 14, FontStyle.Bold);

            // Calcular el número de líneas por hoja.
            lineasPorHoja = (e.MarginBounds.Height / fuente.GetHeight(e.Graphics) - 8);

            yPos = margenSuperior + (contador * fuenteCabecera.GetHeight(e.Graphics));

            e.Graphics.DrawString("Listado de eventos de Backup&Restore... ", fuenteCabecera, Brushes.Black, margenIzquierdo, yPos, new StringFormat());
            contador++;
            yPos = margenSuperior + (contador * fuenteCabecera.GetHeight(e.Graphics));
            e.Graphics.DrawString("Fecha: " + DateTime.Now.ToLongDateString(), new Font("Arial", 10, FontStyle.Bold),
                                                        Brushes.Black, margenIzquierdo, yPos, new StringFormat());
            contador += 4;

            // Interactuar sobre cada línea de impresión.
            while (contador < lineasPorHoja)
            {
                if (indiceimpresion <= lvInfo.Items.Count - 1)
                {
                    contador++;
                    yPos = margenSuperior + (contador * fuente.GetHeight(e.Graphics));
                    e.Graphics.DrawString("[Evento: " + Convert.ToString(lvInfo.Items[indiceimpresion].Index + 1) + "]", fuente,
                                            Brushes.Black, margenIzquierdo, yPos, new StringFormat());
                    contador++;
                    yPos = margenSuperior + (contador * fuente.GetHeight(e.Graphics));
                    e.Graphics.DrawString("     -Fecha .: " + lvInfo.Items[indiceimpresion].SubItems[0].Text + " " + lvInfo.Items[indiceimpresion].SubItems[1].Text,
                                            fuente, Brushes.Black, margenIzquierdo, yPos, new StringFormat());
                    contador++;
                    yPos = margenSuperior + (contador * fuente.GetHeight(e.Graphics));
                    e.Graphics.DrawString("     -Evento : " + lvInfo.Items[indiceimpresion].SubItems[2].Text, fuente, Brushes.Black, margenIzquierdo, yPos, new StringFormat());
                    contador++;
                    yPos = margenSuperior + (contador * fuente.GetHeight(e.Graphics));
                    e.Graphics.DrawString("     -Equipo : " + lvInfo.Items[indiceimpresion].SubItems[3].Text, fuente, Brushes.Black, margenIzquierdo, yPos, new StringFormat());
                    contador++;
                    yPos = margenSuperior + (contador * fuente.GetHeight(e.Graphics));
                    e.Graphics.DrawString("     -Usuario: " + lvInfo.Items[indiceimpresion].SubItems[4].Text, fuente, Brushes.Black, margenIzquierdo, yPos, new StringFormat());
                }
                indiceimpresion++;
                contador++;
            }

            SizeF tampag = e.Graphics.MeasureString("Página: " + numPag.ToString(), fuente);
            contador += 3;
            yPos = margenSuperior + (contador * fuente.GetHeight(e.Graphics));
            e.Graphics.DrawString("Página: " + numPag.ToString(), fuente, Brushes.Black, new PointF((e.PageBounds.Width / 2) - tampag.Width,
                                            yPos), new StringFormat());

            // Si existen más líneas, imprimir otra página.
            if (indiceimpresion <= lvInfo.Items.Count - 1)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }

        private void tsmnuBuscar_Click(object sender, EventArgs e)
        {
            if (tsmnuBuscar.Enabled && lvInfo.Items.Count != 0)
            {
                frmlb = new frmLogBuscar(tsmnuBuscar, lvInfo);
                frmlb.ShowInTaskbar = false;
                frmlb.StartPosition = FormStartPosition.Manual;
                frmlb.Location = new Point(this.Location.X + 200, this.Location.Y + (frmlb.Size.Height - 25));
                frmlb.Show();
                frmlb.Saliendo += new frmLogBuscar.DelegadoSalir(frmlb_Saliendo);
            }
            else
            {
                try
                {
                    if (frmlb != null)
                        frmlb.Select();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void frmlb_Saliendo(bool Saliendo)
        {
            if (Saliendo)
                frmlb.Dispose();
        }

        private void frmLog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.B & e.Modifiers == Keys.Control)
            {
                tsmnuBuscar_Click(null, null);
            }
            else if (e.KeyCode == Keys.Escape)
                btnSalir_Click(sender, e);
                
        }
    }
}