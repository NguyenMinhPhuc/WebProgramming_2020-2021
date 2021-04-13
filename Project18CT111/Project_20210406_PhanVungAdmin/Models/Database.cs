using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Models
{
    public class Database
    {
        private SqlConnection connect;
        private SqlCommand command;
        private SqlDataAdapter dataAdapter;

        public Database()
        {
            connect = new SqlConnection() { 
            ConnectionString=ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString
            };
        }
        public SqlDataReader MyExecuteDataReader(ref string err,string commandText,CommandType commandType,params SqlParameter[] param)
        {
            SqlDataReader dataReader = null;
            try {
                //Mo ket noi
                if (connect.State == ConnectionState.Open)
                    connect.Close();
                connect.Open();
                //khoi tao command
                command = new SqlCommand() { 
                    Connection=connect,
                    CommandText=commandText,
                    CommandType=commandType,
                    CommandTimeout=600
                };
                if(param!=null){
                    foreach (SqlParameter item in param){
                        command.Parameters.Add(item);
                    }
                }
               dataReader= command.ExecuteReader();
            }
            catch (Exception ex){err = ex.Message;}
            //finally { connect.Close(); }//Khong dung dong ket noi
            return dataReader;
        }

        public DataTable MyGetDataTable(ref string err, string commandText, CommandType commandType, params SqlParameter[] param)
        {
            DataTable dataTable = new DataTable();
            try{
                //Mo ket noi
                if (connect.State == ConnectionState.Open)
                    connect.Close();
                connect.Open();
                //khoi tao command
                command = new SqlCommand(){
                    Connection = connect,
                    CommandText = commandText,
                    CommandType = commandType,
                    CommandTimeout = 600
                };
                if (param != null){
                    foreach (SqlParameter item in param){
                        command.Parameters.Add(item);
                    }
                }
                dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);
            }
            catch (Exception ex) {err = ex.Message; }
            finally { connect.Close(); }// dung dong ket noi
            return dataTable;

        }

        public bool MyExecuteNonQuery(ref string err,ref int rows, string commandText, CommandType commandType, params SqlParameter[] param)
        {
            bool result = false;
            try {
                //Mo ket noi
                if (connect.State == ConnectionState.Open)
                    connect.Close();
                connect.Open();
                //khoi tao command
                command = new SqlCommand() {
                    Connection = connect,
                    CommandText = commandText,
                    CommandType = commandType,
                    CommandTimeout = 600
                };
                if (param != null) {
                    foreach (SqlParameter item in param)
                    {
                        command.Parameters.Add(item);
                    }
                }
                rows = command.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex) {err = ex.Message; }
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
                result = command.ExecuteScalar();
              
            }
            catch (Exception ex) { err = ex.Message; }
            finally { connect.Close(); }// dung dong ket noi
            return result;
        }
    }
}
