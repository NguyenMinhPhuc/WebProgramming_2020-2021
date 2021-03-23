using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectWeb_20210323_SIUD_ADO.Models
{
    public class Category
    {
        public int ID { get; set; }//mã danh mục ,identity(1,1)
        public string Name { get; set; }//Tên danh mục
        public string Alias { get; set; }//tên không dấu
        public int ParentID { get; set; }//danh mục Cha
        public DateTime CreateDate { get; set; }
        public int Order { get; set; } //Thứ tự
        public bool Status { get; set; }//1: đang sử dụng; 0: đã xóa
    }
}