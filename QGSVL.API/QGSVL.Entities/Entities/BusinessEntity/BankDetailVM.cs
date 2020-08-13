using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QGSVL_WebAPI.Models.BusinessEntities
{
    public class BankDetailVM
    {
        public Nullable<int> QuoteId { get; set; }
        public string IbanNumber { get; set; }
    }
}
