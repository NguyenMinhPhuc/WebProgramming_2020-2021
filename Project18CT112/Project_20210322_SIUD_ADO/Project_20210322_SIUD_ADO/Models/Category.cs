using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_20210322_SIUD_ADO.Models
{
    public class Category
    {
        //ID, Name, Alias, ParentID, CreateDate, Order, Status
        [Display(Name="Mã Loại SP")]//Thuộc hiển thị tên của thuộc tính category.
        public int ID { get; set; }//ID tăng tự động trong sql 
        [DisplayName("Tên loại SP")]
        public string Name { get; set; }//tên của category
        public string Alias { get; set; }//bí danh
        public int ParentID { get; set; }//category cha
        public DateTime CreateDate { get; set; }
        public int Order { get; set; }// begin 1;
        public bool Status { get; set; }//1. đang sử dụng; 0: đã xóa
    }
}