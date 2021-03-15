using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_20210315_Models.Models
{
    public class Student
    {
        //prop nhấn tab tab
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public DateTime BirthDay { get; set; }
        public bool Sex { get; set; }
        public string Address { get; set; }
    }
}