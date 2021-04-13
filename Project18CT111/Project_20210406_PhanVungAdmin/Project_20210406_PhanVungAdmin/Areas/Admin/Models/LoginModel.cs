using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_20210406_PhanVungAdmin.Areas.Admin.Models
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}