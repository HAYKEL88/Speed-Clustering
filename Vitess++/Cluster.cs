using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitess__
{
    public class Cluster
    {
        public int idCluster;

        public int IdCluster
        {
            get { return idCluster; }
            set { idCluster = value; }
        }

        public List<Data> datas=new List<Data>();

        public List<Data> Datas
        {
            get { return datas; }
            set { datas = value; }
        }

    }
}
