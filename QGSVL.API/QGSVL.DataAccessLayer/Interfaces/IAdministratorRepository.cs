using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QGSVL_WebAPI.Models.BusinessEntities;
using QGSVL_WebAPI.Models.DataEntities;

namespace QGSVL.DataAccessLayer.Interfaces
{
    public interface IAdministratorRepository
    {
        Task<IEnumerable<QuoteStatus>> GetAllQuoteStatus();
        Task<List<QuoteVM>> GetAllQuotes();
        Task<bool> EditQuoteStatus(EditStatusVM editStatusVM);
    }
}
