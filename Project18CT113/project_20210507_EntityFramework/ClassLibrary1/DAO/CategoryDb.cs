using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class CategoryDb
    {
        WebShopHocTapDbContext context;
        public CategoryDb()
        {
            context = new WebShopHocTapDbContext();
        }
        public IEnumerable<Category> GetCategories(int id)
        {
            var list = context.Database.SqlQuery<Category>("PSP_Category_Select @ID", new SqlParameter("@ID", id)).ToList();
            return list;
        }

        public Category GetCategoryByID(int id)
        {
            var category = context.Database.SqlQuery<Category>("PSP_Category_Select @ID", new SqlParameter("@ID", id)).SingleOrDefault();
            return category;
        }

        public int InsertUpdateCategory(Category category)
        {
            SqlParameter[] param=new SqlParameter[]{
                new SqlParameter("@ID",category.ID),
                new SqlParameter("@Name",category.Name),
                new SqlParameter("@Alias",category.Alias), 
                new SqlParameter("@ParentID",category.ParentID),
                new SqlParameter("@CreateDate",category.CreateDate),
                new SqlParameter("@Order",category.Order),
                new SqlParameter("@Status",category.Status)
            };
            var result = context.Database.ExecuteSqlCommand("PSP_Category_InsertUpdate @ID,@Name,@Alias,@ParentID,@CreateDate,@Order,@Status", param);
            return result;
        }
        public int DeleteCategory(Category category)
        {
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@ID",category.ID) 
            };
            var result = context.Database.ExecuteSqlCommand("PSP_Category_Delete @ID", param);
            return result;
        }
    }
}
