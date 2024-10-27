namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmail([FromForm] List<IFormFile> attachments, [FromForm] List<string> toEmails, [FromForm] string subject, [FromForm] string body)
        {
            var files = new List<(byte[] Content, string FileName)>();

            if (attachments != null && attachments.Count > 0)
            {
                foreach (var attachment in attachments)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await attachment.CopyToAsync(memoryStream);
                        files.Add((memoryStream.ToArray(), attachment.FileName));
                    }
                }
            }

            await _emailService.SendEmailAsync(toEmails, subject, body, files);

            return Ok("Email sent successfully.");
        }

    }
}
