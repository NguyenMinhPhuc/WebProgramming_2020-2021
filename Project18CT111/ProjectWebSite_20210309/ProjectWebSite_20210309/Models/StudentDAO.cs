using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectWebSite_20210309.Models
{
    public class StudentDAO
    {
        public List<Student> GetStudentList()
        {
            List<Student> list = new List<Student>();
            Student _student;
            for (int i = 0; i < 20; i++)
            {
                _student = new Student();
                _student.StudentID = i + 1;
                _student.StudentName = string.Format("Nguyễn Minh Phúc_Thứ {0}", i + 1);
                _student.ClassName = "18Ct111".ToUpper();
                _student.Address = "Biên Hòa - Đồng Nai";
                list.Add(_student);
            }
            return list;
        }
    }
}