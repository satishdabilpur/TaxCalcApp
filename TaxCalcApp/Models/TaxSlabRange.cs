using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalcApp.Models
{
    public class TaxSlabRange
    {
        public int Serial { get; set; }
        public int LowRange { get; set; }
        public int HighRange { get; set; }
        public int Percentage { get; set; }
    }
}
