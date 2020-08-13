using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QGSVL_WebAPI.Models.DataEntities
{
    [Table("tblDocument")]
    public class Document
    {
        [Key]
        public int Id { get; set; }
        public DocumentType Type { get; set; }
        public string Path { get; set; }
        public int QuoteId { get; set; }
    }
}
