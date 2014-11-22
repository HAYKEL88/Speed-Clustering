using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitess__
{
    public class DataDataContext : DataContext
    {
        public static string DBConnectionString = @"isostore:/Databases.sdf";
        public DataDataContext(string connectionString)
            : base(connectionString)
        { }
        public Table<Data> datas
        {
            get
            {
                return this.GetTable<Data>();
            }
        }
    }
}
