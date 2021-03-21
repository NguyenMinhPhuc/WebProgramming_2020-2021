using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectWebSite_20210320_Model.Models
{
    public class Student
    {
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public DateTime BirthDay { get; set; }
        public bool Sex { get; set; }
        public string Address { get; set; }
    }
}