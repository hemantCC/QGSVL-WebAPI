using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QGSVL_WebAPI.Models.BusinessEntities
{
    public class PersonalDetailVM
    {
        public string MaritalStatus { get; set; }
        public string RegistrationNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Nationality { get; set; }
        public DateTime LivedSince { get; set; }
    }
}
