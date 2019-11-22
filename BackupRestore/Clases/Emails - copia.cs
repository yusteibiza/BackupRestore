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
                                  string Usuario, String Password, bool Autenticación)
        {
            try
            {
                MailMessage mm = new MailMessage() { From = new MailAddress(Destinatario) };
                SmtpClient smtp = new SmtpClient(ServidorSMTP, Puerto);
                smtp.Credentials = new System.Net.NetworkCredential(Usuario, Password);
                //smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                mm.To.Add(Properties.Settings.Default.prgDestinatario);
                mm.Subject = "Backup&Restore";
                mm.Body = "Este es un mensaje de prueba de Backup&Restore";

                smtp.Send(mm);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static int EnviarInforme(ResultadoCopia ResultadoDeLaCopia, string TextoDelMensaje)
        {
            try
            {
                MailMessage mm = new MailMessage() { From = new MailAddress("pruebas@backuprestore.com") };
                SmtpClient smtp = new SmtpClient(Properties.Settings.Default.prgServSMTP,
                                                (int)Properties.Settings.Default.prgPuertoSMTP);
                smtp.Credentials = new System.Net.NetworkCredential(Properties.Settings.Default.prgUsuarioSMTP,
                                                Properties.Settings.Default.prgPasswordSMTP);
                //smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                mm.To.Add(Properties.Settings.Default.prgDestinatario);
                mm.Subject = "Backup&Restore";

                if (ResultadoDeLaCopia == ResultadoCopia.OK)
                    mm.Body = "Informe de la copia de seguridad de Backup&Restore\n" +
                              "-----------------------------------------------------------------------\n\n" +
                              "- Resultado ... [ OK ]\n\n" + TextoDelMensaje + "\n\n";
                else
                    mm.Body = "Informe de la copia de seguridad de Backup&Restore\n" +
                              "-----------------------------------------------------------------------\n\n" +
                              "- Resultado ... [ ERROR ]\n\n" + TextoDelMensaje + "\n\n";

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
