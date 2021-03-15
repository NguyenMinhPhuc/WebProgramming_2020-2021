using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_20210315_Models.Models
{
    public class StudentDB
    {
        private List<Student> list;//Tạo properties = Ctrl+R+E

        public List<Student> List
        {
            get { return list; }
            set { list = value; }
        }
        public StudentDB()
        {
            list = new List<Student>()
            {
                new Student(){StudentID="118000123",StudentName="Nguyễn Minh Phúc",BirthDay=new DateTime(1985,3,2),Sex=true,Address="Đồng Nai"},
                new Student(){StudentID="118000124",StudentName="Nguyễn  Phúc",BirthDay=new DateTime(1985,3,6),Sex=true,Address="Đồng Nai"},
                new Student(){StudentID="118000125",StudentName="Nguyễn Minh",BirthDay=new DateTime(1988,3,21),Sex=false,Address="Đồng Nai"},
                new Student(){StudentID="118000126",StudentName=" Minh Phúc",BirthDay=new DateTime(1998,8,20),Sex=false,Address="Đồng Nai"},
            };
        }

        public List<Student> GetStudents()
        {
            return list;
        }
    }
}