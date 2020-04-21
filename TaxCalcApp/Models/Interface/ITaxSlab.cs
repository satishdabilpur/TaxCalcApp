using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalcApp.Models
{
    public interface ITaxSlab
    {
        List<TaxSlabRange> GetTaxSlabRanges();
    }
}
