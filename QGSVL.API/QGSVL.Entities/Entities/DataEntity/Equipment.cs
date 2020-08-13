using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QGSVL_WebAPI.Models.DataEntities
{
    [Table("tblEquipment")]
    public class Equipment
    {
        [Key]
        public int Id { get; set; }
        public VehicleDetail Car { get; set; }
        public string EquipmentType { get; set; }
        public string Features { get; set; }
    }
}
