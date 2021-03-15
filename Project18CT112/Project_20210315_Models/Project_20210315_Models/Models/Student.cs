using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_20210315_Models.Models
{
    public class Student
    {
        //prop nhấn tab tab
        [Display(Name="MSSV")]
        public string StudentID { get; set; }
        [Display(Name = "Tên sinh viên")]
        public string StudentName { get; set; }
        [Display(Name = "Ngày Sinh")]
        public DateTime BirthDay { get; set; }
        [Display(Name = "Giới Tính")]
        public bool Sex { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
    }
}