using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjectWebSite_20210320_Model.Models
{
    public class Database
    {
        SqlConnection connection;
        public Database()
        {
            connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }
        SqlCommand command;
        public SqlDataReader MyExcuteReader(string commandText,CommandType commandType,params SqlParameter[] param)
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
            connection.Open();
            command = new SqlCommand(commandText,connection);
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