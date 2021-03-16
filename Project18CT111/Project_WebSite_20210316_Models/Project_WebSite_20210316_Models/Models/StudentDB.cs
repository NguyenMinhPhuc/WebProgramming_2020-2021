using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Project_WebSite_20210316_Models.Models
{
    public class StudentDB
    {
        Database data;
        public StudentDB()
        {
            data = new Database();
        }

        public List<Student> GetStudents()
        {
            List<Student> list=new List<Student>();
            SqlDataReader dataReader = data.MyExcuteReader("PSP_Student_GetStudents", CommandType.StoredProcedure, null);
            while (dataReader.Read())
            {
                list.Add(new Student() { 
                    StudentID=dataReader["StudentID"].ToString(),
                    StudentName = dataReader["StudentName"].ToString(),
                    BirthDay =Convert.ToDateTime( dataReader["BirthDay"].ToString()),
                    Sex =Convert.ToBoolean( dataReader["Sex"].ToString()),
                    Address = dataReader["Address"].ToString()
                });
            }
            return list;
        }
    }
}