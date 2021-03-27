using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Khai báo thêm namespace
using System.Data;
using System.Data.SqlClient;

namespace Project_20210327_SIUD_ADO.Models
{
    public class CategoryDb:BasicDb
    {
        public List<Category> GetCategories(ref string err)
        {
            List<Category> list = null;
            SqlDataReader dataReader = data.MyExecuteReader(ref err, "PSP_Category_GetCategories", CommandType.StoredProcedure, null);
            if(dataReader!=null)
            {
                list = new List<Category>();
                while (dataReader.Read())
                {
                    list.Add(
                        new Category()
                        {
                            ID=Convert.ToInt32(dataReader["ID"].ToString()),
                            Name = dataReader["Name"].ToString(),
                            Alias = dataReader["Alias"].ToString(),
                            ParentID = Convert.ToInt32(dataReader["ParentID"].ToString()),
                            CreateDate = Convert.ToDateTime(dataReader["CreateDate"].ToString()),
                            Order = Convert.ToInt32(dataReader["Order"].ToString()),
                            Status = Convert.ToBoolean(dataReader["Status"].ToString())
                        }
                        );
                }
            }
            return list;
        }

        public Category GetCategoryByID(ref string err,int id)
        {
            SqlDataReader dataReader = data.MyExecuteReader(ref err, "PSP_Category_GetCategoryByID", CommandType.StoredProcedure, 
                new SqlParameter("@ID",id));
            Category category=null;
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
                         Status = Convert.ToBoolean(dataReader["Status"].ToString())
                     };
                       
                }
            }
            return category;
        }

        public bool InsertUpdateCategory(ref string err,ref int rows,Category category)
        {
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@ID",category.ID),
                  new SqlParameter("@Name",category.Name),
                    new SqlParameter("@Alias",category.Alias),
                      new SqlParameter("@ParentID",category.ParentID),
                        new SqlParameter("@CreateDate",category.CreateDate),
                          new SqlParameter("@Order",category.Order),
                            new SqlParameter("@Status",category.Status)
            };
            return data.MyExecteNonQuery(ref err, ref rows, "PSP_Category_InsertUpdateCategory", CommandType.StoredProcedure, param);
        }

        public bool DeleteCategory(ref string err, ref int rows, Category category)
        {
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@ID",category.ID)
            };
            return data.MyExecteNonQuery(ref err, ref rows, "PSP_Category_DeleteByID", CommandType.StoredProcedure, param);
        }
    }
}