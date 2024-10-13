using Microsoft.AspNetCore.Hosting.Server;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        //[HttpPost]
        //public async Task<IActionResult> SendEmail(EmailModel model)
        //{
        //    try
        //    {
        //        using (var message = new MailMessage())
        //        {
        //            message.From = new MailAddress("faxisystem@gmail.com");
        //            message.To.Add(model.To);
        //            message.Subject = model.Subject;
        //            message.Body = model.Body;

        //            using (var smtpClient = new SmtpClient("smtp.gmail.com"))
        //            {
        //                smtpClient.Port = 587;
        //                smtpClient.Credentials = new NetworkCredential("faxisystem@gmail.com", "sgvc kitp rzik rwug");
        //                smtpClient.EnableSsl = true;
        //                await smtpClient.SendMailAsync(message);
        //            }
        //        }

        //        return Ok("Email sent successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Failed to send email: {ex.Message}");
        //    }
        //}
        [HttpPost]
        public async Task<IActionResult> SendEmail(EmailModel model)
        {
            try
            {
                using (var message = new MailMessage())
                {
                    // Set the sender's email address
                    message.From = new MailAddress(model.SourceEmail);

                    // Allow sending to multiple recipients
                    foreach (var recipient in model.To.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        message.To.Add(recipient.Trim());
                    }

                    message.Subject = model.Subject;
                    message.Body = model.Body;

                    // Add attachments
                    foreach (var filePath in model.Attachments)
                    {
                        if (System.IO.File.Exists(filePath)) // Check if file exists before attaching
                        {
                            message.Attachments.Add(new Attachment(filePath));
                        }
                    }

                    using (var smtpClient = new SmtpClient("smtp.gmail.com"))
                    {
                        smtpClient.Port = 587;
                        smtpClient.Credentials = new NetworkCredential(model.SourceEmail, "cnvg kxbv bzam fdza"); // Use the provided SourceEmail
                        smtpClient.EnableSsl = true;
                        await smtpClient.SendMailAsync(message);
                    }
                }

                return Ok("Email sent successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to send email: {ex.Message}");
            }
        }
    }
}
