using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjectWeb_20210323_SIUD_ADO.Models
{
    public class CategoryDb
    {
        private Database data;//khai báo đối tượng Database
        //hàm tạo để khởi tạo đối tượng Database
        public CategoryDb()
        {
            data = new Database();
        }
        #region Method
        public List<Category> GetCategories(ref string err)
        {
            List<Category> list = null;
            var dataReader = data.MyExecuteReader(ref err, "PSP_Category_GetCategories", CommandType.StoredProcedure, null);
            if(dataReader!=null)
            {
                list = new List<Category>();
                while (dataReader.Read())
                {
                    list.Add(
                        new Category()
                        {
                            ID=Convert.ToInt32(dataReader["ID"]),
                            Name=dataReader["Name"].ToString(),
                            Alias=dataReader["Alias"].ToString(),
                            CreateDate=Convert.ToDateTime(dataReader["CreateDate"].ToString()),
                            ParentID=Convert.ToInt32(dataReader["ParentID"].ToString()),
                            Order=Convert.ToInt32(dataReader["Order"].ToString()),
                            Status=Convert.ToBoolean(dataReader["Status"].ToString())
                        });
                }
            }
            return list;
        }

        public Category GetCategoryByID(ref string err,int id)
        {
            Category category=null;
            var dataReader = data.MyExecuteReader(ref err, "PSP_Category_GetCategoryByID", CommandType.StoredProcedure, new SqlParameter("@ID", id));
            if (dataReader != null)
            { 
                while(dataReader.Read())
                {
                    category = new Category();
                   category.ID=Convert.ToInt32(dataReader["ID"]);
                            category.Name=dataReader["Name"].ToString();
                            category.Alias=dataReader["Alias"].ToString();
                            category.CreateDate=Convert.ToDateTime(dataReader["CreateDate"].ToString());
                            category.ParentID=Convert.ToInt32(dataReader["ParentID"].ToString());
                            category.Order=Convert.ToInt32(dataReader["Order"].ToString());
                            category.Status = Convert.ToBoolean(dataReader["Status"].ToString());
                }
            }
            return category;
        }

        public bool InserCategory(ref string err, ref int rows, Category category)
        {
            SqlParameter[] param = new SqlParameter[] {
             new SqlParameter("@ID", category.ID),
             new SqlParameter("@Name", category.Name),
             new SqlParameter("@Alias", category.Alias),
             new SqlParameter("@CreateDate", category.CreateDate),
             new SqlParameter("@Order", category.Order),
             new SqlParameter("@Status", category.Status),
             new SqlParameter("@ParentID", category.ParentID)
            };

            return data.MyExecuteNonQuery(ref err, ref rows, "PSP_Category_InsertUpdateCategory", CommandType.StoredProcedure,
               param);
        }
        #endregion
    }
}