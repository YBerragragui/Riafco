using System;

namespace Riafco.Dataflex.Pro.Models
{
    public class MailModel
    {
        public string Fullnom { get; set; }
        public string Email { get; set; }
        public string Sujet { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            string htmlMessage = "<strong>Nom :</strong>" + Fullnom + "<br/>"
                                 + "<strong>Email :</strong>" + Email + "<br/>"
                                 + "<strong>Sujet :</strong>" + Sujet + "<br/>"
                                 + "<br/><br/><strong>Message :</strong><br/><br/>";
            if (Message != null)
            {
                htmlMessage += Message.Replace(Environment.NewLine, "<br/>");

                return htmlMessage;
            }
            else return htmlMessage;
        }
    }
}