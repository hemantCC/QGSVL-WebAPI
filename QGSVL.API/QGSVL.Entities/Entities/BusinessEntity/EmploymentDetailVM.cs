using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QGSVL_WebAPI.Models.BusinessEntities
{
    public class EmploymentDetailVM
    {
        public string EmployerName { get; set; }
        public string ContractType { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public int NetIncome { get; set; }
        public int RentalIncome { get; set; }
        public string PropertyStatus { get; set; }
        public int CreditCost { get; set; }
        public int MonthlyRent { get; set; }
        public DateTime StartDate { get; set; }
    }
}
