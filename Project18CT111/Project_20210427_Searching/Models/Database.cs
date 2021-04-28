using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Models
{

    //Sinh viên xây dựng lớp database để kết nối đến SQL Server 
    //1. Khai báo biến của ADO.NET
    //2. Khởi tạo đối tượng kết nối bằng hàm tạo
    //3. Viết hàm trả về danh sách 
    //4. Viết hàm thực hiện Non Query
    //5. Viết hàm trả vể dataTable
    public class Database : IDisposable
    {
        SqlConnection connect;
        SqlCommand command;
        SqlDataAdapter dataAdapter;
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
            if (dataAdapter != null)
            {
                dataAdapter.Dispose();
                dataAdapter = null;
            }
        }
        public Database()
        {
            connect = new SqlConnection() { ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString };
        }
        public SqlDataReader MyExecuteDataReader(ref string err, string commandText, CommandType commandType, params SqlParameter[] param)
        {
            SqlDataReader dataReader = null;
            try
            {
                //Mo ket noi
                if (connect.State == ConnectionState.Open)
                    connect.Close();
                connect.Open();
                //khoi tao command
                command = new SqlCommand()
                {
                    Connection = connect,
                    CommandText = commandText,
                    CommandType = commandType,
                    CommandTimeout = 600
                };
                if (param != null)
                {
                    foreach (SqlParameter item in param)
                    {
                        command.Parameters.Add(item);
                    }
                }
                dataReader = command.ExecuteReader();
            }
            catch (Exception ex) { err = ex.Message; }
            //finally { connect.Close(); }//Khong dung dong ket noi
            return dataReader;
        }

        public DataTable MyGetDataTable(ref string err, string commandText, CommandType commandType, params SqlParameter[] param)
        {
            DataTable dataTable = new DataTable();
            try
            {
                //Mo ket noi
                if (connect.State == ConnectionState.Open)
                    connect.Close();
                connect.Open();
                //khoi tao command
                command = new SqlCommand()
                {
                    Connection = connect,
                    CommandText = commandText,
                    CommandType = commandType,
                    CommandTimeout = 600
                };
                if (param != null)
                {
                    foreach (SqlParameter item in param)
                    {
                        command.Parameters.Add(item);
                    }
                }
                dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);
            }
            catch (Exception ex) { err = ex.Message; }
            finally { connect.Close(); }// dung dong ket noi
            return dataTable;

        }

        public bool MyExecuteNonQuery(ref string err, ref int rows, string commandText, CommandType commandType, params SqlParameter[] param)
        {
            bool result = false;
            try
            {
                //Mo ket noi
                if (connect.State == ConnectionState.Open)
                    connect.Close();
                connect.Open();
                //khoi tao command
                command = new SqlCommand()
                {
                    Connection = connect,
                    CommandText = commandText,
                    CommandType = commandType,
                    CommandTimeout = 600
                };
                if (param != null)
                {
                    foreach (SqlParameter item in param)
                    {
                        command.Parameters.Add(item);
                    }
                }
                rows = command.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex) { err = ex.Message; }
            finally { connect.Close(); }// dung dong ket noi
            return result;

        }
        public object MyExecuteScalar(ref string err, string commandText, CommandType commandType, params SqlParameter[] param)
        {
            object result = null;
            try
            {
                //Mo ket noi
                if (connect.State == ConnectionState.Open)
                    connect.Close();
                connect.Open();
                //khoi tao command
                command = new SqlCommand()
                {
                    Connection = connect,
                    CommandText = commandText,
                    CommandType = commandType,
                    CommandTimeout = 600
                };
                if (param != null)
                {
                    foreach (SqlParameter item in param)
                    {
                        command.Parameters.Add(item);
                    }
                }
              result=  command.ExecuteScalar();
             
            }
            catch (Exception ex) { err = ex.Message; }
            finally { connect.Close(); }// dung dong ket noi
            return result;

        }
    }
}

