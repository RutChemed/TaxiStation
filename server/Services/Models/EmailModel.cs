using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class EmailModel
    {
        public string SourceEmail { get; set; } = "expresstaxi10@gmail.com";
        public string To { get; set; } = "expresstaxi10@gmail.com";
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<string> Attachments { get; set; }
    }
}
