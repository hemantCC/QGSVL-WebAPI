using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QGSVL_WebAPI.Models.DataEntities
{
    [Table("tblMaritalStatus")]
    public class MaritalStatus
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
