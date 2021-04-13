using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CategoryDb : IDisposable
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
        public CategoryDb()
        {
            data = new Database();
        }
        public List<Category> GetCategories(ref string err)
        {
            List<Category> list = new List<Category>();
            DataTable dataCategories = data.MyGetDataTable(ref err, "PSP_Category_Select", CommandType.StoredProcedure, null);
            foreach (DataRow item in dataCategories.Rows)
            {
                list.Add(
                    new Category()
                    {
                        ID = Convert.ToInt32(item["ID"].ToString()),
                        Name = item["Name"].ToString(),
                        Alias = item["Alias"].ToString(),
                        ParentID = Convert.ToInt32(item["ParentID"].ToString()),
                        CreateDate = Convert.ToDateTime(item["CreateDate"].ToString()),
                        Order = Convert.ToInt32(item["Order"].ToString()),
                        Status = Convert.ToBoolean(item["Status"].ToString())
                    });
            }
            return list;
        }
        public Category GetCategoryByID(ref string err, int id)
        {
            Category category = null;
            DataTable dataCategory = data.MyGetDataTable(ref err, "PSP_Category_SelectByID", CommandType.StoredProcedure, null);
            if (dataCategory.Rows.Count > 0)
            {
                category = new Category()
                {
                    ID = Convert.ToInt32(dataCategory.Rows[0]["ID"].ToString()),
                    Name = dataCategory.Rows[0]["Name"].ToString(),
                    Alias = dataCategory.Rows[0]["Alias"].ToString(),
                    ParentID = Convert.ToInt32(dataCategory.Rows[0]["ParentID"].ToString()),
                    CreateDate = Convert.ToDateTime(dataCategory.Rows[0]["CreateDate"].ToString()),
                    Order = Convert.ToInt32(dataCategory.Rows[0]["Order"].ToString()),
                    Status = Convert.ToBoolean(dataCategory.Rows[0]["Status"].ToString())
                };
            }
            return category;
        }

        public bool InsertUpdateCategory(ref string err, ref int rows, Category category)
        {
            //Truyền tham số
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@ID",category.ID),
                 new SqlParameter("@Name",category.Name),
                  new SqlParameter("@Alias",category.Alias),
                   new SqlParameter("@ParentID",category.ParentID),
                    new SqlParameter("@CreateDate",category.CreateDate),
                     new SqlParameter("@Order",category.Order),
                      new SqlParameter("@Status",category.Status)
            };
            //Thực hiện
            return data.MyExecuteNonQuery(ref err, ref rows, "PSP_Category_InsertUpdate", CommandType.StoredProcedure, param);
        }
    }
}
