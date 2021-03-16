using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Project_WebSite_20210316_Models.Models
{
    public class Database
    {
        private SqlConnection connection;
        private SqlCommand command;
        private string connectString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        
        public Database()
        {
            connection = new SqlConnection();
            connection.ConnectionString = connectString;
        }
        public SqlDataReader MyExcuteReader(string commandText,CommandType commandType,params SqlParameter[] param)
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
            connection.Open();

            //khởi tạo đối tượng command
            command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = commandText;
            command.CommandType = commandType;
            command.CommandTimeout = 600;
            if (param != null)
            {
                foreach (SqlParameter item in param)
                {
                    command.Parameters.Add(item);
                }
            }
            return command.ExecuteReader();
        }
    }
}