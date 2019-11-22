/* ----------------------------------------------
 *  Clase para las copias de seguridad comprimida
 * ---------------------------------------------- */

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Threading;

namespace BackupRestore
{
    class CopiaComprimida
    {
        #region Controladores de eventos y Eventos
        public delegate void CopiaInciadaEventHandler();
        public event CopiaInciadaEventHandler CopiaIniciada;
        public delegate void CopiaFinalizadaEventHandler();
        public event CopiaFinalizadaEventHandler CopiaFinalizada;
        #endregion

        #region Variables Miembro o campos
        DateTime fechaHoraInicio;
        private OleDbConnection mCon;
        private OleDbCommand mCom;
        private OleDbDataReader dr;
        private int mCiclos;
        private string mDestino1, mDestino2;
        private ListView mLv;
        private ToolStripStatusLabel mTsslbl;
        private int mErrores;
        private int mArchivos;
        private Label mContador;
        private ProgressBar mPrgB;
        private int mArcActual;
        private Label mObjeto;
        private bool mPulsadoBotonParar;
        private KryptonButton mBotonConfigurar, mBotonEmpezar, mBotonParar, mBotonSalir;
        private CheckBox mChkApagar;
        private int mUltimoCiclo;
        private ICSharpCode.SharpZipLib.Zip.ZipOutputStream zip;
        private EventosApp epp;
        private Label lblDirectorioCopias, lblCiclo, lblPorcentaje;
        int diractual;
        int sigCiclo;
        int numAvisos;
        CalcularPorcentaje cp;
        private bool errorRaro;
        #endregion

        #region Constructor
        public CopiaComprimida(Label LabelCiclo, ListView ListViewErrores, ToolStripStatusLabel ToolStripStatusLabel, Label lblContador, ProgressBar BarraProgreso, Label Objeto,
                       KryptonButton BotonConfigurar, KryptonButton BotonEmpezar, KryptonButton BotonParar, KryptonButton BotonSalir, CheckBox CheckApagar, Label labelDestCopia, Label labelPorcentaje)
        {
            errorRaro = false;
            numAvisos = 1;
            lblPorcentaje = labelPorcentaje;
            mLv = ListViewErrores;
            mTsslbl = ToolStripStatusLabel;
            mErrores = 0;
            mContador = lblContador;
            mPrgB = BarraProgreso;
            mObjeto = Objeto;
            mPulsadoBotonParar = false;
            mBotonConfigurar = BotonConfigurar;
            mBotonEmpezar = BotonEmpezar;
            mBotonParar = BotonParar;
            mBotonSalir = BotonSalir;
            mChkApagar = CheckApagar;
            lblDirectorioCopias = labelDestCopia;
            lblCiclo = LabelCiclo;
            string dbase = Application.StartupPath + "\\Datos.mdb";
            string strcon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbase + ";User Id=admin;Password=;";
            try
            {
                // Se crea la conexión
                if (mCon != null)
                {
                    if (mCon.State == ConnectionState.Closed)
                    {
                        mCon.Open();
                    }
                }
                else
                {
                    mCon = new OleDbConnection(strcon);
                    mCon.Open();
                }

                mCom = new OleDbCommand("SELECT * FROM Opciones", mCon);
                epp = new EventosApp();
                PoblarCampos();
                PonerDestinos();
                PonerCiclo(false);
            }
            catch (OleDbException ex)
            {
                PonerSucesos(ex, null, true, false);
            }
        }
        #endregion

        #region Carga de datos desde la base de datos
        public int PoblarCampos()
        {
            mCom.CommandText = "SELECT * FROM destinos;";
            dr = mCom.ExecuteReader();

            while (dr.Read())
            {
                mDestino1 = dr.GetString(1);
                mDestino2 = dr.GetString(2);
            }
            dr.Close();

            mCom.CommandText = "SELECT * FROM opciones;";
            dr = mCom.ExecuteReader();

            // Se puebla la variable mCiclos para saber cuantos ciclos
            while (dr.Read())
            {
                mCiclos = dr.GetInt32(2);
            }
            dr.Close();

            // Se lee el último Destino de copia:
            mCom.CommandText = "SELECT * FROM ciclocopias;";
            dr = mCom.ExecuteReader();
            while (dr.Read())
            {
                mUltimoCiclo = dr.GetInt32(0);
            }
            dr.Close();

            ComprobarLabel();

            if (Directory.Exists(mDestino1))
                return 1;
            else
                return 0;
        }
        #endregion

        #region Comprobar Label
        public void ComprobarLabel()
        {
            string dest1 = ComprobarPorLabel.UnidadCopias(mDestino1);

            if (dest1 == null)
            {
                if (numAvisos == 0)
                {
                    //MessageBox.Show("- El disco no es de copias.\n\n- Posibles causas . . .\n\n     - Compruebe que la etiqueta del disco que sea . . .\n        " +
                    //Properties.Settings.Default.label_disco + "\n\n     - También tiene que fijarse en que el primer\n        " +
                    //                "destino exista en el disco de copias.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DateTime ahora = DateTime.Now;
                    DateTime despues = ahora.AddSeconds(1);

                    while (ahora <= despues)
                    {
                        ahora = DateTime.Now;
                        Application.DoEvents();
                    }

                    numAvisos++;
                }

                mDestino1 = "";
            }
            else
            {
                mDestino1 = dest1;
            }
        }
        #endregion

        #region Propiedades
        public int Errores
        {
            get { return mErrores; }
        }

        public int ArchivoActual
        {
            get { return mArcActual; }
        }

        public int ArchivosTotales
        {
            get { return mArchivos; }
        }
        #endregion

        #region PonerCiclos
        public void PonerCiclo(bool VieneDeConfiguración)
        {
            if (Directory.Exists(mDestino1))
            {
                if (VieneDeConfiguración == false)
                {
                    int sigcl = mUltimoCiclo + 1;

                    if (mUltimoCiclo < mCiclos)
                        lblCiclo.Text = "Último ciclo: " + Convert.ToString(sigcl) + " / " + mCiclos.ToString();
                    else
                        lblCiclo.Text = "Último ciclo: 1 / " + mCiclos.ToString();
                }
                else
                {
                    lblCiclo.Text = "Último ciclo: " + mUltimoCiclo.ToString() + " / " + mCiclos.ToString();
                }
            }
            else
            {
                lblCiclo.Text = "Último ciclo: " + mUltimoCiclo.ToString() + " / " + mCiclos.ToString();
            }
        }
        #endregion

        #region Bloquear y Desbloquear botones
        // Calcular el ancho del item descripción del listview errores para ampliar la columna descripción al máximo
        //private int AnchoItem(ListViewItem LvItem)
        //{
        //    Graphics g = null;
        //    SizeF tam = new SizeF(g.MeasureString(LvItem.SubItems[1].Text, LvItem.Font));
        //    //Rectangle r = new Rectangle(new Point(LvItem.SubItems[0].Bounds.X, LvItem.SubItems[0].Bounds.Y), tam.ToSize());
        //    return (int)tam.Width;
        //}

        //Función que hace que cuando se esté haciendo la copia los botones de acciones se desactiven menos el botón parar
        //Así no se podrá por ejemplo llamar a la ventana de opciones pero si se podrá interrumpir la copia
        private void BloquearBotones()
        {
            mBotonConfigurar.Enabled = false;
            mBotonEmpezar.Enabled = false;
            mBotonSalir.Enabled = false;
        }

        //Activa los botones de acciones ya que en este momento no se está haciendo la copia
        private void DesBloquearBotones()
        {
            mBotonConfigurar.Enabled = true;
            mBotonEmpezar.Enabled = true;
            mBotonSalir.Enabled = true;
        }
        #endregion

        #region Calcular Archivos
        // Función para calcular el número de archivos para la copia
        private int Calcular()
        {
            mPrgB.Style = ProgressBarStyle.Marquee;
            mPrgB.MarqueeAnimationSpeed = 20;
            mObjeto.Text = "Calculando el número de archivos de la copia, espere...";
            mContador.Text = "0 / 0 archivos";
            mPrgB.Value = 0;
            mArchivos = 0;
            int existe = 0;
            Application.DoEvents();

            // Se invoca a este método para releer los datos nuevos de la configuración
            // por si esta ha cambiado al pulsar el botón configurar.
            ComponerDataReaderDatos();

            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (mPulsadoBotonParar == false)
                        {
                            if (dr.GetBoolean(1) == true && dr.GetBoolean(2) == false)
                            {
                                DirectoryInfo dir = new DirectoryInfo(dr.GetString(0));

                                if (dir.Exists)
                                {
                                    mArchivos += dir.GetFiles().Length;
                                    existe = 1;
                                }
                                else
                                {
                                    existe = 0;
                                    break;
                                }
                            }
                            else if (dr.GetBoolean(1) == true && dr.GetBoolean(2) == true)
                            {
                                DirectoryInfo dir = new DirectoryInfo(dr.GetString(0));

                                if (dir.Exists)
                                {
                                    // Se ejecuta el método Recalcular para hacer recursividad en el 
                                    // número de archivos que hay que incluir en la copia
                                    ReCalcular(dir);
                                    existe = 1;
                                }
                                else
                                {
                                    existe = 0;
                                    break;
                                }
                            }
                            else
                            {
                                if (File.Exists(dr.GetString(0)))
                                {
                                    // Es un directorio y no es recursivo entonces se llena la variable 
                                    // mArchivos que contien el total de archivos de la copia
                                    mArchivos++;
                                    existe = 1;
                                }
                                else
                                {
                                    existe = 0;
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    existe = 0;
                }

                switch (existe)
                {
                    case 0:
                        mContador.Text = "0 / 0 archivos";
                        break;
                    case 1:
                        mContador.Text = "0 / " + mArchivos.ToString("#,#") + " archivos";
                        break;
                    default:
                        break;
                }

                Application.DoEvents();
                return existe;
            }
            catch (Exception ex)
            {
                PonerSucesos(ex, null, true, false);
                return 0;
            }
            finally
            {
                mArcActual = 0;
                mPrgB.Minimum = 0;
                mPrgB.Maximum = mArchivos; // La barra de progreso se pone como propiedad Maximun el número totales de archivos
                mPrgB.Style = ProgressBarStyle.Continuous;
                lblPorcentaje.Text = "0%";
                cp = new CalcularPorcentaje(0, mArchivos);
                dr.Close();
                Application.DoEvents();
            }
        }

        // Función recursiva para calcular el número de archivos de la copia
        private void ReCalcular(DirectoryInfo DirectorioPrincipal)
        {
            try
            {
                if (!mPulsadoBotonParar)
                {
                    mArchivos += DirectorioPrincipal.GetFiles().Length;
                    mContador.Text = "0 / " + mArchivos.ToString("#,#") + " archivos";
                    cp.TotalArchivos = mArchivos;
                    lblPorcentaje.Text = "0%";
                    Application.DoEvents();

                    foreach (DirectoryInfo dir in DirectorioPrincipal.GetDirectories())
                    {
                        if (!mPulsadoBotonParar)
                        {
                            ReCalcular(dir);
                            Application.DoEvents();
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PonerSucesos(ex, null, true, false);
            }
        }
        #endregion

        #region Componer el DataReader de Datos
        // Función que puebla el componente DataReader que está asignado a la variable dr, con los datos de la tabla datos
        // Éste se utilizará para leer todos los archivos que hay que copiar
        private void ComponerDataReaderDatos()
        {
            try
            {
                dr.Close();
                mCom.CommandText = "SELECT * FROM datos;";
                dr = mCom.ExecuteReader();
            }
            catch (Exception ex)
            {
                PonerSucesos(ex, null, true, false);
            }
        }
        #endregion

        #region Poner valores por defecto de la ventana

        public void PonerDestinos()
        {
            PoblarCampos();
            if (Directory.Exists(mDestino2))
                lblDirectorioCopias.Text = "Destino de copia: 1/2";
            else
                lblDirectorioCopias.Text = "Destino de copia: 1/1";
        }

        private void PonerACero()
        {
            diractual = 1;
            BloquearBotones();
            mArcActual = 0;
            mErrores = 0;
            mLv.Items.Clear();
            mPrgB.Value = 0;
            mTsslbl.Text = "Número de errores: 0";
            mObjeto.Text = "";
            mContador.Text = "0 / 0 archivos";
            mPulsadoBotonParar = false;
            lblPorcentaje.Text = "0%";
            numAvisos = 0;
            Application.DoEvents();
            PonerDestinos();

            if (cp != null)
                cp.TotalArchivos = 0;
            else
                cp = new CalcularPorcentaje(0, 0);

            Application.DoEvents();
        }
        #endregion

        #region Funcion para empezar la copia
        /* Función para empeza a copiar, es pública para que dentro del formulario de copias donde está declarado
         * un objeto que és esta clase, se pueda llamar a la función parar para interrumpir la copia */
        public void EmpezarCopia()
        {
            if (Directory.Exists(mDestino1))
            {
                if (mPulsadoBotonParar == false)
                {
                    try
                    {
                        fechaHoraInicio = DateTime.Now;

                        CopiaIniciada();
                        PonerACero();
                        errorRaro = false;
                        PonerCiclo(false);

                        // Carga los datos de la configuración y devuelve 1 si el destino1 existe
                        if (PoblarCampos() == 1)
                        {
                            // Se calcula el total de archivos de la copia y se devuelve 1 si hay algo que copiar y las rutas existen, creado en la configuración
                            if (Calcular() == 1)
                            {
                                // Si existe el destino 1 se crea el archivo siguiente del ciclo, el 1 es un número que indica en que destino hacer las copias
                                if (CrearCiclosCopiasCompromidas(1) != "")
                                {
                                    // Se crea el archivo zip en el primer destino de copias
                                    CrearArchivoZip(1);

                                    // Función que añade los archivos al zip
                                    InsertarAlZip();
                                    CerrarArchivoZip();

                                    // Si hay algo en el campo destino2 y es un directorio crearlo tambien los ciclos de copias...
                                    if (Directory.Exists(mDestino2))
                                    {
                                        if (mPulsadoBotonParar == false)
                                        {
                                            PonerACero();
                                            diractual++;
                                            lblDirectorioCopias.Text = "Destino de copia: 2/2";
                                            CrearCiclosCopiasCompromidas(2);
                                            CrearArchivoZip(2);
                                            InsertarAlZip();
                                            CerrarArchivoZip();
                                        }
                                    }
                                }
                                else
                                {
                                    ListViewItem it = new ListViewItem("Error: 0", 2);
                                    ListViewItem it2 = new ListViewItem("");
                                    it.SubItems.Add("La información de la copia está mal configurada...");
                                    it2.SubItems.Add("Puede ser que algún directorio o archivo no exista o se haya movido...");
                                    mLv.Items.Add(it);
                                    mLv.Items.Add(it2);
                                    mErrores++;
                                    mTsslbl.Text = "Número de errores: " + mErrores.ToString();
                                    epp.PonerEvento("Error: La información de la copia está mal configurada.");
                                    epp.PonerEvento("Error: La copia comprimida en el destino " + diractual.ToString() + ", ciclo " + sigCiclo.ToString() +
                                                    ", no se ha creado.");
                                    mObjeto.Text = "Error en el proceso de copias, revise los errores...";
                                    mContador.Text = "0 / 0 archivos";
                                }
                            }
                            else
                            {
                                ListViewItem it = new ListViewItem("Error: 0", 2);
                                ListViewItem it2 = new ListViewItem("");
                                it.SubItems.Add("La información de la copia está mal configurada...");
                                it2.SubItems.Add("Puede ser que algún directorio o archivo no exista o se haya movido...");
                                mLv.Items.Add(it);
                                mLv.Items.Add(it2);
                                mErrores++;
                                mTsslbl.Text = "Número de errores: " + mErrores.ToString();
                                epp.PonerEvento("Error: La información de la copia está mal configurada.");
                                epp.PonerEvento("Error: La copia comprimida en el destino " + diractual.ToString() + ", ciclo " + sigCiclo.ToString() +
                                                ", no se ha creado.");
                                mObjeto.Text = "Error en el proceso de copias, revise los errores...";
                            }
                        }
                        else
                        {
                            ListViewItem it = new ListViewItem("Error: 0", 2);
                            it.SubItems.Add("El primer destino de copias no existe -> " + mDestino1);
                            mLv.Items.Add(it);
                            mErrores++;
                            mTsslbl.Text = "Número de errores: " + mErrores.ToString();
                            epp.PonerEvento("Error: El primer destino de copias no existe.");
                            epp.PonerEvento("Error: La copia comprimida en el destino " + diractual.ToString() + ", ciclo " + sigCiclo.ToString() +
                                                    ", no se ha creado.");
                            mObjeto.Text = "Error en el proceso de copias, revise los errores...";
                        }
                    }
                    catch (OleDbException ex)
                    {
                        ListViewItem it = new ListViewItem(ex.ErrorCode.ToString(), 0);
                        it.SubItems.Add(ex.Message);
                        mLv.Items.Add(it);
                        mErrores++;
                        mTsslbl.Text = "Número de errores: " + mErrores.ToString();
                        epp.PonerEvento("Error: " + ex.Message);
                    }
                    finally
                    {
                        if (errorRaro)
                        {
                            mPrgB.Value = mArchivos;
                            lblPorcentaje.Text = "100%";
                            mContador.Text = mArchivos.ToString("#,#") + " / " + mArchivos.ToString("#,#") + " archivos";
                        }
                        else
                        {
                            if (mPulsadoBotonParar == false)
                            {
                                if (Properties.Settings.Default.control_errores)
                                {
                                    mPrgB.Value = mArchivos - mLv.Items.Count;
                                    mContador.Text = mPrgB.Value.ToString("#,#") + " / " + ArchivosTotales.ToString("#,#") + " archivos";

                                    if (mLv.Items.Count != 0)
                                        lblPorcentaje.Text = Convert.ToString(cp.CalcularPorcentajeRestante(mArcActual, mArchivos)) + "%";
                                    else
                                        lblPorcentaje.Text = "100%";
                                }
                                else
                                {
                                    mPrgB.Value = ArchivosTotales;
                                    mContador.Text = ArchivosTotales.ToString("#,#") + " / " + ArchivosTotales.ToString("#,#") + " archivos";
                                    lblPorcentaje.Text = "100%";
                                }
                            }
                        }

                        Application.DoEvents();
                        Thread.Sleep(1000);
                        Application.DoEvents();

                        CopiaFinalizada();

                        TimeSpan tinicio = new TimeSpan(fechaHoraInicio.Hour, fechaHoraInicio.Minute, fechaHoraInicio.Second);
                        TimeSpan tfinal = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                        TimeSpan duracion = tfinal.Subtract(tinicio);

                        if (Properties.Settings.Default.prgEnviarInforme == true)
                        {
                            if (mPulsadoBotonParar == false)
                            {
                                string mObjetoTextAntes = mObjeto.Text;
                                mObjeto.Text = "Enviando informe, espere...";
                                int estado = 0;
                                Application.DoEvents();

                                if (mLv.Items.Count == 0)
                                {
                                    estado = Emails.EnviarInforme(Emails.ResultadoCopia.OK, "- Tipo de copia ".PadRight(24, '.') + ": " + "Comprimida\n" +
                                                           "- Equipo ".PadRight(28, '.') + ": " + Environment.MachineName + "\n" +
                                                           "- Inicio ".PadRight(30, '.') + ": " + fechaHoraInicio.ToShortDateString() + " " +
                                                           fechaHoraInicio.ToLongTimeString() + "\n" +
                                                           "- Fin ".PadRight(31, '.') + ": " + DateTime.Now.ToShortDateString() + " " +
                                                           DateTime.Now.ToLongTimeString() + "\n" +
                                                           "- Duración " + "".PadRight(16, '.') + ": " + duracion.Hours.ToString("00") +
                                                           ":" + duracion.Minutes.ToString("00") + ":" + duracion.Seconds.ToString("00") + "\n" +
                                                           "- Archivos copiados .: " + mContador.Text +
                                                           "\n\n-{ Fin del informe }-");
                                    if (estado == 0)
                                    {
                                        mObjeto.Text = mObjetoTextAntes + ", envío del informe correcto...";
                                        epp.PonerEvento("Informe enviado correctamente");
                                    }
                                    else
                                    {
                                        mObjeto.Text = mObjetoTextAntes + ", envío del informe erróneo...";
                                        epp.PonerEvento("Error al enviar el informe");
                                    }
                                }
                                else
                                {
                                    estado = Emails.EnviarInforme(Emails.ResultadoCopia.Error, "- Tipo de copia ".PadRight(24, '.') + ": " + "Comprimida\n" +
                                                           "- Equipo ".PadRight(27, '.') + ": " + Environment.MachineName + "\n" +
                                                           "- Inicio ".PadRight(30, '.') + ": " + fechaHoraInicio.ToShortDateString() + " " +
                                                           fechaHoraInicio.ToLongTimeString() + "\n" +
                                                           "- Fin ".PadRight(31, '.') + ": " + DateTime.Now.ToShortDateString() + " " +
                                                           DateTime.Now.ToLongTimeString() + "\n" +
                                                           "- Duración " + "".PadRight(16, '.') + ": " + duracion.Hours.ToString("00") +
                                                           ":" + duracion.Minutes.ToString("00") + ":" + duracion.Seconds.ToString("00") + "\n" +
                                                           "- Archivos copiados .: " + mContador.Text +
                                                           "\n\n-{ Fin del informe }-");
                                    if (estado == 0)
                                    {
                                        mObjeto.Text = mObjetoTextAntes + ", envío del informe correcto...";
                                        epp.PonerEvento("Informe enviado correctamente");
                                    }
                                    else
                                    {
                                        mObjeto.Text = mObjetoTextAntes + ", envío del informe erróneo...";
                                        epp.PonerEvento("Error al enviar el informe");
                                    }
                                }
                            }
                        }

                        mPulsadoBotonParar = false;

                        // Aquí ya se habrán hecho las copias de seguridad comprimidas o no, entonces se vuelven a activar los botones de acciones
                        DesBloquearBotones();

                        // Se llama a la función de Apagar(), pero solo se apagará si no se ha pulsado en el botón parar
                        // y si el checkbox de parar está marcado.
                        Apagar();
                    }
                }
            }
            else
            {
                ListViewItem it = new ListViewItem("Error: 0", 2);
                it.SubItems.Add("El primer destino de copias no existe -> " + mDestino1);
                mLv.Items.Add(it);
                mErrores++;
                mTsslbl.Text = "Número de errores: " + mErrores.ToString();
                epp.PonerEvento("Error: El primer destino de copias no existe.");
                epp.PonerEvento("Error: La copia comprimida en el destino " + diractual.ToString() + ", ciclo " + sigCiclo.ToString() +
                                        ", no se ha creado.");
                mObjeto.Text = "Error en el proceso de copias, revise los errores...";
            }
        }
        #endregion

        #region Funciones para el siguiente ciclo y crear y añadir al fichero zip

        private string CrearCiclosCopiasCompromidas(int NumDirDestino)
        {
            try
            {
                string nombreArchivoZip = "";
                sigCiclo = 1;
                string destino = "";
                mPrgB.Style = ProgressBarStyle.Marquee;
                mPrgB.MarqueeAnimationSpeed = 20;

                if (Directory.Exists(mDestino1))
                {
                    if (NumDirDestino == 1)
                        destino = mDestino1;
                    else
                        destino = mDestino2;

                    if (NumDirDestino == 1)
                    {
                        if (mUltimoCiclo < mCiclos)
                        {
                            sigCiclo = mUltimoCiclo + 1;
                        }
                        else
                        {
                            sigCiclo = 1;
                        }
                    }
                    else
                    {
                        sigCiclo = mUltimoCiclo;
                    }

                    string fichUltima = destino + "\\Ultima.log";
                    FileStream fs = new FileStream(fichUltima, FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write("La última copia se realizó el día: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() +
                         "\r\nEn el ciclo de copias ...........: Ciclo" + sigCiclo.ToString());
                    sw.Flush();
                    sw.Close();
                    fs.Close();

                    destino += "\\Ciclo" + sigCiclo.ToString();

                    if (!Directory.Exists(destino))
                        Directory.CreateDirectory(destino);

                    if (mPulsadoBotonParar == false)
                    {
                        mObjeto.Text = "Eliminando copias anteriores...";
                        DirectoryInfo dinfo = new DirectoryInfo(destino);
                        foreach (FileInfo fi in dinfo.GetFiles())
                        {
                            //System.Security.AccessControl.FileSecurity fs = new System.Security.AccessControl.FileSecurity(fi.FullName, System.Security.AccessControl.AccessControlSections.All);
                            //fi.SetAccessControl(fs);
                            fi.Delete();
                        }
                    }

                    nombreArchivoZip = destino + "\\BR-Copia" + DateTime.Now.Day.ToString("00") + DateTime.Now.Month.ToString("00") +
                                                    DateTime.Now.Year.ToString() + ".zip";

                    mCom.CommandText = "UPDATE CicloCopias SET ciclo=" + sigCiclo + " WHERE ciclo=" + mUltimoCiclo + ";";
                    mCom.ExecuteNonQuery();

                    mPrgB.Style = ProgressBarStyle.Continuous;
                    mPrgB.Invalidate();
                    Application.DoEvents();

                    return nombreArchivoZip;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                PonerSucesos(ex, null, true, false);
                return "";
            }
        }

        private void CrearArchivoZip(int NumDirDestino)
        {
            try
            {
                //Se pone la constante del objeto zip a la página de códigos actual para el tema de acentos y demás
                ICSharpCode.SharpZipLib.Zip.ZipConstants.DefaultCodePage = System.Globalization.CultureInfo.CurrentCulture.TextInfo.OEMCodePage;
                // Se crea el archivo zip mediante la función NombreArchivo que devuelve el siguiente archivo del ciclo
                zip = new ICSharpCode.SharpZipLib.Zip.ZipOutputStream(File.Create(CrearCiclosCopiasCompromidas(NumDirDestino)));

                zip.UseZip64 = ICSharpCode.SharpZipLib.Zip.UseZip64.Dynamic;
                //zip.UseZip64 = ICSharpCode.SharpZipLib.Zip.UseZip64.Off;

                //Método de compresión (1=Menos... - ...9=Más)
                zip.SetLevel(Convert.ToInt32(Properties.Settings.Default.compresion));
            }
            catch (Exception ex)
            {
                PonerSucesos(ex, null, true, false);
            }
        }

        // Función que va añadiendo los archivos al fichero zip que se le pasan desde la funcion InsertarAlZip
        private void AñadirArchAlArchivoZip(FileInfo fichero)
        {
            if (fichero.Exists)
            {
                FileStream FlujoDatos = null;

                try
                {
                    // Se crea un objeto Zipentry que contiene una nueva entrada en el archivo zip con la ruta completa menos la unidad
                    ICSharpCode.SharpZipLib.Zip.ZipEntry entrada = new ICSharpCode.SharpZipLib.Zip.ZipEntry(fichero.FullName);

                    // Carga de los datos que estan en el fichero al stream
                    FlujoDatos = new FileStream(fichero.FullName, FileMode.Open, FileAccess.Read);

                    // Se dan propiedades de la fecha y el tamaño del fichero al objeto ZipEntry
                    entrada.DateTime = fichero.LastWriteTime;
                    entrada.Size = FlujoDatos.Length;

                    // Comprimimos los datos
                    entrada.CompressionMethod = ICSharpCode.SharpZipLib.Zip.CompressionMethod.Deflated;

                    //se añade el objeto al zip, pero ojo no hay datos, mas abajo se añaden los datos.
                    zip.PutNextEntry(entrada);

                    // A partir de aquí se añaden los datos al objeto ZipEntry
                    long datosleer = FlujoDatos.Length; // Contiene el tamaño del fichero
                    int tamaño; // Esta variable contendrá la lectura de 10000 bytes que se restarán a datosleer
                                // Se crea un buffer de 64000 bytes, se hace así porque byte solo puede contener tipos int32 como máximo
                    byte[] buffer = new byte[64000];

                    PonerSucesos(null, fichero, false, true);

                    // Mientras el tamaño de los datos leidos del filestream sea mayor que 0
                    while (datosleer > 0)
                    {
                        /* Se leen 64000 bytes y se añaden al buffer y tamaño valdrá los 64000 bytes que se leen y el puntero del objeto Stream
                           FlujoDatos se situa al final del tamaño que se lee 64000 bytes */
                        // Se escribe la secuencia de bytes en el buffer del objeto zip y se hace avanzar la posición al número de bytes escritos
                        // Al valor de datosleer que era el tamaño total de los datos se le resta los bits leidos para que cada vez hayan menos
                        // datos que leer hasta que llegue a 0 y se salga del bucle

                        tamaño = FlujoDatos.Read(buffer, 0, 64000);
                        zip.Write(buffer, 0, tamaño);
                        datosleer -= tamaño;
                    }
                    // Se graban los datos fisicamente y se libera el buffer del stream zipstream -> objeto zip
                    zip.Flush();
                    // Se cierra la entrada de datos
                    zip.CloseEntry();
                    // Se cierra el archivo leido para añadir
                    FlujoDatos.Close();
                }
                catch (Exception ex)
                {
                    PonerSucesos(ex, null, true, false);
                }
            }
            else
            {
                Exception ex2 = new Exception("No se encuentra el archivo -> " + fichero.FullName);
                PonerSucesos(ex2, null, true, false);

            }
        }

        public void CerrarArchivoZip()
        {
            try
            {
                zip.Finish();
                zip.Close();
            }
            catch (Exception ex)
            {
                if (mPulsadoBotonParar == false)
                    PonerSucesos(ex, null, true, false);
            }
        }
        #endregion

        #region Aqui se añaden los ficheros al zip
        private void InsertarAlZip()
        {
            try
            {
                ComponerDataReaderDatos();
                /* Mientras que el dr se pueda leer, mientras que existan filas, se leen una por una
                 * Se comprueba si la columna 1 -> directorio está chequeada, si lo está es un directorio
                 * y se leen todos los archivos de éste y se añaden al fichero zip */
                while (dr.Read())
                {
                    if (dr.GetBoolean(1) == true && dr.GetBoolean(2) == false)
                    {
                        DirectoryInfo dir = new DirectoryInfo(dr.GetString(0));
                        if (Directory.Exists(dr.GetString(0)))
                        {
                            foreach (FileInfo fi in dir.GetFiles())
                            {
                                try
                                {
                                    if (mPulsadoBotonParar == false)
                                    {
                                        if (EsUnaExclusion(fi) == false)
                                            AñadirArchAlArchivoZip(fi);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    PonerSucesos(ex, fi, true, false);
                                }
                            }
                        }
                    }
                    /* Si la columna2 -> Recursivo está chequeada se sabe que es un directorio y que hay que es recursivo
                    * por lo tanto se llama a otra función qué leerá todos los archivos de este directorio y el de los sucesivos
                    * Se envía como parámetro el directorio inicial */
                    else if (dr.GetBoolean(1) == true && dr.GetBoolean(2) == true)
                    {
                        DirectoryInfo dir = new DirectoryInfo(dr.GetString(0));
                        if (dir.Exists)
                        {
                            foreach (FileInfo fi in dir.GetFiles())
                            {
                                try
                                {
                                    if (!mPulsadoBotonParar)
                                    {
                                        if (EsUnaExclusion(fi) == false)
                                            AñadirArchAlArchivoZip(fi);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    PonerSucesos(ex, fi, true, false);
                                }
                            }

                            ZipRecursivo(dir.FullName);
                        }
                    }
                    else
                    {
                        // Si no es un directorio ni es recursivo, por cada lectura del datareader dr se añaden las filas al fichero zip
                        if (mPulsadoBotonParar == false)
                        {
                            FileInfo fi = null;

                            try
                            {
                                fi = new FileInfo(dr.GetString(0));
                                if (EsUnaExclusion(fi) == false)
                                    AñadirArchAlArchivoZip(fi);
                            }
                            catch (Exception ex)
                            {
                                PonerSucesos(ex, fi, true, false);
                            }
                        }
                    }
                }

                if (mPulsadoBotonParar)
                {
                    mObjeto.Text = "Copia abortada...";
                }
                else
                {
                    if (mErrores == 0)
                    {
                        mObjeto.Text = "Copia finalizada correctamente...";
                        epp.PonerEvento("La copia comprimida del destino " + diractual.ToString() + ", ciclo " + sigCiclo.ToString() +
                                        ", ha finalizado correctamente.");
                    }
                    else
                    {
                        mObjeto.Text = "Copia finalizada con errores...";
                        epp.PonerEvento("Error: La copia comprimida del destino " + diractual.ToString() + ", ciclo " + sigCiclo.ToString() +
                                        ", ha finalizado con errores.");
                    }
                }
            }
            catch (Exception ex)
            {
                PonerSucesos(ex, null, true, false);
            }
            finally
            {
                CerrarArchivoZip();
                dr.Close();
            }
        }

        // Función para añadir archivos recursivamente a la copia comprimida
        private void ZipRecursivo(string dirinicial)
        {
            try
            {
                foreach (string dir in Directory.GetDirectories(dirinicial))
                {
                    try
                    {
                        DirectoryInfo diri = new DirectoryInfo(dir);

                        foreach (FileInfo fi in diri.GetFiles())
                        {
                            if (mPulsadoBotonParar == false)
                            {
                                try
                                {
                                    if (EsUnaExclusion(fi) == false)
                                        AñadirArchAlArchivoZip(fi);
                                }
                                catch (Exception ex)
                                {
                                    PonerSucesos(ex, fi, true, false);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        PonerSucesos(ex, null, true, false);
                    }

                    ZipRecursivo(dir);
                    Application.DoEvents();
                }
            }
            catch (Exception ex)
            {
                PonerSucesos(ex, null, true, false);
            }
        }
        #endregion

        #region Control de los sucesos de las copias
        private void PonerSucesos(Exception Excepción, FileInfo Fichero, bool AumentarError, bool Avanzar)
        {
            try
            {
                if (AumentarError)
                {
                    if (Properties.Settings.Default.control_errores == true)
                    {
                        if (Excepción.TargetSite.Name.ToLower() != "winioerror")
                        {
                            //Control de error de acceso denegado
                            mErrores++;
                            mTsslbl.Text = "Número de errores: " + mErrores.ToString();
                        }
                    }
                }

                if (Avanzar)
                {
                    mObjeto.Text = Fichero.FullName;
                    mArcActual++;
                    mPrgB.Value = mArcActual;
                    mContador.Text = mArcActual.ToString("#,#") + " / " + mArchivos.ToString("#,#") + " archivos";
                    lblPorcentaje.Text = Convert.ToString(cp.CalcularPorcentajeRestante(mArcActual, mArchivos)) + "%";
                    Application.DoEvents();
                }
                else
                {
                    if (Properties.Settings.Default.control_errores == true)
                    {
                        //Control de error de acceso denegado
                        if (Excepción.TargetSite.Name.ToLower() != "winioerror")
                        {
                            ListViewItem it = new ListViewItem(Excepción.TargetSite.Name, 2);
                            it.SubItems.Add("Error copiando -> " + Fichero.Name + " -> " + Excepción.Message);
                            mLv.Items.Add(it);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region Funciones de Parar y Apagar
        // Ocurre cuando se pulsa el botón parar.
        // Interrumpe la copia y se cierra el archivo zip de la copia
        /* Durante las copias comprimidad o no comprimidas la variable miembro 'mPulsadoBotonParar' controla si se
         * se puede o no se puede seguir copiando archivos, si mPulsadoBotonParar vale false no se siguen copiando
         * archivos, de lo contrario la copia de archivos continua hasta el fin del bucle */
        public void Parar()
        {
            mObjeto.Text = "Cancelando el proceso de copias, espere...";

            // mPulsadoBotonParar se pone a true para interrumpir la copia y que no se pueda apagar
            mPulsadoBotonParar = true;

            // Se pone el evento de empezar copia en la base de datos
            epp.PonerEvento("El usuario ha cancelado el proceso de copia.");
        }

        //Función que apaga el equipo cuando termina la copia
        private void Apagar()
        {
            try
            {
                // Si no se ha pulsado el boton parar
                if (mPulsadoBotonParar == false)
                {
                    // Si el checkbox de apagar está marcado
                    if (mChkApagar.Checked)
                    {
                        epp.PonerEvento("Backup&Restore ha apagado el equipo.");

                        if (mCon != null)
                        {
                            if (mCon.State == ConnectionState.Open)
                            {
                                mCon.Close();
                            }
                        }

                        ProcessStartInfo startInfo = new ProcessStartInfo("shutdown.exe", "-s -f -t 0");
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.UseShellExecute = false; //No utiliza RunDLL32 para lanzarlo
                                                           //Redirige las salidas y los errores
                        startInfo.RedirectStandardOutput = true;
                        startInfo.RedirectStandardError = true;
                        Process proc = Process.Start(startInfo); //Ejecuta el proceso
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Comprobar archivos excluidos
        private bool EsUnaExclusion(FileInfo fichero)
        {
            bool excluir = false;

            if (Properties.Settings.Default.exclusiones.Length != 0)
            {
                string[] arrExtensiones = Properties.Settings.Default.exclusiones.Split(' ');

                foreach (string extension in arrExtensiones)
                {
                    if (fichero.Extension.ToLower() == extension.ToLower())
                    {
                        excluir = true;
                        break;
                    }
                }
            }

            return excluir;
        }
        #endregion

        public bool HayErrores()
        {
            if (Properties.Settings.Default.control_errores)
            {
                if (mLv.Items.Count == 0)
                    return false;
                else
                    return true;
            }
            else
                return false;
        }
    }
}