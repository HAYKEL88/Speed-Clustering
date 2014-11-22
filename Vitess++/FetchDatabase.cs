using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitess__
{
    public class DataStrings
    {
        public string Id { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Speed { get; set; }
        public string DateOfPassage { get; set; }
        public string HeureOfPassage { get; set; }
    }


    public class FetchDatabase
    {
        public IList<Data> GetAllDatas()
        {
            IList<Data> list = null;
            using (DataDataContext context = new DataDataContext(DataDataContext.DBConnectionString))
            {
                IQueryable<Data> query = from c in context.datas select c;
                list = query.ToList();
            }
            return list;
        }
        public List<DataStrings> getDatas()
        {
            IList<Data> usrs = this.GetAllDatas();
            List<DataStrings> allmsgs = new List<DataStrings>();
            foreach (Data m in usrs)
            {
                DataStrings n = new DataStrings();
                n.Id = m.Id.ToString();
                n.Longitude      = "Longitude       : "+ m.Longitude.ToString("0.000000");
                n.Latitude       = "Latitude        : "+m.Latitude.ToString("0.000000");
                n.Speed          = "Speed           : "+ m.Speed.ToString("0.000000");
                n.DateOfPassage  = "Date of Passage : "+ m.DateOfPassage;
                n.HeureOfPassage = "Time of Passage : "+ m.HeureOfPassage;
                allmsgs.Add(n);
            }
            return allmsgs;
        }
    }
}
