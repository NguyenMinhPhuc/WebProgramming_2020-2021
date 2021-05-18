using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Models
{
    public class ProDb : BaseDb, IDisposable
    {

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
                context = null;
            }
        }

        public IEnumerable<tblPro> GetProducts()
        {
            return context.Database.SqlQuery<tblPro>("PSP_tblPro_Select").ToList();
        }

        public int DeleteProduct(int id)
        {
            return context.Database.ExecuteSqlCommand("PSP_tblPro_Delete @ProID", new SqlParameter("@ProID", id));
        }

        public int ChangeStatus(int id)
        {
            var result=context.Database.SqlQuery<int>("PSP_tblPro_ChangeStatus @ProID", new SqlParameter("@ProID", id)).SingleOrDefault();
            return result;
        }
    }
}
