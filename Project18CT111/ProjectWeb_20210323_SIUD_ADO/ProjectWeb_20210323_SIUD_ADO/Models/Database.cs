using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Thêm namespace để làm việc với đối tượng ADO.NET
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ProjectWeb_20210323_SIUD_ADO.Models
{
    public class Database
    {
        //Khai báo biến thành viên (field) của ADO.Net
        private SqlConnection connect;
        private SqlCommand command;
        //Hàm tạo Constructor()
        public Database()
        {
            connect = new SqlConnection() { ConnectionString=ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString};
        }
        //method
        /// <summary>
        /// Phương thực thực thi thủ tục (Store procedure) trả về danh sách 
        /// </summary>
        /// <param name="err">tham số tham chiếu lưu lỗi (nếu có)</param>
        /// <param name="commandText">Thuộc tính commandText (tên của SP, câu Query)</param>
        /// <param name="commandType">Thuộc tính commandType (Store procedure, text,tableDirect)</param>
        /// <param name="param">danh sách tham số cho SP</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader MyExecuteReader(ref string err,string commandText,CommandType commandType,params SqlParameter[] param)
        {
            SqlDataReader dataReader = null;
            try
            {
                //Mở kết nối
                if (connect.State == ConnectionState.Open)
                    connect.Close();
                connect.Open();
                //Khởi tạo Sqlcommand
                command = new SqlCommand() {Connection=connect,CommandText=commandText,CommandType=commandType,CommandTimeout=600 };
                //Khai báo tham số cho SqlCommand
                if (param != null)
                {
                    foreach (SqlParameter item in param)
                    {
                        command.Parameters.Add(item);
                    }
                }
                dataReader = command.ExecuteReader();//Phương thức thực thi của SqlCommand -->trả về đối tượng SqlDataReader
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            return dataReader;
        }

        /// <summary>
        /// Phương thực thực thi thủ tục (Store procedure) cho tác vụ Insert, Update, Delete
        /// </summary>
        /// <param name="err">tham số tham chiếu lưu lỗi (nếu có)</param>
        /// <param name="commandText">Thuộc tính commandText (tên của SP, câu Query)</param>
        /// <param name="commandType">Thuộc tính commandType (Store procedure, text,tableDirect)</param>
        /// <param name="param">danh sách tham số cho SP</param>
        /// <returns>SqlDataReader</returns>
        public bool MyExecuteNonQuery(ref string err,ref int rows, string commandText, CommandType commandType, params SqlParameter[] param)
        {
            bool result = false;
            try
            {
                //Mở kết nối
                if (connect.State == ConnectionState.Open)
                    connect.Close();
                connect.Open();
                //Khởi tạo Sqlcommand
                command = new SqlCommand() { Connection = connect, CommandText = commandText, CommandType = commandType, CommandTimeout = 600 };
                //Khai báo tham số cho SqlCommand
                if (param != null)
                {
                    foreach (SqlParameter item in param)
                    {
                        command.Parameters.Add(item);
                    }
                }
                rows = command.ExecuteNonQuery();//Phương thức thực thi của SqlCommand -->trả về int là số dòng thực hiện được
                result = true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            finally { connect.Close(); }
            return result;
        }

    }
}