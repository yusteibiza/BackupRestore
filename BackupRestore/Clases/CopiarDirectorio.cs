using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BackupRestore
{
    public class CopiarDirectorio
    {
        public static void Copiar(string DirectorioOrigen, string DirectorioDestino)
        {
            DirectoryInfo diOrigen = new DirectoryInfo(DirectorioOrigen);
            DirectoryInfo diDestino = new DirectoryInfo(DirectorioDestino);

            CopiarTodo(diOrigen, diDestino);
        }

        public static void CopiarTodo(DirectoryInfo Origen, DirectoryInfo Destino)
        {
            // Comprobar si existe el directorio origen, si no, crearlo.
            if (Directory.Exists(Destino.FullName) == false)
            {
                Directory.CreateDirectory(Destino.FullName);
            }

            // Copiar todos los ficheros en el nuevo directorio.
            foreach (FileInfo fi in Origen.GetFiles())
            {
                fi.CopyTo(Path.Combine(Destino.ToString(), fi.Name), true);
            }

            // Copiar todos los subdirectorios usando recursividad.
            foreach (DirectoryInfo diOrigenSubDir in Origen.GetDirectories())
            {
                DirectoryInfo siguienteSubdirectorio = Destino.CreateSubdirectory(diOrigenSubDir.Name);
                CopiarTodo(diOrigenSubDir, siguienteSubdirectorio);
            }
        }
    }
}
