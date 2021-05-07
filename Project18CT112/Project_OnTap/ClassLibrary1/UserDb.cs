using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserDb
    {
        ThiASPDbContext context;
        public UserDb()
        {
            context = new ThiASPDbContext();
        }

        public IEnumerable<tblUser> GetUsers()
        {
            var list = context.Database.SqlQuery<tblUser>("PSP_tblUser_Select").ToList();
            return list;
        }

        public tblUser GetUserByID(int ID)
        {
            SqlParameter[] param=new SqlParameter[]{
                new SqlParameter("@ID",ID)
            };
            var user = context.Database.SqlQuery<tblUser>("", param).SingleOrDefault();
            return user;
        }

        public int InsertUser(tblUser user)
        {
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@ID",user.UserID),
                 new SqlParameter("@Username",user.Username),
                  new SqlParameter("@Fullname",user.Fullname),
                   new SqlParameter("@Status",user.Status),
                    new SqlParameter("@Address",user.Address),
                     new SqlParameter("@Phone",user.Phone),
                      new SqlParameter("@Userpass",user.Userpass), 
                      new SqlParameter("@Systemright",user.Systemright)
            };
            var result = context.Database.ExecuteSqlCommand("", param);
            return result;
        }

        public int DeleteUser(tblUser user)
        {
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@ID",user.UserID)
                 
            };
            var result = context.Database.ExecuteSqlCommand("", param);
            return result;
        }
    }
}
