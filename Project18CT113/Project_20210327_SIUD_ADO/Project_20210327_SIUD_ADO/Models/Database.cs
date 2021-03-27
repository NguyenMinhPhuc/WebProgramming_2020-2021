using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
//Them namespace
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Project_20210327_SIUD_ADO.Models
{
    public class Database
    {
        private SqlConnection connect;
        private SqlCommand command;

        public Database()
        {
            connect = new SqlConnection() { ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString };
        }

        public SqlDataReader MyExecuteReader(ref string err, string commandText, CommandType commandType, params SqlParameter[] param)
        {
            SqlDataReader dataReader = null;
            try
            {
                //mo ket noi
                if (connect.State == ConnectionState.Open)
                    connect.Close();
                connect.Open();
                command = new SqlCommand() { Connection = connect, CommandText = commandText, CommandType = commandType, CommandTimeout = 600 };
                if (param != null){
                    foreach (SqlParameter item in param){
                        command.Parameters.Add(item);
                    }
                }
                dataReader = command.ExecuteReader();
            }
            catch (Exception ex){err = ex.Message; }
            return dataReader;
        }

        public bool MyExecteNonQuery(ref string err, ref int rows,string commandText, CommandType commandType, params SqlParameter[] param )
        {
            bool result = false;
            try
            {
                //mo ket noi
                if (connect.State == ConnectionState.Open)
                    connect.Close();
                connect.Open();
                command = new SqlCommand() { Connection = connect, CommandText = commandText, CommandType = commandType, CommandTimeout = 600 };
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
            return result;
        }
    }
}