using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Models
{
    public class AccountDb
    {
        Database data;
        public AccountDb()
        {
            data = new Database();
        }

        public bool Login(ref string err,string UserName, string Password)
        {
            bool result = false;
            SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@UserName",UserName),
                new SqlParameter("@Password",Password)
            };
            try
            {
                result =(bool) data.MyExecuteScalar(ref err, "SP_Account_Login", CommandType.StoredProcedure, sqlParams);
                
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            return result;
        }

    }
}
