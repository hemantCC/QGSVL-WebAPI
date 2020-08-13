using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QGSVL_WebAPI.Models.DataEntities
{
    [Table("tblMileage")]
    public class Mileage
    {
        [Key]
        public int Id { get; set; }
        public int MileageInKms { get; set; }
    }
}
