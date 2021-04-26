using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductDb:BasicDb
    {
        public List<Product> GetProducts(ref string err, int categoryID,string search)
        {
            List<Product> products = new List<Product>();

            SqlDataReader dr = data.MyExecuteDataReader(ref err, "PSP_Product_Search", CommandType.StoredProcedure, new SqlParameter("@CategoryID", categoryID),
                new SqlParameter("@Search", search));
            if(dr!=null)
            {
                while (dr.Read())
                {
                    products.Add(new Product()
                    {
                        ID=Convert.ToInt32(dr["ID"].ToString()),
                        Name = dr["Name"].ToString(),
                        Alias = dr["Alias"].ToString(),
                        CategoryID = Convert.ToInt32(dr["CategoryID"].ToString()),
                        CreateDate = Convert.ToDateTime(dr["CreateDate"].ToString()),
                        Images = dr["Images"].ToString(),
                        Detail = dr["Detail"].ToString(),
                        Price = Convert.ToDouble(dr["Price"].ToString()),
                        Status = Convert.ToBoolean(dr["Status"].ToString())
                       
                    });
                }
            }
            return products;
        }


        public List<Product> GetProductsC2(ref string err, int ID)
        {
            List<Product> products = new List<Product>();

            SqlDataReader dr = data.MyExecuteDataReader(ref err, "PSP_Product_Select", CommandType.StoredProcedure, new SqlParameter("@ID",ID));
            if (dr != null)
            {
                while (dr.Read())
                {
                    products.Add(new Product()
                    {
                        ID = Convert.ToInt32(dr["ID"].ToString()),
                        Name = dr["Name"].ToString(),
                        Alias = dr["Alias"].ToString(),
                        CategoryID = Convert.ToInt32(dr["CategoryID"].ToString()),
                        CreateDate = Convert.ToDateTime(dr["CreateDate"].ToString()),
                        Images = dr["Images"].ToString(),
                        Detail = dr["Detail"].ToString(),
                        Price = Convert.ToDouble(dr["Price"].ToString()),
                        Status = Convert.ToBoolean(dr["Status"].ToString())

                    });
                }
            }
            return products;
        }
        public Product GetProductByID(ref string err, int iD)
        {
            Product product =null;
            SqlDataReader dr = data.MyExecuteDataReader(ref err, "PSP_Product_Select", CommandType.StoredProcedure, new SqlParameter("@ID", iD));
            if (dr != null)
            {
                while (dr.Read())
                {
                    product = new Product()
                    {
                        ID = Convert.ToInt32(dr["ID"].ToString()),
                        Name = dr["Name"].ToString(),
                        Alias = dr["Alias"].ToString(),
                        CategoryID = Convert.ToInt32(dr["CategoryID"].ToString()),
                        CreateDate = Convert.ToDateTime(dr["CreateDate"].ToString()),
                        Images = dr["Images"].ToString(),
                        Detail = dr["Detail"].ToString(),
                        Price = Convert.ToDouble(dr["Price"].ToString()),
                        Status = Convert.ToBoolean(dr["Status"].ToString())

                    };
                }
            }
            return product;
        }

        public bool InsertUpdateProduct(ref string err, ref int rows,Product product)
        {
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ID",product.ID),
               new SqlParameter("@Name",product.Name),
               new SqlParameter("@Alias",product.Alias),
               new SqlParameter("@CategoryID",product.CategoryID),
               new SqlParameter("@CreateDate",product.CreateDate),
               new SqlParameter("@Images",product.Images),
               new SqlParameter("@Detail",product.Detail),
               new SqlParameter("@Price",product.Price),
               new SqlParameter("@Status",product.Status)
            };
            return data.MyExecuteNonQuery(ref err, ref rows, "PSP_Product_InsertUpdate", CommandType.StoredProcedure, param);
        }

        public bool DeleteProduct(ref string err, ref int rows, Product product)
        {
            SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@ID",product.ID)
            };
            return data.MyExecuteNonQuery(ref err, ref rows, "PSP_Product_Delete", CommandType.StoredProcedure, param);
        }
    }
}
