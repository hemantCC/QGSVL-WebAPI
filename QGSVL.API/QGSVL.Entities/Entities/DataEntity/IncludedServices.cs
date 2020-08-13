using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QGSVL_WebAPI.Models.DataEntities
{
    [Table("tblIncludedServices")]
    public class IncludedServices
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
