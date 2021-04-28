using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CategoryDb : BaseDb
    {
        public List<Category> GetCategories(ref string err, int iD)
        {
            List<Category> categories = categories = new List<Category>();
            SqlDataReader dataReader = data.MyExecuteDataReader(ref err, "PSP_Category_Select", CommandType.StoredProcedure, new SqlParameter("@ID", iD));
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    categories.Add(new Category()
                    {
                        ID = Convert.ToInt32(dataReader["ID"].ToString()),
                        Name = dataReader["Name"].ToString(),
                        Alias = dataReader["Alias"].ToString(),
                        ParentID = Convert.ToInt32(dataReader["ParentID"].ToString()),
                        CreateDate = Convert.ToDateTime(dataReader["CreateDate"].ToString()),
                        Order = Convert.ToInt32(dataReader["Order"].ToString()),
                        Status = Convert.ToBoolean(dataReader["Status"].ToString())
                    });
                }
            }
            return categories;
        }

        public Category GetCategoryByID(ref string err, int iD)
        {
            Category category = null;
            SqlDataReader dataReader = data.MyExecuteDataReader(ref err, "PSP_Category_Select", CommandType.StoredProcedure, new SqlParameter("@ID", iD));
            if (dataReader != null)
            {
                while (dataReader.Read())
                {
                    category = new Category()
                    {
                        ID = Convert.ToInt32(dataReader["ID"].ToString()),
                        Name = dataReader["Name"].ToString(),
                        Alias = dataReader["Alias"].ToString(),
                        ParentID = Convert.ToInt32(dataReader["ParentID"].ToString()),
                        CreateDate = Convert.ToDateTime(dataReader["CreateDate"].ToString()),
                        Order = Convert.ToInt32(dataReader["Order"].ToString()),
                        Status = Convert.ToBoolean(dataReader["ID"].ToString())
                    };
                }
            }
            return category;
        }

        public bool InsertUpdateCategory(ref string err, ref int rows, Category category)
        {
            SqlParameter[] param = new SqlParameter[] { 
                new SqlParameter("@ID",category.ID),
                 new SqlParameter("@Name",category.Name),
                  new SqlParameter("@Alias",category.Alias),
                   new SqlParameter("@ParentID",category.ParentID),
                    new SqlParameter("@CreateDate",category.CreateDate),
                     new SqlParameter("@Order",category.Order),
                     new SqlParameter("@Status",category.Status)
            };
            return data.MyExecuteNonQuery(ref err, ref rows, "PSP_Category_InsertUpdate", CommandType.StoredProcedure, param);
        }

        public bool DeleteCategory(ref string err, ref int rows, Category category)
        {
            SqlParameter[] param = new SqlParameter[] { 
                new SqlParameter("@ID",category.ID)
                
            };
            return data.MyExecuteNonQuery(ref err, ref rows, "PSP_Category_Delete", CommandType.StoredProcedure, param);
        }
    }
}
