using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QGSVL_WebAPI.Models.BusinessEntities;
using QGSVL_WebAPI.Models.DataEntities;

namespace QGSVL.BusinessLogicLayer.Interfaces
{
    public interface IAdministratorService
    {
        Task<IEnumerable<QuoteStatus>> GetAllQuoteStatus();
        Task<List<QuoteVM>> GetAllQuotes();
        Task<bool> EditQuoteStatus(EditStatusVM editStatusVM);
    }
}
