using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class ProductDao : IDisposable
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
        public ProductDao()
        {
            context = new ThiASPDbContext();
        }

        public IEnumerable<tblCat> GetCategories()
        {
            return context.Database.SqlQuery<tblCat>("PSP_Cat_Select").ToList();
        }
        public IEnumerable<tblPro> GetProducts(int catID)
        {
            SqlParameter[] param = new SqlParameter[] { 
                new SqlParameter("@CatID",catID)
            };
            return context.Database.SqlQuery<tblPro>("PSP_tblPro_SelectByCatID @CatID", param).ToList();
        }

        public int InsertProduct(tblPro model)
        {
            SqlParameter[] param=new SqlParameter[]{
                new SqlParameter("@ProName",model.ProName),
                new SqlParameter("@ProDescription",model.ProDescription),
                new SqlParameter("@CatID",model.CatID)
            };
            return context.Database.ExecuteSqlCommand("PSP_tblPro_Insert @ProName,@ProDescription,@CatID", param);
        }

        public int DeleteProduct(int id)
        {
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@ProID",id)
               
            };
            return context.Database.ExecuteSqlCommand("PSP_tblPro_Delete @ProID", param);
        }
    }
}
