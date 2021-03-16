using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_WebSite_20210316_Models.Models
{
    public class Student
    {
        //prop
        public string StudentID { get; set; }
        [Display(Name="Tên sinh viên")]
        public string StudentName { get; set; }
        public DateTime BirthDay { get; set; }
        public bool Sex { get; set; }
        public string Address { get; set; }
    }
}