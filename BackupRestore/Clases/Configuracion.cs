using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace BackupRestore
{
    class Configuracion
    {
        public class LeerConfig
        {
            private OleDbConnection mCon;
            private OleDbCommand mCmd;
            private OleDbDataReader mDr;
            private DataTable dt;
            private string mDestino1;
            private string mDestino2;
            private bool mComprimir;
            private int mCiclos;
            private object[] mDatos;
            private string mCadenaCon;

            public LeerConfig()
            {
            }

            public LeerConfig(string CadenaConexión)
            {
                try
                {
                    mCadenaCon = CadenaConexión;
                    mCon = new OleDbConnection(CadenaConexión);
                    mCon.Open();
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            ~LeerConfig()
            {
                mCon.Close();
            }

            public void Leer()
            {

                try
                {
                    if (mCon != null)
                    {
                        if (mCon.State == ConnectionState.Closed)
                        {
                            mCon.Open();
                        }
                    }
                    else
                    {
                        mCon = new OleDbConnection(mCadenaCon);
                        mCon.Open();
                    }
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (mCadenaCon != null)
                {
                    try
                    {
                        mCmd = new OleDbCommand("SELECT * FROM opciones;", mCon);
                        mDr = mCmd.ExecuteReader();

                        if (mDr.Read())
                        {
                            if (mDr.GetBoolean(1) == true)
                            {
                                mComprimir = true;
                            }
                            else
                            {
                                mComprimir = false;
                            }

                            mCiclos = mDr.GetInt32(2);
                        }

                        mDr.Close();

                        mCmd.CommandText = "SELECT * FROM destinos;";
                        mDr = mCmd.ExecuteReader();

                        if (mDr.Read())
                        {
                            mDestino1 = mDr.GetString(1);
                            mDestino2 = mDr.GetString(2);
                        }

                        mDr.Close();

                        mCmd.CommandText = "SELECT * FROM datos;";
                        mDr = mCmd.ExecuteReader();

                        dt = new DataTable("Datos");
                        dt.Columns.Add("Path", Type.GetType("System.String"));
                        dt.Columns.Add("Directorio", Type.GetType("System.Boolean"));
                        dt.Columns.Add("Recursivo", Type.GetType("System.Boolean"));
                        mDatos = new object[mDr.FieldCount];

                        while (mDr.Read())
                        {
                            mDatos[0] = mDr.GetString(0);
                            mDatos[1] = mDr.GetBoolean(1);
                            mDatos[2] = mDr.GetBoolean(2);
                            dt.Rows.Add(mDatos);
                        }

                        mDr.Close();
                        mCon.Close();
                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    throw new Exception("No se ha especificado la cadena de conexión");
                }
            }

            public bool Comprimir
            {
                get
                {
                    return mComprimir;
                }
            }

            public int Ciclos
            {
                get
                {
                    return mCiclos;
                }
            }

            public string Destino1
            {
                get
                {
                    return mDestino1;
                }
            }

            public string Destino2
            {
                get
                {
                    return mDestino2;
                }
            }

            public DataTable TablaDeDatos
            {
                get
                {
                    return dt;
                }
            }

            public string CadenaConexión
            {
                set
                {
                    mCadenaCon = value;
                }
            }
        }

        public class GuardarConfig
        {
            private OleDbConnection mCon;
            private OleDbCommand mCmd;
            private DataTable mDt;
            private string mCadenaCon;
            private Form mFormPadre;
            private string mDestino1;
            private string mDestino2;
            private bool mComprimir;
            private int mCiclos;

            public GuardarConfig()
            {
            }

            public GuardarConfig(string CadenaConexión)
            {
                mCadenaCon = CadenaConexión;
            }

            public GuardarConfig(string CadenaConexión, DataTable TablaDeDatos)
            {
                mCadenaCon = CadenaConexión;
                mDt = TablaDeDatos;
            }

            public GuardarConfig(string CadenaConexión, DataTable TablaDeDatos, Form FormularioPadre)
            {
                mCadenaCon = CadenaConexión;
                mDt = TablaDeDatos;
                mFormPadre = FormularioPadre;
            }

            ~GuardarConfig()
            {
                mCon.Close();
            }

            public void Guardar()
            {
                try
                {
                    mCon = new OleDbConnection(mCadenaCon);
                    mCmd = new OleDbCommand("", mCon);
                    mCon.Open();

                    frmGuardando frmg = new frmGuardando();
                    frmg.StartPosition = FormStartPosition.CenterScreen;
                    frmg.ValorMaxProgreso = mDt.Rows.Count;
                    frmg.Show();
                    Application.DoEvents();

                    mCmd.CommandText = "DELETE * FROM Opciones;";
                    mCmd.ExecuteNonQuery();
                    mCmd.CommandText = "DELETE * FROM Destinos";
                    mCmd.ExecuteNonQuery();
                    mCmd.CommandText = "DELETE * FROM Datos;";
                    mCmd.ExecuteNonQuery();

                    mCmd.CommandText = "INSERT INTO Opciones (Comprimir,Ciclos) Values (" + mComprimir + "," + mCiclos + ");";
                    mCmd.ExecuteNonQuery();

                    mCmd.CommandText = "INSERT INTO Destinos (Destino_1,Destino_2) Values ('" + mDestino1 + "','" + mDestino2 + "');";
                    mCmd.ExecuteNonQuery();

                    foreach (Control c in mFormPadre.Controls)
                    {
                        c.Enabled = false;
                    }

                    int x = 1;

                    foreach (DataRow dr in mDt.Rows)
                    {
                        frmg.ValorActualProgreso = x;
                        string path = dr[0].ToString();
                        bool dir = (bool)dr[1];
                        bool rec = (bool)dr[2];
                        mCmd.CommandText = "INSERT INTO Datos (Path,Directorio,Recursivo) VALUES " +
                                           "('" + path + "'," + dir + "," + rec + ");";
                        mCmd.ExecuteNonQuery();
                        x++;
                    }
                    mCon.Close();
                    
                    DateTime tiempoahora = DateTime.Now;
                    DateTime tiempodespues = tiempoahora.AddSeconds(2);
                 
                    while (tiempoahora <= tiempodespues)
                    {
                        tiempoahora = DateTime.Now;
                        Application.DoEvents();
                    }
                    frmg.Close();
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            public string CadenaConexion
            {
                set
                {
                    mCadenaCon = value;
                }
            }

            public DataTable TablaDeDatos
            {
                set
                {
                    mDt = value;
                }
            }

            public Form FormularioPadre
            {
                set
                {
                    mFormPadre = value;
                }
            }

            public bool Comprimir
            {
                set
                {
                    mComprimir = value;
                }
            }

            public int Ciclos
            {
                set
                {
                    mCiclos = value;
                }
            }

            public string Destino1
            {
                set
                {
                    mDestino1 = value;
                }
            }

            public string Destino2
            {
                set
                {
                    mDestino2 = value; ;
                }
            }
        }
    }
}