using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjectWebSite_20210320_Model.Models
{
    public class StudentDb
    {
        List<Student> list;

        public List<Student> List
        {
            get { return list; }
            set { list = value; }
        }
        Database data;
        public StudentDb()
        {
            data = new Database();
        }

        public List<Student> GetStudents()
        {
            List<Student> listlocal = new List<Student>();
            SqlDataReader dataReader = data.MyExcuteReader("PSP_Student_GetStudents", CommandType.StoredProcedure, null);
            while (dataReader.Read())
            {
                listlocal.Add(
                    new Student()
                    {
                        StudentID = dataReader["StudentID"].ToString(),
                        StudentName=dataReader["StudentName"].ToString(),
                        BirthDay=Convert.ToDateTime(dataReader["BirthDay"].ToString()),
                        Sex=Convert.ToBoolean(dataReader["Sex"].ToString()),
                        Address=dataReader["Address"].ToString()
                    }
                    );
            }
            this.list = listlocal;
            return list;
        }

    }
}