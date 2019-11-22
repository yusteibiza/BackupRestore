/* --------------------------------------------------------------------
 * Clase para las copias de seguridad sin comprimir
 * 
 * Esquema...
 *      - Esta clase se inicia mediante el método público EmpezarCopia()
 *      - Esto hace que se invoque a los métodos...
 *          1º) PonerACero() -> que pone toda la información de la
 *              ventana de copias y variables a los valores por defecto.
 *          2º) PoblarCampos() -> que lee todas las opciones de las
 *              copias y las mete en variables privadas a la clase
 *          3º) Calcular() -> que calcula el número de archivos que se
 *              va a incluir en la copia y devuelve 1 o 0 dependiendo de
 *              si el archivo o directorio almacenado en las opciones ha
 *              cambiado de nombre, se ha movido o se ha borrado por lo
 *              que en este caso devolvera 0 y la copia no se iniciará
 *              mostrando un error y devolvera 1 si está todo correcto.
 *          4º) CrearCiclosCopias(x) -> Crea el siguiente ciclo que le 
 *              corresponda a la siguiente copia y devuelve un string 
 *              que contiene el lugar de destino de la siguiente copia
 *              y que se guarda en la varible miembro pathCopias o 
 *              devuelve "" "nada" si el destino no existe o se ha movido
 *              por lo que entonces tampoco se iniciará la copia.
 *          5º) Copiar(x) -> empieza la copia de archivos, llamando en
 *              el caso que convenga a los métodos... CopiarArchivo(),
 *              CopiarDir(), CopiarTodosDirs(), estos métodos también
 *              comprueba que existan directorios y archivos origenes y
 *              crean y copian los directorios y archivos origen en su
 *              correspondiente destino.
 * --------------------------------------------------------------------- */

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
    class CopiaSinComprimir
    {
        #region Controladores de eventos y Eventos
        public delegate void CopiaInciadaEventHandler();
        public event CopiaInciadaEventHandler CopiaIniciada;
        public delegate void CopiaFinalizadaEventHandler();
        public event CopiaFinalizadaEventHandler CopiaFinalizada;
        #endregion

        #region Variables Miembro
        DateTime fechaHoraInicio;
        private OleDbConnection mCon;
        private OleDbCommand mCom;
        private OleDbDataReader dr;
        private int mCiclos;
        private string mDestino1, mDestino2, pathCopias;
        private ListView mLv;
        private ToolStripStatusLabel mTsslbl;
        private int mErrores;
        private int mArchivos;
        private Label mContador;
        private ProgressBar mPrgB;
        private Label mObjeto;
        private bool mPulsadoBotonParar;
        private KryptonButton mBotonConfigurar, mBotonEmpezar, mBotonParar, mBotonSalir;
        private CheckBox mChkApagar;
        private int mUltimoCiclo;
        private EventosApp epp;
        private Label lblDirectorioCopias, lblCiclo, lblPorcentaje;
        private int mArcActual;
        int diractual;
        int sigCiclo;
        int numAvisos;
        CalcularPorcentaje cp;
        #endregion

        #region Constructor
        public CopiaSinComprimir(Label LabelCiclo, ListView ListViewErrores, ToolStripStatusLabel ToolStripStatusLabel, Label lblContador, ProgressBar BarraProgreso, Label Objeto,
                       KryptonButton BotonConfigurar, KryptonButton BotonEmpezar, KryptonButton BotonParar, KryptonButton BotonSalir, CheckBox CheckApagar, Label labelDestCopia, Label labelPorcentaje)
        {
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

        #region PonerCiclo
        public void PonerCiclo(bool VieneDeConfiguración)
        {
            if (Directory.Exists(mDestino1))
            {
                if (VieneDeConfiguración == false)
                {
                    sigCiclo = mUltimoCiclo + 1;

                    if (mUltimoCiclo < mCiclos)
                        lblCiclo.Text = "Último ciclo: " + Convert.ToString(sigCiclo) + " / " + mCiclos.ToString();
                    else
                        lblCiclo.Text = "Últmimo ciclo: 1 / " + mCiclos.ToString();
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
                    cp.TotalArchivos = mArchivos;
                    lblPorcentaje.Text = "0%";
                    mContador.Text = "0 / " + mArchivos.ToString("#,#") + " archivos";
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
                Console.WriteLine(ex.Message);
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

        // Poner todos los contadores y variables a cero para empezar la copia.
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

        #region Función para empezar a copiar
        public void EmpezarCopia()
        {
            if (Directory.Exists(mDestino1))
            {
                try
                {
                    fechaHoraInicio = DateTime.Now;

                    CopiaIniciada();
                    PonerACero();
                    PonerCiclo(false);

                    // Carga los datos de la configuración y devuelve 1 si el destino1 existe
                    if (PoblarCampos() == 1)
                    {
                        // Se calcula el total de archivos de la copia y se devuelve 1 si hay algo que copiar y las rutas existen, creado en la configuración
                        if (Calcular() == 1)
                        {

                            // Si existe el destino 1 se crea el archivo siguiente del ciclo, el 1 es un número que indica en que destino hacer las copias
                            if (CrearCiclosCopias(1) != "")
                            {
                                Copiar(1);

                                // Si hay algo en el campo destino2 y es un directorio crearlo tambien los ciclos de copias...
                                if (Directory.Exists(mDestino2))
                                {
                                    if (mPulsadoBotonParar == false)
                                    {
                                        CrearCiclosCopias(2);
                                        PonerACero();
                                        diractual++;
                                        lblDirectorioCopias.Text = "Destino de copia: 2/2";
                                        Copiar(2);
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
                                epp.PonerEvento("Error: La copia no comprimida en el destino " + diractual.ToString() + ", ciclo " + sigCiclo.ToString() +
                                                ", no se ha creado.");
                                mObjeto.Text = "Error en el proceso de copias, revise los errores...";
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
                            epp.PonerEvento("Error: La copia no comprimida en el destino " + diractual.ToString() + ", ciclo " + sigCiclo.ToString() +
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
                        epp.PonerEvento("Error: La copia no comprimida en el destino " + diractual.ToString() + ", ciclo " + sigCiclo.ToString() +
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
                                estado = Emails.EnviarInforme(Emails.ResultadoCopia.OK, "- Tipo de copia ".PadRight(24, '.') + ": " + "Sin comprimir\n" +
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
                                estado = Emails.EnviarInforme(Emails.ResultadoCopia.Error, "- Tipo de copia ".PadRight(24, '.') + ": " + "Sin comprimir\n" +
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
            else
            {
                ListViewItem it = new ListViewItem("Error: 0", 2);
                it.SubItems.Add("El primer destino de copias no existe -> " + mDestino1);
                mLv.Items.Add(it);
                mErrores++;
                mTsslbl.Text = "Número de errores: " + mErrores.ToString();
                epp.PonerEvento("Error: El primer destino de copias no existe.");
                epp.PonerEvento("Error: La copia no comprimida en el destino " + diractual.ToString() + ", ciclo " + sigCiclo.ToString() +
                                        ", no se ha creado.");
                mObjeto.Text = "Error en el proceso de copias, revise los errores...";
            }
        }
        #endregion

        #region Funciones para el siguiente ciclo y crear y añadir el directorio siguiente

        private string CrearCiclosCopias(int NumDirDestino)
        {
            mPrgB.Style = ProgressBarStyle.Marquee;
            mPrgB.MarqueeAnimationSpeed = 20;
            string destino = "";
            sigCiclo = 1;
            string path;

            if (mPulsadoBotonParar == false)
            {
                mObjeto.Text = "Reorganizando ciclos de copias en el destino " + NumDirDestino.ToString() + ", espere...";

                if (Directory.Exists(mDestino1))
                {
                    if (NumDirDestino == 1)
                        destino = mDestino1;
                    else
                        destino = mDestino2;

                    if (mUltimoCiclo < mCiclos)
                    {
                        sigCiclo = mUltimoCiclo + 1;
                    }
                    else
                    {
                        sigCiclo = 1;
                    }

                    string fichUltima = destino + "\\Ultima.log";
                    FileStream fs = new FileStream(fichUltima, FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write("La última copia se realizó el día: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() +
                           "\r\nEn el ciclo de copias ...........: Ciclo" + sigCiclo.ToString());
                    sw.Flush();
                    sw.Close();
                    fs.Close();

                    path = destino + "\\Ciclo" + Convert.ToString(sigCiclo);

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    dr.Close();
                    mCom.CommandText = "UPDATE CicloCopias SET ciclo=" + sigCiclo + " WHERE ciclo=" + mUltimoCiclo + ";";
                    mCom.ExecuteNonQuery();
                }
                else
                {
                    path = "";
                }
            }
            else
            {
                path = "";
            }

            pathCopias = path;
            mPrgB.Style = ProgressBarStyle.Continuous;
            mPrgB.Invalidate();
            Application.DoEvents();

            return path;
        }
        #endregion

        #region Funciones para Copiar
        private void Copiar(int NumDestino)
        {
            ComponerDataReaderDatos();
            DirectoryInfo dirD = new DirectoryInfo(pathCopias);
            DirectoryInfo dirO = null;

            try
            {
                while (dr.Read())
                {
                    // Si es Directorio y no es recursivo
                    if (dr.GetBoolean(1) == true && dr.GetBoolean(2) == false)
                    {
                        dirO = new DirectoryInfo(dr.GetString(0));

                        if (mPulsadoBotonParar == false)
                        {
                            CopiarDir(dirO, dirD, false);
                        }
                    }
                    // Si es Directorio y es recursivo
                    else if (dr.GetBoolean(1) == true && dr.GetBoolean(2) == true)
                    {
                        dirO = new DirectoryInfo(dr.GetString(0));
                        if (mPulsadoBotonParar == false)
                        {
                            CopiarDir(dirO, dirD, true);
                        }
                    }
                    else
                    {
                        // Si no es un directorio ni es recursivo, por cada lectura del datareader dr se añaden las filas al fichero zip
                        if (mPulsadoBotonParar == false)
                        {
                            DirectoryInfo dirOArch = new DirectoryInfo(dr.GetString(0));
                            DirectoryInfo dirDestArch = new DirectoryInfo(pathCopias);
                            CopiarArchivo(dirOArch.Parent, dirDestArch, dr.GetString(0));
                        }
                    }
                }

                if (mPulsadoBotonParar)
                {
                    mObjeto.Text = "Copia abortada...";
                }
                else
                {
                    if (mLv.Items.Count == 0)
                    {
                        mObjeto.Text = "Copia finalizada correctamente...";
                        epp.PonerEvento("La copia no comprimida del destino " + diractual.ToString() + ", ciclo " + sigCiclo.ToString() +
                                        ", ha finalizado correctamente.");
                    }
                    else
                    {
                        mObjeto.Text = "Copia finalizada con errores...";
                        epp.PonerEvento("Error: La copia no comprimida en el destino " + diractual.ToString() + ", ciclo " + sigCiclo.ToString() +
                                            ", ha finalizado con errores.");
                    }
                }
            }
            catch (Exception ex)
            {
                PonerSucesos(ex, null, true, false);
            }

            dr.Close();
        }

        private void CopiarArchivo(DirectoryInfo DirOrigen, DirectoryInfo DirDestino, string Fichero)
        {
            string DirInicial;

            if (!DirOrigen.FullName.Contains(@"\\"))
            {
                DirInicial = "\\Disco_" + DirOrigen.Root.Name.Remove(1, 2) + "\\";
            }
            else
            {
                DirInicial = "\\Red\\";
            }

            //Copiar todos los ficheros en el nuevo directorio.
            DirectoryInfo dirDestArch = new DirectoryInfo(DirDestino.FullName + DirInicial + DirOrigen.FullName.Remove(0, 2));
            try
            {
                if (Directory.Exists(dirDestArch.FullName) == false) //&& DirOrigen.GetFiles().Length != 0)
                {
                    Directory.CreateDirectory(dirDestArch.FullName);
                }

                FileInfo fi = new FileInfo(Fichero);

                if (fi.Exists)
                {
                    if (Directory.Exists(dirDestArch.FullName)) //== false && DirOrigen.GetFiles().Length != 0)
                    {
                        Directory.CreateDirectory(dirDestArch.FullName);
                    }

                    if (!mPulsadoBotonParar)
                    {
                        PonerSucesos(null, fi, false, true);
                        File.Copy(fi.FullName, dirDestArch.FullName + "\\" + fi.Name, true);
                    }
                }
                else
                {
                    PonerSucesos(null, fi, true, false);
                }
            }
            catch (Exception ex)
            {
                PonerSucesos(ex, null, true, false);
            }
        }

        private void CopiarDir(DirectoryInfo DirOrigen, DirectoryInfo DirDestino, bool Recursivo)
        {
            string DirInicial;

            if (!DirOrigen.FullName.Contains(@"\\"))
            {
                DirInicial = "\\Disco_" + DirOrigen.Root.Name.Remove(1, 2) + "\\";
            }
            else
            {
                DirInicial = "\\Red\\";
            }

            //Copiar todos los ficheros en el nuevo directorio.
            DirectoryInfo dirDestDir = new DirectoryInfo(DirDestino.FullName + DirInicial + DirOrigen.FullName.Remove(0, 2));

            try
            {
                if (Directory.Exists(dirDestDir.FullName) == false) //&& DirOrigen.GetFiles().Length != 0)
                {
                    Directory.CreateDirectory(dirDestDir.FullName);
                }

                if (Recursivo == false)
                {
                    foreach (FileInfo fi in DirOrigen.GetFiles())
                    {
                        if (!mPulsadoBotonParar)
                        {
                            try
                            {
                                if (fi.Exists)
                                {
                                    if (EsUnaExclusion(fi) == false)
                                    {
                                        PonerSucesos(null, fi, false, true);
                                        File.Copy(fi.FullName, dirDestDir.FullName + "\\" + fi.Name, true);
                                    }
                                }
                                else
                                {
                                    PonerSucesos(null, fi, true, false);
                                }
                            }
                            catch (Exception ex)
                            {
                                PonerSucesos(ex, null, true, false);
                            }
                        }
                    }
                }
                else
                {
                    CopiarTodosDirs(DirOrigen, dirDestDir);
                }
            }
            catch (Exception ex)
            {
                PonerSucesos(ex, null, true, false);
            }
        }

        private void CopiarTodosDirs(DirectoryInfo DirOrigen, DirectoryInfo DirDestino)
        {

            // Comprobar si existe el directorio origen, si no, crearlo.
            if (Directory.Exists(DirDestino.FullName) == false)
            {
                Directory.CreateDirectory(DirDestino.FullName);
            }

            try
            {
                // Copiar todos los ficheros en el nuevo directorio.
                foreach (FileInfo fi in DirOrigen.GetFiles())
                {
                    if (!mPulsadoBotonParar)
                    {
                        try
                        {
                            if (EsUnaExclusion(fi) == false)
                            {
                                PonerSucesos(null, fi, false, true);
                                File.Copy(fi.FullName, DirDestino.FullName + "\\" + fi.Name, true);
                            }
                        }
                        catch (Exception ex)
                        {
                            PonerSucesos(ex, null, true, false);
                        }
                    }
                }
                // Copiar todos los subdirectorios usando recursividad.
                foreach (DirectoryInfo diOrigenSubDir in DirOrigen.GetDirectories())
                {
                    if (!mPulsadoBotonParar)
                    {
                        DirectoryInfo siguienteSubdirectorio = DirDestino.CreateSubdirectory(diOrigenSubDir.Name);
                        CopiarTodosDirs(diOrigenSubDir, siguienteSubdirectorio);
                    }
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
                        //Control de error de acceso denegado
                        if (Excepción.TargetSite.Name.ToLower() != "winioerror")
                        {
                            mTsslbl.Text = "Número de errores: " + mErrores.ToString();
                            ListViewItem it = new ListViewItem("Error copiando -> ");
                            it.SubItems.Add(Excepción.Message);
                            mLv.Items.Add(it);
                        }
                    }
                }

                if (Avanzar)
                {
                    mArcActual++;
                    mObjeto.Text = Fichero.FullName;
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
                            ListViewItem it = new ListViewItem("Error copiando -> ");
                            it.SubItems.Add(Excepción.Message);
                            mLv.Items.Add(it);
                        }
                    }
                }

                if (mPulsadoBotonParar)
                {
                    if (Properties.Settings.Default.control_errores == false)
                    {
                        if (mErrores != 0)
                        {
                            mLv.Items.Clear();
                            mTsslbl.Text = "Número de errores: 0";
                            mPrgB.Value = mPrgB.Maximum;
                            lblPorcentaje.Text = "100%";
                            mContador.Text = mArchivos.ToString("#,#") + " / " + mArchivos.ToString("#,#") + " archivos";
                            mLv.BackColor = Color.LightSalmon;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                mTsslbl.Text = "Número de errores: " + mLv.Items.Count.ToString();
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
                PonerSucesos(ex, null, false, false);
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
