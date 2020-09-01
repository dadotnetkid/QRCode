using System;
using System.Collections.Generic;
using System.Text;

namespace QRCode.Models
{
    public class LoginVM
    {
        public string grant_type { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
