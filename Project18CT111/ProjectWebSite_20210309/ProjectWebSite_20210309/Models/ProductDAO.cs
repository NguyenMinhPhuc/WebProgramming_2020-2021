using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectWebSite_20210309.Models
{
    public class ProductDAO
    {
        public Product GetProduct()
        {
            return new Product()
            {
                ProductID=1,
                ProductName="Máy tính Asus",
                Quantity=20,
                Price=24000000
            };
        }

        public List<Product> GetProductList()
        {
            List<Product> list = new List<Product>();
            Product _product;
            for (int i = 0; i < 20; i++)
            {
                _product = new Product() {ProductID=i+1,ProductName=string.Format("product {0:00}",i+1),Quantity=new Random().Next(1,200),Price=new Random().Next(20000,2000000) };
                list.Add(_product);
            }
            return list;
        }

        public Product GetProductByID(int? ProductID)
        {
            List<Product> list = new List<Product>();
            Product _product;
            for (int i = 0; i < 20; i++)
            {
                _product = new Product() { ProductID = i + 1, ProductName = string.Format("product {0:00}", i + 1), Quantity = new Random().Next(1, 200), Price = new Random().Next(20000, 2000000) };
                list.Add(_product);
            }
            var Result = list.SingleOrDefault(x => x.ProductID == ProductID);
            return Result as Product;
        }
    }
}