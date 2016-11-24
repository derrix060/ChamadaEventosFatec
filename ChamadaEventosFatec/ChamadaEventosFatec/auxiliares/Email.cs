using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


//Email
using System.Net.Mail;
//NetworkCredencial
using System.Net;

namespace ChamadaEventosFatec.auxiliares
{
    public class Email
    {
        static string host = "smtp.gmail.com";
        private static string email = "chamadafatec@gmail.com";

        static int port = 587;
        static NetworkCredential credencial = new NetworkCredential(email, "ChamadaFatec2016");
        static MailAddress eFrom = new MailAddress(email);

        public static string EnviarEmail (List<string> emailTo, string corpoMensagem, string assunto)
        {

            MailMessage mail = new MailMessage();
            mail.From = eFrom;

            //popula o To
            foreach(string to in emailTo)
            {
                mail.To.Add(to);
            }

            mail.Subject = assunto;
            mail.Body = corpoMensagem;

            SmtpClient smtp = new SmtpClient(host, port);

            try
            {
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = credencial;
                smtp.Send(mail);
                return "Email enviado com sucesso!";
            }
            catch (SmtpException err)
            {
                return "Ocorreu o seguinte erro: " + err.Message;
            }
        }
    }
}