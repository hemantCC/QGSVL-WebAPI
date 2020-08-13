using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QGSVL_WebAPI.Models.BusinessEntities
{
    public class CreditCheckVM
    {
        public PersonalDetailVM PersonalDetails { get; set; }
        public EmploymentDetailVM EmploymentDetails { get; set; }
    }
}
