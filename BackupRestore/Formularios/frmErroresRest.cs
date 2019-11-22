using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BackupRestore
{
    public partial class frmErroresRest : Form
    {
        string titulo = string.Empty;

        public frmErroresRest(ArrayList ArrayDeErrores, string Titulo)
        {
            InitializeComponent();
            titulo = Titulo;
            this.label1.Text = titulo;

            if (ArrayDeErrores.Count != 0)
                for (int x = 0; x <= ArrayDeErrores.Count - 1; x++)
                {
                    lbErrores.Items.Add(ArrayDeErrores[x].ToString());
                }

            lblTotal.Text = "Total errores: " + lbErrores.Items.Count.ToString();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SaveFileDialog sdlg = new SaveFileDialog();
            sdlg.Filter = "Archivo de texto (*.txt)|*.txt|Archivo de información (*.log)|*.log";
            sdlg.ShowHelp = true;
            sdlg.FileName = "BR-Errores.txt";
            if (sdlg.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(sdlg.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(titulo + "\n[ " + DateTime.Now.ToLongDateString() + " ]");
                sw.WriteLine("------------------------------------------------------------------------\n");

                for (int x = 0; x <= lbErrores.Items.Count - 1; x++)
                {
                    sw.WriteLine("[*] " + lbErrores.Items[x].ToString());
                }

                sw.WriteLine("");
                sw.Write("-Total errores: " + lbErrores.Items.Count.ToString() + "\n\n-=[Fin del archivo]=-");
                sw.Flush();
                sw.Close();
                fs.Close();
            }
        }
    }
}