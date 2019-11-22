using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace BackupRestore
{
    public static class Emails
    {
        public enum ResultadoCopia { OK, Error };

        public static bool Probar(string Destinatario, string ServidorSMTP, int Puerto,
                                  string Usuario, String Password, bool ConexionSSL)
        {
            try
            {
                MailMessage mm = new MailMessage("pruebas@backuprestore.com", Destinatario);
                mm.Subject = "Prueba de Backup&Restore";
                mm.Body = "Este es un mensaje de prueba de Backup&Restore";

                SmtpClient smtp = new SmtpClient(ServidorSMTP, Puerto);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(Usuario, Password);
                smtp.Host = ServidorSMTP;
                smtp.Port = Puerto;
                if (ConexionSSL)
                    smtp.EnableSsl = true;
                smtp.Timeout = 20000;
                smtp.Send(mm);

                return true;
            }
            catch (Exception ex)
            {
                // System.Windows.Forms.MessageBox.Show(ex.Message+"\nUsuario: " +Usuario+"\n"+"Pass: "+Password+"\nPuerto: " + Puerto+"\nServidor: "+ServidorSMTP+"\nSSL :" + ConexionSSL);
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static int EnviarInforme(ResultadoCopia ResultadoDeLaCopia, string TextoDelMensaje)
        {
            try
            {
                MailMessage mm = new MailMessage("backuprestore@backuprestore.com ",
                                                Properties.Settings.Default.prgDestinatario);
                mm.Subject = "Resultado de la copia de Backup&Restore";

                if (ResultadoDeLaCopia == ResultadoCopia.OK)
                    mm.Body = "Informe de la copia de seguridad de Backup&Restore\n" +
                              "-----------------------------------------------------------------------\n\n" +
                              "- Resultado ... [ OK ]\n\n" + TextoDelMensaje + "\n\n";
                else
                    mm.Body = "Informe de la copia de seguridad de Backup&Restore\n" +
                              "-----------------------------------------------------------------------\n\n" +
                              "- Resultado ... [ ERROR ]\n\n" + TextoDelMensaje + "\n\n";

                SmtpClient smtp = new SmtpClient(Properties.Settings.Default.prgServSMTP,
                                                (int)Properties.Settings.Default.prgPuertoSMTP);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(Properties.Settings.Default.prgUsuarioSMTP,
                                                Properties.Settings.Default.prgPasswordSMTP);
                smtp.Host = Properties.Settings.Default.prgServSMTP;
                smtp.Port = (int)Properties.Settings.Default.prgPuertoSMTP;
                smtp.EnableSsl = Properties.Settings.Default.prgConexionSSL;
                smtp.Timeout = 20000;

                smtp.Send(mm);

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
        }
    }
}
