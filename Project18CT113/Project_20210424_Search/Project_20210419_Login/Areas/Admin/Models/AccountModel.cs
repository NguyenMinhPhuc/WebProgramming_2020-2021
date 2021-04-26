using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_20210419_Login.Areas.Admin.Models
{
    public class AccountModel
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }

        public bool RememberMe { get; set; }
    }
}