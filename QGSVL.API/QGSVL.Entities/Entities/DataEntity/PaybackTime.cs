using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QGSVL_WebAPI.Models.DataEntities
{
    [Table("tblPaybackTime")]
    public class PaybackTime
    {
        [Key]
        public int Id { get; set; }
        public int PaybackInMonths { get; set; }
    }
}
