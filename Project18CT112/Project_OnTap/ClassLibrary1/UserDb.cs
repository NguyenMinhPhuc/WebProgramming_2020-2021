using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserDb : IDisposable
    {
        ThiASPDbContext context;
        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
                context = null;
            }
        }
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

        public int InsertUser(string userName,string fullName,string address,string phone)
        {
            SqlParameter[] param = new SqlParameter[]{
                 new SqlParameter("@Username",userName),
                  new SqlParameter("@Fullname",fullName),
                    new SqlParameter("@Address",address),
                     new SqlParameter("@Phone",phone)
            };
            var result = context.Database.ExecuteSqlCommand("PSP_tblUser_Insert", param);
            return result;
        }

        public int DeleteUser(int id)
        {
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@UserId",id)
                 
            };
            var result = context.Database.ExecuteSqlCommand("PSP_User_Delete @UserId", param);
            return result;
        }
        public int? ChangeStatus(int id)
        {
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@UserId",id)
            };
            var result = context.Database.SqlQuery<int>("PSP_User_ChangeStatus @UserId", param).SingleOrDefault();
            return result;
        }
    }
}
