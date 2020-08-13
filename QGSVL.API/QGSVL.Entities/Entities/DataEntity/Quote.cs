using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QGSVL_WebAPI.Models.DataEntities
{
    [Table("tblQuote")]
    public class Quote
    {
        [Key]
        public int Id { get; set; }
        public UserProfile User { get; set; }
        public VehicleDetail Car { get; set; }
        public DateTime Date { get; set; }
        public Insurance Insurance { get; set; }
        public Mileage Mileage { get; set; }
        public int TotalPrice { get; set; }
        public QuoteStatus QuoteStatus { get; set; }
        public PaybackTime PaybackTime { get; set; }

    }
}
