using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_20210327_SIUD_ADO.Models
{
    public class Category
    {
        //ID, Name, Alias, ParentID, CreateDate, Order, Status
        public int ID { get; set; }//mã tăng tự động trong SQL
        public string Name { get; set; }//tên danh mục SP
        public string Alias { get; set; }//tên không dấu
        public int ParentID { get; set; }//danh mục cha
        public DateTime CreateDate { get; set; }//Ngày tạo
        public int Order { get; set; }//Thứ tự sắp xếp
        public bool Status { get; set; }//trạng thái
    }
}