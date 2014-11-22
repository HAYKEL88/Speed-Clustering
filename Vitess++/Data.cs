using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitess__
{
    [Table]
    public class Data
    {

        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int Id { get; set; }

        [Column]
        public double Speed { get; set; }

        [Column]
        public double Longitude { get; set; }

        [Column]
        public double Latitude { get; set; }

        [Column]
        public String DateOfPassage { get; set; }

        [Column]
        public String HeureOfPassage { get; set; }


       
    }
}
