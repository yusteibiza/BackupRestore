using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace BackupRestore
{
    class EventosApp
    {
        OleDbConnection con;
        OleDbCommand com;

        string dbase;
        string strcon;

        private string Usuario = System.Environment.UserName;
        private string Equipo = System.Environment.MachineName;

        public EventosApp()
        {
            dbase = Application.StartupPath + "\\Datos.mdb";
            strcon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbase + ";User Id=admin;Password=;";
            con = new OleDbConnection(strcon);
            com = new OleDbCommand("", con);
        }

        public void PonerEvento(string TextoEvento)
        {
            Int64 maximo;

            try
            {
                con.Open();
                com.CommandText = "SELECT MAX(Código) FROM logs;";

                if (com.ExecuteScalar() == DBNull.Value) // ExecuteScalar() -> Devuelve la primera columan y la primera fila de la consulta.
                    maximo = 1;
                else
                    maximo = Convert.ToInt64(com.ExecuteScalar()) + 1;

                com.CommandText = "INSERT INTO Logs (Código,fecha,evento,equipo,usuario) values (" + maximo + ",'" + DateTime.Now.ToString() +
                                    "','" + TextoEvento + "','" + Equipo + "','" + Usuario + "');";
                com.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Source + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con != null)
                    if (con.State == ConnectionState.Open)
                        con.Close();
            }
        }
    }
}
