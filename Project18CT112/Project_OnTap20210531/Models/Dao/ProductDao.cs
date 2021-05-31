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
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@CatID",catID)
            };
            return context.Database.SqlQuery<tblPro>("PSP_tblPro_SelectByCatID @CatID", param).ToList();

        }
        public int InsertPro(tblPro product)
        {
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@ProName",product.ProName),
                  new SqlParameter("@ProDescription",product.ProDescription),
                    new SqlParameter("@CatID",product.CatID),
            };
            return context.Database.ExecuteSqlCommand("PSP_tblPro_Insert @ProName, @ProDescription,@CatID", param);
        }
    }
}
