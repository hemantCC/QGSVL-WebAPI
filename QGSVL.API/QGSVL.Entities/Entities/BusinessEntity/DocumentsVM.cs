using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace QGSVL_WebAPI.Models.BusinessEntities
{
    public class DocumentsVM
    {
        public IFormFile DrivingLicense { get; set; }
        public IFormFile CertificateOfResidence { get; set; }
        public IFormFile IdentityProof { get; set; }
        public int QuoteId { get; set; }
    }
}
