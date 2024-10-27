using System.Net.Mail;

namespace Services.ServicesImplementation
{
    public class EmailService:IEmailService
    {
        public async Task SendEmailAsync(List<string> toEmails, string subject, string body, List<(byte[] Content, string FileName)> attachments)
        {
            using (var message = new MailMessage())
            {
                message.From = new MailAddress("expresstaxi10@example.com");

                if (toEmails == null || !toEmails.Any())
                {
                    message.To.Add("expresstaxi10@gmail.com");
                }
                else
                {
                    foreach (var email in toEmails)
                    {
                        message.To.Add(email);
                    }
                }

                message.Subject = subject;
                message.Body = body;

                if (attachments != null && attachments.Any())
                {
                    foreach (var attachment in attachments)
                    {
                        if (attachment.Content.Length > 0)
                        {
                            var stream = new MemoryStream(attachment.Content);
                            var mailAttachment = new Attachment(stream, attachment.FileName);
                            message.Attachments.Add(mailAttachment);
                        }
                    }
                }

                using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.Credentials = new NetworkCredential("expresstaxi10@gmail.com", "wjcw ujqx vikx byrb");
                    smtpClient.EnableSsl = true;
                    await smtpClient.SendMailAsync(message);
                }
            }
        }

    }
}