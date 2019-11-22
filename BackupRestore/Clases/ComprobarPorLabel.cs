using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BackupRestore
{
    public static class ComprobarPorLabel
    {
        public static string UnidadCopias(string Destino)
        {
            if (Destino != null & Destino != string.Empty & !System.IO.Directory.Exists(Destino) )
            {
                string destino = Destino.Remove(0, 1);
                string ruta = null;
                string[] letras = Environment.GetLogicalDrives();

                foreach (string unidad in letras)
                {
                    try
                    {
                        DriveInfo di = new DriveInfo(unidad);

                        if (!unidad.StartsWith("a:", StringComparison.OrdinalIgnoreCase) & !unidad.StartsWith("b:", StringComparison.OrdinalIgnoreCase))
                        {
                            if (di.VolumeLabel.ToLower() == Properties.Settings.Default.label_disco.ToLower())
                            {
                                ruta = di.RootDirectory.Name.Remove(1, 2) + destino;
                                break;
                            }
                        }
                    }
                    catch (System.IO.IOException ioex)
                    {
                        Console.WriteLine(ioex.Message);
                    }
                }

                if (ruta != null & !Directory.Exists(ruta))
                    Directory.CreateDirectory(ruta);

                return ruta;
            }
            else
            {
                return Destino;
            }
        }
    }
}
