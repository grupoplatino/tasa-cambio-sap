using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class csORTT
    {
        public DateTime RateDate { get; set; }
        public string Currency { get; set; }
        public double Rate { get; set; }
        public char DataSource { get; set; }
        public int UserSign { get; set; }
    }
}
