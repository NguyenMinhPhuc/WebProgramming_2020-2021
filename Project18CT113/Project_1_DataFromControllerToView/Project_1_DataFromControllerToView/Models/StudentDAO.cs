using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_1_DataFromControllerToView.Models
{
    public class StudentDAO
    {
        List<Student> list;
        public StudentDAO()
        {
            list = new List<Student>() { 
                new Student(){ StudentID=1,StudentName="Nguyễn Văn A",ClassName="18CT113",Address="Bình Dương"},
                new Student(){ StudentID=2,StudentName="Nguyễn Văn B",ClassName="18CT113",Address="Đồng Nai"},
                new Student(){ StudentID=3,StudentName="Nguyễn Văn C",ClassName="18CT113",Address="Bình Dương"},
                new Student(){ StudentID=4,StudentName="Nguyễn Văn D",ClassName="18CT113",Address="Đồng Nai"},
                new Student(){ StudentID=5,StudentName="Nguyễn Văn E",ClassName="18CT113",Address="Đồng Nai"},
                new Student(){ StudentID=6,StudentName="Nguyễn Văn F",ClassName="18CT113",Address="Bình Dương"}
            };
        }
        
        public List<Student> GetStudentList()
        {
            return list;
        }

        public Student GetStudentByID(int? StudentID = 1)
        {
            var _student = list.SingleOrDefault(x => x.StudentID == StudentID);
            return _student;
        }
    }
}