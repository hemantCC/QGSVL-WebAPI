using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QGSVL.BusinessLogicLayer.Interfaces;
using QGSVL.DataAccessLayer.Interfaces;
using QGSVL_WebAPI.Models.BusinessEntities;
using QGSVL_WebAPI.Models.DataEntities;

namespace QGSVL.BusinessLogicLayer
{
    public class QuoteService : IQuoteService
    {
        private readonly IQuoteRepository _quoteRepository;
        public QuoteService(IQuoteRepository _quoteRepository)
        {
            this._quoteRepository = _quoteRepository;
        }
        public async Task<Quote> GenerateQuote(GenerateQuoteVM quote, string Email)
        {
            return await _quoteRepository.GenerateQuote(quote, Email);
        }

        public async Task<IEnumerable<Quote>> GetUserQuotes(string Email)
        {
            return await _quoteRepository.GetUserQuotes(Email);
        }
    }
}
