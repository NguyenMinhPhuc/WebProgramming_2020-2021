using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ProductDao:IDisposable
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
            return context.Database.SqlQuery<tblCat>("PSP_tblCat_LayDanhSach").ToList();
        }
        public IEnumerable<tblPro> GetProductByID(int catid)
        {
            return context.Database.SqlQuery<tblPro>("PSP_tblPro_SelectByCatID @CatID", new SqlParameter("@CatID", catid));
        }

    }
}
