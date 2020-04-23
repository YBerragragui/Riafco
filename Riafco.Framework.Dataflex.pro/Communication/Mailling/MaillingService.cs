using System.Net;
using System.Net.Mail;

namespace Riafco.Framework.Dataflex.pro.Communication.Mailling
{
    /// <summary>
    /// The MaillingService class.
    /// </summary>
    public static class MaillingService
    {
        /// <summary>
        /// Send mail.
        /// </summary>
        /// <param name="toAdress">the reception adress</param>
        /// <param name="subjectMAil">the message subject</param>
        /// <param name="bodyMail">body mail.</param>
        /// <param name="isBodyHtml">true if the body is htlm content.</param>
        public static void SendMail(string toAdress, string subjectMAil, string bodyMail, bool isBodyHtml)
        {
            MailMessage message = new MailMessage(Constant.Mail, toAdress, subjectMAil, bodyMail) { IsBodyHtml = isBodyHtml };
            SmtpClient client =
                new SmtpClient(Constant.Smtp, Constant.SmtpPort)
                {
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(Constant.Mail, Constant.Password)
                };
            client.Send(message);
        }
    }
}
