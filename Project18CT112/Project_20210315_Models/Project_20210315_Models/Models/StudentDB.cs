using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Project_20210315_Models.Models
{
    public class StudentDB
    {
        private List<Student> list;//Tạo properties = Ctrl+R+E
        Database data;
        public StudentDB()
        {
            data=new Database();
        }
        public List<Student> GetStudentList()
        {
            var dataReader = data.GetStudentList("PSP_Student_GetStudents", CommandType.StoredProcedure, null);
            list = new List<Student>();
            while (dataReader.Read())
            {
                list.Add(new Student()
                {
                    StudentID = dataReader["StudentID"].ToString(),
                    StudentName = dataReader["StudentName"].ToString(),
                    Sex = Convert.ToBoolean(dataReader["Sex"].ToString()),
                    BirthDay = Convert.ToDateTime(dataReader["BirthDay"].ToString()),
                    Address = dataReader["Address"].ToString()
                });
            }
            return list;
        }
    }
}