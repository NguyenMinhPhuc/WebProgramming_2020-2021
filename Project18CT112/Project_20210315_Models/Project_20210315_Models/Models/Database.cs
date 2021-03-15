using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Project_20210315_Models.Models
{
    public class Database
    {

        SqlConnection cnn;
        SqlCommand cmd;
        //Đọc chuỗi kết nối trong file Web.Config để cho đối tượng SqlConnection
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        public Database()
        {
            cnn = new SqlConnection();
            cnn.ConnectionString = connectionString;
        }
        /// <summary>
        /// Phương thức thực thi thủ tục Sql lấy data về kiểu dữ liệu SqlDataReader;
        /// </summary>
        /// <param name="commandText">Tên sql wuery hoặc Store Proceduce</param>
        /// <param name="commandType">Kiểu command</param>
        /// <param name="p">Danh sách tham số</param>
        /// <returns>Trả vể: SqlDataReader</returns>
        public SqlDataReader GetStudentList(string commandText, CommandType commandType, params SqlParameter[] p)
        {
            SqlDataReader dataReader = null;
            if (cnn.State == ConnectionState.Open)
                cnn.Close();
            cnn.Open();
            cmd = new SqlCommand() { Connection = cnn, CommandText = commandText, CommandType = commandType, CommandTimeout = 600 };
            if (p != null)
            {
                foreach (SqlParameter item in p)
                {
                    cmd.Parameters.Add(item);
                }
            }
            dataReader = cmd.ExecuteReader();
            return dataReader;
        }
    }
}