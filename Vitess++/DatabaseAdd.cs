using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitess__
{
    public class DatabaseAdd
    {
        public void AddData(Data d)
        {
            using (DataDataContext context = new DataDataContext(DataDataContext.DBConnectionString))
            {
                context.datas.InsertOnSubmit(d);
                context.SubmitChanges();
            }
        }
    }
}
