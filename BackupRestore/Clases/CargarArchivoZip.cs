using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace BackupRestore
{
    class CargarArchivoZip : System.Collections.Generic.List<ListViewItem>
    {
        public CargarArchivoZip()
        {
        }

        public CargarArchivoZip(ListViewItem item)
        {
            this.Add(item);
        }
    }
}
