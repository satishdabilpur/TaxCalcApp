using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalcApp.Models
{
    public class TaxSlab2019_2020 :ITaxSlab
    {
        public List<TaxSlabRange> GetTaxSlabRanges()
        {
            var taxslab = new List<TaxSlabRange>
            {
                new TaxSlabRange { Serial=1, LowRange = 0, HighRange = 250000, Percentage = 0 },
                new TaxSlabRange { Serial=2, LowRange = 250001, HighRange = 500000, Percentage = 5 },
                new TaxSlabRange { Serial=3, LowRange = 500001, HighRange = 1000000, Percentage = 20 },
                new TaxSlabRange { Serial=4, LowRange = 1000001, HighRange = int.MaxValue, Percentage = 30 }
            };
            return taxslab;
        }
    }
}
