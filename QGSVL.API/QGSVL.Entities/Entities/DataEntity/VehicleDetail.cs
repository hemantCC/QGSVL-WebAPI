using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QGSVL_WebAPI.Models.DataEntities
{
    [Table("tblVehicleDetail")]
    public class VehicleDetail
    {
        [Key]
        public int Id { get; set; }
        public string Image { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string ModelName { get; set; }
        public string HorsePower { get; set; }
        public string FuelConsumption { get; set; }
        public string CO2Emission { get; set; }
        public string FuelType { get; set; }
        public int Seating { get; set; }
        public Boolean ABS { get; set; }
        public int Airbag { get; set; }
        public string Transmission { get; set; }
        public string Colour { get; set; }
        public int Price { get; set; }

    }
}
