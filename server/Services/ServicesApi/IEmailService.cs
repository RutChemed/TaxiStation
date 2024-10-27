using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesApi
{
    public interface IEmailService
    {
        public Task SendEmailAsync(List<string> toEmails, string subject, string body, List<(byte[] Content, string FileName)> attachments);
    }
}
