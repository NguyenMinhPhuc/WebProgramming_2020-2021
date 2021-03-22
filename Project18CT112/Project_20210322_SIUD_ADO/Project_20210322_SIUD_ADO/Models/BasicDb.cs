using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_20210322_SIUD_ADO.Models
{
    public class BasicDb
    {
        //Khai báo một đối tượng database
        public Database data;
        public BasicDb()
        {
            data = new Database();
        }
        //Class này dùng để:
        //-1. Khai báo đối tượng thuộc class Database (đã đươc làm từ bước trước)
        //-2. Khởi tạo đối tượng data trong hàm tạo.
        //-3. Dùng cho lớp __Db khác kế thừa lại.
    }
}