using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QGSVL_WebAPI.Models.DataEntities
{
    [Table("tblEmployementDetail")]
    public class EmployementDetail
    {
        [Key]
        public int Id { get; set; }
        public UserProfile UserProfile { get; set; }
        public string EmployerName { get; set; }
        public ContractType ContractType { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime StartDate { get; set; }
        public EmploymentStatus EmploymentStatus { get; set; }
    }
}
