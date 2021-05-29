using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class CategoryDao : IDisposable
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
        public CategoryDao()
        {
            context = new ThiASPDbContext();
        }

        public IEnumerable<tblCat> GetCategories()
        {
            return context.Database.SqlQuery<tblCat>("PSP_tblCat_LayDanhSach").ToList();
        }

        public int DeleteCategoryByID(int id)
        {

            return context.Database.ExecuteSqlCommand("PSP_tblCat_XoaCategory @CatID", 
                new SqlParameter("@CatID", id));
        }

        public int InsertCategory(tblCat model)
        {
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@CatName",model.CatName),
                new SqlParameter("@CatDescription",model.CatDescription)
            };
            return context.Database.ExecuteSqlCommand("PSP_tblCat_ThemCategory @CatName,@CatDescription", param);
        }
    }
}
