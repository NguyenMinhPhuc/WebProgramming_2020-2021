using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        //ID, Name, Alias, CategoryID, Images, CreateDate, Price, Detail, Status
        public int ID { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public int CategoryID { get; set; }
        public string Images { get; set; }
        public DateTime CreateDate { get; set; }
        public double Price { get; set; }
        public string Detail { get; set; }
        public bool Status { get; set; }
    }
}
