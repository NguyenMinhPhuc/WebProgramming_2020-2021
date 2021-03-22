using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Project_20210322_SIUD_ADO.Models
{
    public class Database : IDisposable
    {
        //field - biến thành viên
        private SqlConnection connect;//Kết nối đến SQL Server 
        private SqlCommand command;//thực thi thủ tục
        public void Dispose()
        {
            if (connect != null)
            {
                connect.Dispose();
                connect = null;
            }
            if (command != null)
            {
                command.Dispose();
                command = null;
            }
        }
        //Hàm tạo -Contructor
        public Database()
        {
            //khởi tạo đối tượng kết nối
            connect = new SqlConnection() { ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString };
        }
        /// <summary>
        /// Phương thức thực hiện thực thi thủ tục (store Procedure) trong sql với tác vụ SELECT
        /// </summary>
        /// <param name="err">Tham số tham chiếu lưu lỗi</param>
        /// <param name="commandText">thuộc tính commandtext</param>
        /// <param name="commandType">Thuộc tính commandType</param>
        /// <param name="param">Danh sách parameter của thử tục sql</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader MyExcuteReader(ref string err,string commandText,CommandType commandType,params SqlParameter[] param)
        {
            SqlDataReader datareader = null;
            try
            {   //Mở kết nối
                if (connect.State == ConnectionState.Open)
                    connect.Close();
                connect.Open();
                //khởi tạo đối tượng SqlCommand
                command = new SqlCommand() { Connection = connect, CommandText = commandText, CommandType = commandType, CommandTimeout = 600 };
                if (param != null)//Kiểm tra Add tham số cho đối tượng SqlCommand.
                {
                    foreach (SqlParameter item in param)
                    {
                        command.Parameters.Add(item);
                    }
                }
                datareader = command.ExecuteReader();//Phương thức của đối tượng SqlCommand trả về 1 danh sách kiểu SqlDataReader.
            }
            catch (Exception ex) 
            {
                err = ex.Message;
            }
            return datareader;
        }
        /// <summary>
        /// Phương thức dùng để thực thi thủ tục (store procedure) với các tác vụ: Insert, Update, Delete
        /// </summary>
        /// <param name="err">tham số tham chiếu lưu lỗi</param>
        /// <param name="rows">tham số tham chiếu lưu số dòng thực hiện được của SqlCommand</param>
        /// <param name="commandText">thuộc tính command text </param>
        /// <param name="commandType">Thuộc tính command type</param>
        /// <param name="param">danh sách tham số (SqlParameter)</param>
        /// <returns>thành công  true; lỗi: false</returns>
        public bool MyExcuteNonQuery(ref string err,ref int rows,string commandText,CommandType commandType,params SqlParameter[] param)
        {
            bool result = false;
            try
            {   //Mở kết nối
                if (connect.State == ConnectionState.Open)
                    connect.Close();
                connect.Open();
                //khởi tạo đối tượng SqlCommand
                command = new SqlCommand() { Connection = connect, CommandText = commandText, CommandType = commandType, CommandTimeout = 600 };
                if (param != null)
                {
                    foreach (SqlParameter item in param)
                    {
                        command.Parameters.Add(item);
                    }
                }
                rows = command.ExecuteNonQuery();//Phuong thức thực thi không trả vể truy vấn. Kết quả trả vể số lượng dòng được thực hiện thành công.
                result = true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            finally
            {
                connect.Close();//Đóng kết nối
            }
            return result;
        }

    }
}