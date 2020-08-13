using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QGSVL_WebAPI.Models.DataEntities
{
    [Table("tblRentDetail")]
    public class RentDetail
    {
        [Key]
        public int Id { get; set; }
        public UserProfile User { get; set; }
        public int NetIncomeInMonths { get; set; }
        public int RentalIncome { get; set; }
        public PropertyStatus PropertyStatus { get; set; }
        public int CreditCost { get; set; }
        public int MonthlyRent { get; set; }

    }
}
