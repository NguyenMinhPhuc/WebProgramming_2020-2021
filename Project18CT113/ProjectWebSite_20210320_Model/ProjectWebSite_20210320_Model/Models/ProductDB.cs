using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectWebSite_20210320_Model.Models
{
    public class ProductDb
    {
        private List<Product> list;//Field chua danh sach product; Tao properties bằng cách Ctrl+R+E;

        public List<Product> List
        {
            get { return list; }
            set { list = value; }
        }
        public ProductDb()//Ham tao (Constructor)
        {
            list = new List<Product>() { 
                new Product(){ ProductID=1,ProductName="Cafe",Quantity=20,Price=200000},
                new Product(){ ProductID=2,ProductName="Milk",Quantity=20,Price=250000},
                new Product(){ ProductID=3,ProductName="Sugar",Quantity=20,Price=500000}
            };
        }
    }
}