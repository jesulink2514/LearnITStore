using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnITStore.Domain.Concrete
{
    public class EmailSettings
    {
        public string MailTo = "jesus.angulo@outlook.com";
        public string MailFrom = "jsc2514@gmail.com";
        public bool UseSSL = true;
        public string UserName = "jsc2514@gmail.com";
        public string Password = "";
        public string Server = "smtp.gmail.com";
        public int ServerPort = 587;

        public bool WriteAsFile = true;
        public string FileLocation = @"C:\tmp";
    }
}
