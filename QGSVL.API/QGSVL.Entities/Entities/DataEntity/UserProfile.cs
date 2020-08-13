using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QGSVL_WebAPI.Models.DataEntities
{
    [Table("tblUserProfile")]
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Contact { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Boolean IsMainDriver { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string RegistrationNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public Nationality Nationality { get; set; }
        public DateTime LivedSince { get; set; }

    }
}
