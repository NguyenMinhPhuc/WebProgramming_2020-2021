using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AccountDb
    {
        Database data;
        public AccountDb()
        {
            data = new Database();
        }

        public bool CheckLogin(ref string err,string userName,string passWord)
        {
            return (bool)data.MyExecuteScalar(ref err, "SP_Account_Login", CommandType.StoredProcedure,
                new SqlParameter("@UserName", userName),
                new SqlParameter("@PassWord", passWord));
        }
    }
}
