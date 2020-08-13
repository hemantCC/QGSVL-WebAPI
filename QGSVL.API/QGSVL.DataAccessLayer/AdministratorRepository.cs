using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QGSVL.DataAccessLayer.Interfaces;
using QGSVL.EntityLayer.Data;
using QGSVL_WebAPI.Models.BusinessEntities;
using QGSVL_WebAPI.Models.DataEntities;

namespace QGSVL.DataAccessLayer
{
    public class AdministratorRepository : IAdministratorRepository
    {
        private readonly ApplicationDbContext _context;
        public AdministratorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> EditQuoteStatus(EditStatusVM editStatusVM)
        {
            QuoteStatus status = await _context.QuoteStatus.Where(x => x.Name == editStatusVM.Status).FirstOrDefaultAsync();
            Quote quote = await _context.Quote.Where(x => x.Id == editStatusVM.QuoteId).Include("Car").Include("Insurance").Include("Mileage").Include("QuoteStatus").Include("PaybackTime").FirstOrDefaultAsync();
            quote.QuoteStatus = status;
            _context.Quote.Update(quote);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<QuoteStatus>> GetAllQuoteStatus()
        {
            return await _context.QuoteStatus.ToListAsync();
        }

        public async Task<List<QuoteVM>> GetAllQuotes()
        {
            List<Quote> quotes = await _context.Quote.Include("Car").Include("Insurance").Include("Mileage").Include("QuoteStatus").Include("PaybackTime").ToListAsync();
            List<QuoteVM> quotesVMs = new List<QuoteVM>();
            foreach (var quote in quotes)
            {
                QuoteVM quoteVM = new QuoteVM()
                {
                    Id = quote.Id,
                    Brand = quote.Car.Brand,
                    Model = quote.Car.ModelName,
                    RentalDate = quote.Date,
                    Insurance = quote.Insurance.Term,
                    Mileage = quote.Mileage.MileageInKms,
                    PaybackTime = quote.PaybackTime.PaybackInMonths,
                    TotalPrice = quote.TotalPrice,
                    QuoteStatus = quote.QuoteStatus.Name
                };
                quotesVMs.Add(quoteVM);
            }
            return quotesVMs;
        }
    }
}
