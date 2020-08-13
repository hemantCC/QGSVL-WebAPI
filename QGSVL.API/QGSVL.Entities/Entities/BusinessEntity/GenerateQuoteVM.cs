using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QGSVL_WebAPI.Models.BusinessEntities
{
    public class GenerateQuoteVM
    {
        public DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Mileage { get; set; }
        public int PaybackTime { get; set; }
        public int Total { get; set; }
        public string Prefix { get; set; }
        public string SelectedVehicle { get; set; }
        public bool IsMainDriver { get; set; }
    }
}
