using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_1_DataFromControllerToView.Models
{
    public class ProductDao
    {
        List<Product> list;//Khai báo biến kiểu danh sách (List<Product>) lưu trữ danh sách product.
        /// <summary>
        /// Hàm tạo: Khởi tạo giá trị cho danh sách sản phẩm
        /// trong bài tập hiện tại, danh sách sản phẩm được sinh ra tự động (không lấy từ database)
        /// </summary>
        public ProductDao()
        {
            Product p;
            list = new List<Product>();
            for (int i = 0; i < 20; i++)
            {
                p = new Product() { 
                    ProductID=i+1,
                    ProductName=string.Format("Sản phẩm{0}",+i+1),
                    Price=new Random().Next(10000000,20000000)
                };
                list.Add(p);
            }
        }
        /// <summary>
        /// PHương thức trả về giá trị danh sách sản phẩm
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProducts()
        {
            return list;
        }
        public Product GetProductByID(int ProductID)
        {
            Product _product = new Product();
            if(list!=null)
            {
                _product = list.SingleOrDefault(x => x.ProductID == ProductID);
            }
            return _product;
        }
    }
}