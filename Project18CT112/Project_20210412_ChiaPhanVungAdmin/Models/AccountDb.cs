using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AccountDb : IDisposable
    {
        Database data;
        public void Dispose()
        {
            if (data != null)
            {
                data.Dispose();
                data = null;
            }
        }
        public AccountDb()
        {
            data = new Database();
        }
        
        public bool Login(ref string err,string userName,string passWord)
        {
            return (bool)data.MyExecuteScalar(ref err, "SP_Account_Login", CommandType.StoredProcedure
                , new SqlParameter("@UserName", userName)
                , new SqlParameter("@PassWord", passWord));
        }

    }
}
