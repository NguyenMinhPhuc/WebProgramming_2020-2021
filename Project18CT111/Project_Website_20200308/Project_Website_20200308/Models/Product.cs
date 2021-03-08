using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Website_20200308.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        public string Color { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
    }
}