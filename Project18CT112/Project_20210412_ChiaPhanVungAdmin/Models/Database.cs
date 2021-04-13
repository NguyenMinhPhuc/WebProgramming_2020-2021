using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Models
{
    public class Database : IDisposable
    {
        //field
        private SqlConnection connect;
        private SqlCommand command;
        private SqlDataAdapter dataAdapter;
        //constructor
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
            connect = new SqlConnection() {
                ConnectionString =ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString
            };
            //"Server=MinhPhuc;Database=WebShopHocTap;uid=??;pwd=??"
        }
        //Method
        public SqlDataReader MyExecuteReader(string commandText, CommandType commandType,params SqlParameter[] arrayParameter)
        {
            if (connect.State == ConnectionState.Open)
                connect.Close();
            connect.Open();
            command = new SqlCommand(){
                Connection=connect,
                CommandText = commandText,
                CommandType = commandType,
                CommandTimeout=600
            };
            if (arrayParameter != null)
            {
                foreach (SqlParameter item in arrayParameter)
                {
                    command.Parameters.Add(item);
                }
            }
          return  command.ExecuteReader(); 
        }
        public int MyExecuteNonQuery(string commandText, CommandType commandType, params SqlParameter[] arrayParameter)
        {
            if (connect.State == ConnectionState.Open)
                connect.Close();
            connect.Open();
            command = new SqlCommand()
            {
                Connection = connect,
                CommandText = commandText,
                CommandType = commandType,
                CommandTimeout = 600
            };
            if (arrayParameter != null)
            {
                foreach (SqlParameter item in arrayParameter)
                {
                    command.Parameters.Add(item);
                }
            }
            return command.ExecuteNonQuery();
        }

        public DataTable MyGetDataTable(string commandText, CommandType commandType, params SqlParameter[] arrayParameter)
        {
            if (connect.State == ConnectionState.Open)
                connect.Close();
            connect.Open();
            command = new SqlCommand()
            {
                Connection = connect,
                CommandText = commandText,
                CommandType = commandType,
                CommandTimeout = 600
            };
            if (arrayParameter != null)
            {
                foreach (SqlParameter item in arrayParameter)
                {
                    command.Parameters.Add(item);
                }
            }
            DataTable tableResult = new DataTable();
            dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(tableResult);
            return tableResult;
        }
        public object MyExecuteScalar(ref string err,string commandText, CommandType commandType, params SqlParameter[] arrayParameter)
        {
            object objResult = null;
            try
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
                connect.Open();
                command = new SqlCommand(){
                    Connection = connect,
                    CommandText = commandText,
                    CommandType = commandType,
                    CommandTimeout = 600
                };
                if (arrayParameter != null) {
                    foreach (SqlParameter item in arrayParameter)
                    {
                        command.Parameters.Add(item);
                    }
                }

                objResult= command.ExecuteScalar();  
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            finally {connect.Close(); }
            return objResult;
        }
    }
}
