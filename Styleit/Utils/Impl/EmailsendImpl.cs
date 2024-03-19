using MailKit.Net.Smtp;
using MimeKit;

namespace Styleit.Utils.Impl
{
    public class EmailsendImpl : Emailsend
    {
        public void send(string to, string body)
        {
            try{
                var email = new MimeMessage();

                email.From.Add(new MailboxAddress("Styleit", "Styleit"));
                email.To.Add(new MailboxAddress("Receiver Name", to));

                email.Subject = "info";
                email.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
                {
                    Text = body
                };
                using (var smtp = new SmtpClient())
                {
                    smtp.Connect("smtp.gmail.com", 587, false);

                    // Note: only needed if the SMTP server requires authentication
                    smtp.Authenticate("smulili039@gmail.com", "hbskkpoojxcgrkuu");

                    smtp.Send(email);
                    smtp.Disconnect(true);
                }
            }
            catch (Exception e)
            {
                
            }
        }
    }
}
