using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   
        public class BaseDb
        {
            protected Database data;
            public BaseDb()
            {
                data = new Database();
            }
        }
    

}
