using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Website_20200308.Models
{
    public class Student
    {
        int age;//field
       
        public int Age//Properties
        {
            get { return age; }
            set { age = value; }
        }
        //prop--tab
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string ClassName { get; set; }
    }
}