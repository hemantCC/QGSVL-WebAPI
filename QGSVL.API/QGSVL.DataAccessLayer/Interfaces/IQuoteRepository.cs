using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QGSVL_WebAPI.Models.BusinessEntities;
using QGSVL_WebAPI.Models.DataEntities;

namespace QGSVL.DataAccessLayer.Interfaces
{
    public interface IQuoteRepository
    {
        Task<IEnumerable<Quote>> GetUserQuotes(string Email);
        Task<Quote> GenerateQuote(GenerateQuoteVM quote, string Email);
        Task<UserProfile> GetUserProfileByUserEmail(string Email);
    }
}
