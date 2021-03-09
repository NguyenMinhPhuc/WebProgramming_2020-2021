using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectWebSite_20210309.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}