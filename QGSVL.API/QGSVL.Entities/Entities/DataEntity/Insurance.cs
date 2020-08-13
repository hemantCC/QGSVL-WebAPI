using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QGSVL_WebAPI.Models.DataEntities
{
    [Table("tblInsurance")]
    public class Insurance
    {
        [Key]
        public int Id { get; set; }
        public int Term { get; set; }
        public int Price { get; set; }
    }
}
