using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Category
    {
        //ID, Name, Alias, ParentID, CreateDate, Order, Status
        public int ID { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public int ParentID { get; set; }
        public DateTime CreateDate { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
    }
}
