using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Security.Permissions;
using Microsoft.Win32.TaskScheduler;

namespace BackupRestore
{
    static class Program
    {
        /// <summary>

        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
        static void Main(string[] parametros)
        {
            #region Para cazar los errores al inicio de la aplicación
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledException);
            #endregion

            Application.EnableVisualStyles();
            bool copiar = false;

            //Comprobar si ya se está ejecutando la aplicación. --------------------
            Process[] procesoBackupAndRestore = Process.GetProcessesByName("Backup&Restore");
            if (procesoBackupAndRestore.Length > 1)
            {
                MessageBox.Show("La aplicación " + Process.GetCurrentProcess().ProcessName + " ya se está ejecuando."
                               , "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }
            //----------------------------------------------------------------------

            if (parametros.Length != 0)
            {
                if (parametros.Length == 1 & parametros[0].ToLower() == "/ocultar")
                {
                    MessageBox.Show("Parámetro /ocultar necesita del parámetro /ocultar", "Aviso", MessageBoxButtons.OK,
                                     MessageBoxIcon.Information);
                    Environment.Exit(0);
                }
            }

            Properties.Settings.Default.apagar = false;
            string datos = string.Empty;
            bool segundoPlano = false;

            foreach (string valor in parametros)
            {
                if (valor.ToLower() == "/ocultar")
                {
                    segundoPlano = true;
                }
                else if (valor.ToLower() == "/apagar")
                {
                    Properties.Settings.Default.apagar = true;
                }
                else if (valor.ToLower() == "/copiar")
                {
                    copiar = true;
                }
            }

            if (copiar)
            {
                //TaskService taskService = new TaskService("\\localhost");
                //var task = taskService.RootFolder.GetTasks().Where(a => a.Name == "NameOfApplication").FirstOrDefault();

                frmCopiar frmc = null;

                if (segundoPlano)
                {
                    frmc = new frmCopiar(true);
                }
                else
                {
                    frmc = new frmCopiar(false);
                }

                frmc.TopLevel = true;
                frmc.Select();
                frmc.BringToFront();
                frmc.Show();
                Application.DoEvents();
                frmc.EmpezarCopia();
            }
            else
            {
                Application.Run(new frmInicial());
            }
        }

        #region  Controladores de errores de la aplicación
        private static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Debug.WriteLine((e.ExceptionObject as Exception).Message);
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Debug.WriteLine(e.Exception.Message);
        }
        #endregion
    }
}
