using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BackupRestore
{
    class VerListView
    {
        ListView _lv;
        public delegate void MostrarView(string Mensaje);
        public event MostrarView Mostrar;

        public VerListView(ListView ControlLista)
        {
            _lv = ControlLista;
            System.Threading.Thread hiloMostrar = new System.Threading.Thread(HiloEventoMostrar);
            hiloMostrar.Start();
        }

        private void HiloEventoMostrar()
        {
            while (true)
            {
                try
                {
                    _lv.Visible = true;
                    Mostrar("Se ha hecho visible el control.");
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
