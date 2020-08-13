using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using QGSVL.EntityLayer.Entities.DataEntity;

namespace QGSVL_WebAPI.Models.DataEntities
{
    [Table("tblBankDetail")]
    public class BankDetail
    {
        [Key]
        public int IbanId { get; set; }
        public Nullable<int> QuoteId { get; set; }
        public user User { get; set; }
        public string IbanNumber { get; set; }
    }
}
