using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductDb
    {
        Database data;
        public ProductDb()
        {
            data = new Database();
        }
        public List<Product> GetProducts(ref string err,string searchString,int categoryID)
        {
            List<Product> products = new List<Product>();
            SqlDataReader dr = data.MyExecuteDataReader(ref err, "PSP_Product_Searching", CommandType.StoredProcedure,
                new SqlParameter("@SearchString", searchString),
                new SqlParameter("@CategoryID", categoryID));
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
    }
}
