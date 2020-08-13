using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QGSVL_WebAPI.Models.DataEntities;

namespace QGSVL_WebAPI.Models.BusinessEntities
{
    public class CreditCheckValuesVM
    {
        public IEnumerable<MaritalStatus> maritalStatuses { get; set; }
        public IEnumerable<Nationality> nationalities { get; set; }
        public IEnumerable<EmploymentStatus> employmentStatuses { get; set; }
        public IEnumerable<ContractType> contractTypes { get; set; }
        public IEnumerable<PropertyStatus> propertyStatuses { get; set; }
        public RegisterUserVM user { get; set; }

    }
}
