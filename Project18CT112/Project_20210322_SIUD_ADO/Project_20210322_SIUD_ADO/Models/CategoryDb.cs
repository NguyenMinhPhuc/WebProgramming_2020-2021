using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Project_20210322_SIUD_ADO.Models
{
    public class CategoryDb:BasicDb
    {
        public CategoryDb():base()
        { }
        /// <summary>
        /// Phương thức Lấy danh sách Category từ database Sql Server
        /// </summary>
        /// <param name="err">tham số tham chiếu lưu lỗi</param>
        /// <returns>Danh sách Category được trả về</returns>
        public List<Category> GetCategories(ref string err)
        {
            //Khai báo biến list dạng danh sách kiểu Category.
            List<Category> list = new List<Category>();
            //Khai báo đối tượng SqlDataReader để nhận giá trị trả về từ phương thức thực thi thủ tục đươc viết trong class Database ở bước trước.
            var dataReader = data.MyExcuteReader(ref err, "PSP_Category_GetCategories", CommandType.StoredProcedure, null);
           //Đọc giá trị sau khi đã nhận được kết quả
            if (dataReader != null){
                while (dataReader.Read()){
                    list.Add(
                        new Category(){
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
            return list;
        }
        /// <summary>
        /// Phương thức lấy Category theo ID 
        /// </summary>
        /// <param name="err">Tham số tham chiếu lưu lỗi</param>
        /// <param name="ID">mã số của Category muốn lấy</param>
        /// <returns></returns>
        public Category GetCategoryByID(ref string err, int ID)
        {
            Category category = null; //Khởi tạo đối tượng category, 
            var dataReader = data.MyExcuteReader(ref err, "PSP_Category_GetCategoryByID", CommandType.StoredProcedure, new SqlParameter("@ID",ID));//Gọi thủ tục lấy 1 category theo ID từ SQL.
            if (dataReader != null)//Kiểm tra giá trị trả về
            {
                while (dataReader.Read())
                {//Gán giá trị cho những thuộc tính của Category
                    category = new Category();
                    category.ID = Convert.ToInt32(dataReader["ID"].ToString());
                    category.Name = dataReader["Name"].ToString();
                    category.Alias = dataReader["Alias"].ToString();
                    category.ParentID = Convert.ToInt32(dataReader["ParentID"].ToString());
                    category.CreateDate = Convert.ToDateTime(dataReader["CreateDate"].ToString());
                    category.Order = Convert.ToInt32(dataReader["Order"].ToString());
                    category.Status = Convert.ToBoolean(dataReader["Status"].ToString());
                }
            }
            return category;//Trả về đối tượng Category tìm được
        }
        /// <summary>
        /// Phương thức thực hiên thao tác insert Category vào trong database
        /// </summary>
        /// <param name="err">Tham số tham chiếu lưu lỗi</param>
        /// <param name="rows">Tham số tham chiếu lưu số dòng thực hiện thành công</param>
        /// <param name="category">Đối tượng Category</param>
        /// <returns>Thực hiện thành công trả về : true; ngược lại trả về false</returns>
        public bool InsertCategory(ref string err,ref int rows,Category category)
        {
            return data.MyExcuteNonQuery(ref err, ref rows, "PSP_Category_InsertUpdateCategory", CommandType.StoredProcedure,
                   new SqlParameter("@ID", category.ID),
                   new SqlParameter("@Name", category.Name),
                 new SqlParameter("@Alias", category.Alias),
                  new SqlParameter("@ParentID", category.ParentID),
                  new SqlParameter("@CreateDate", category.CreateDate),
                   new SqlParameter("@Order", category.Order),
                    new SqlParameter("@Status", category.Status));
        }
        /// <summary>
        /// Phương thức thực hiên thao tác Update Category vào trong database
        /// </summary>
        /// <param name="err">Tham số tham chiếu lưu lỗi</param>
        /// <param name="rows">Tham số tham chiếu lưu số dòng thực hiện thành công</param>
        /// <param name="category">Đối tượng Category</param>
        /// <returns>Thực hiện thành công trả về : true; ngược lại trả về false</returns>
        public bool UpdateCategory(ref string err, ref int rows, Category category)
        {
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@ID",category.ID),
                 new SqlParameter("@Name",category.Name),
                 new SqlParameter("@Alias", category.Alias),
                  new SqlParameter("@ParentID", category.ParentID),
                  new SqlParameter("@CreateDate", category.CreateDate),
                   new SqlParameter("@Order", category.Order),
                    new SqlParameter("@Status", category.Status)
            };
            return data.MyExcuteNonQuery(ref err, ref rows, "PSP_Category_InsertUpdateCategory", CommandType.StoredProcedure, param);
        }
        /// <summary>
        /// PHương thức xóa Category
        /// </summary>
        /// <param name="err">Tham số tham chiếu lưu lỗi</param>
        /// <param name="rows">Tham số tham chiếu lưu số dòng thực hiện thành công</param>
        /// <param name="category">Đối tượng Category</param>
        /// <returns></returns>
        public bool DeleteCategoryByID(ref string err, ref int rows, Category category)
        {
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@ID",category.ID)
            };
            return data.MyExcuteNonQuery(ref err, ref rows, "PSP_Category_DeleteByID", CommandType.StoredProcedure, param);
        }
    }
}