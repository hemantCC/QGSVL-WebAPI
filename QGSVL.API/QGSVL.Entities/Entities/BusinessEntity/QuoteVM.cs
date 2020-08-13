using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QGSVL_WebAPI.Models.BusinessEntities
{
    public class QuoteVM
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime RentalDate { get; set; }
        public int Insurance { get; set; }
        public int Mileage { get; set; }
        public int PaybackTime { get; set; }
        public int TotalPrice { get; set; }
        public string QuoteStatus { get; set; }
    }
}
