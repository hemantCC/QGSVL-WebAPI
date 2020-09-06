using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QGSVL_WebAPI.Models.BusinessEntities
{
    public class EditStatusVM
    {
        [Required]
        public int QuoteId { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
