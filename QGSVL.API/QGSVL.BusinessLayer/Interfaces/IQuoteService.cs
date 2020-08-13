using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QGSVL_WebAPI.Models.BusinessEntities;
using QGSVL_WebAPI.Models.DataEntities;

namespace QGSVL.BusinessLogicLayer.Interfaces
{
    public interface IQuoteService
    {
        Task<IEnumerable<Quote>> GetUserQuotes(string Email);
        Task<Quote> GenerateQuote(GenerateQuoteVM quote, string Email);
    }
}
