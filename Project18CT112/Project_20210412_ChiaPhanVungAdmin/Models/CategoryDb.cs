using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CategoryDb
    {
        Database data;
        public CategoryDb()
        {
            data = new Database();
        }
        public List<Category> GetCategories()
        {
            List<Category> listCategory = new List<Category>();
            var sqlDataReader = data.MyExecuteReader("PSP_Category_Select", CommandType.StoredProcedure, null);
            if(sqlDataReader!=null)
            {
                while (sqlDataReader.Read())
                {
                    listCategory.Add(new Category() {
                        ID=Convert.ToInt32(sqlDataReader["ID"].ToString()),
                        Name = sqlDataReader["Name"].ToString()
                    });
                }
            }
            return listCategory;
        }
    }
}
