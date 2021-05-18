using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BaseDb
    {
        public ThiASPDbContext context;
        public BaseDb()
        {
            context = new ThiASPDbContext();
        }
    }
}
