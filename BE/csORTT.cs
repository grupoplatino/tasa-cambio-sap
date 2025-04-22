using System;

namespace BE
{
    public class csORTT
    {
        public DateTime RateDate { get; set; }
        public string Currency { get; set; }
        public double Rate { get; set; }
        public char DataSource { get; set; }
        public int UserSign { get; set; }
        public bool Update { get; set; }
    }
}
