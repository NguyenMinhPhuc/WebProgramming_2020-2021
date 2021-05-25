using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CatDb : IDisposable
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
        public CatDb()
        {
            context = new ThiASPDbContext();
        }
        public IEnumerable<tblCat> GetCats()
        {
            return context.Database.SqlQuery<tblCat>("PSP_Cat_Select").ToList();
        }

        public int DelectCat(int catID)
        {
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@CatID", catID)
            };
            return context.Database.ExecuteSqlCommand("PSP_Cat_Delete @CatID", param);
        }

        public int UpdateCat(int catID)
        {
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@CatID", catID)
            };
            return context.Database.SqlQuery<int>("PSP_tblCat_Update @CatID", param).SingleOrDefault();
        }
    }
} 
