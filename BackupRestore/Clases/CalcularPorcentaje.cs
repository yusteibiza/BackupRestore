using System;
using System.Collections.Generic;
using System.Text;

namespace BackupRestore
{
    public class CalcularPorcentaje
    {
        private int copiandoActualmente, totalArchivos;

        public CalcularPorcentaje(int CopiandoActualmente, int TotalArchivos)
        {
            copiandoActualmente = CopiandoActualmente; totalArchivos = TotalArchivos;
        }

        public int CalcularPorcentajeRestante(int CopiandoActualmente, int TotalArchivos)
        {
            return Convert.ToInt32((CopiandoActualmente * 100) / TotalArchivos);
        }

        public int CopiandoActualmente
        {
            get { return copiandoActualmente; }
            set { copiandoActualmente = value; }
        }

        public int TotalArchivos
        {
            get { return totalArchivos; }
            set { totalArchivos = value; }
        }
    }
}
