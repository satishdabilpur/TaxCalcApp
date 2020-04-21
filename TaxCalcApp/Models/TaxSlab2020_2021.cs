using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalcApp.Models
{
    public class TaxSlab2020_2021 : ITaxSlab
    { 
        public List<TaxSlabRange> GetTaxSlabRanges()
        {
            var taxslab = new List<TaxSlabRange>
            {
                new TaxSlabRange { Serial=1, LowRange = 0, HighRange = 500000, Percentage = 0 },
                new TaxSlabRange { Serial=2, LowRange = 500001, HighRange = 750000, Percentage = 10 },
                new TaxSlabRange { Serial=3, LowRange = 750001, HighRange = 1000000, Percentage = 15 },
                new TaxSlabRange { Serial=4, LowRange = 1000001, HighRange = 1250000, Percentage = 20 },
                new TaxSlabRange { Serial=5, LowRange = 1250001, HighRange = 1500000, Percentage = 25 },
                new TaxSlabRange { Serial=6, LowRange = 1500001, HighRange = int.MaxValue, Percentage = 30 }
            };
            return taxslab;
        }
    }
}
