using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QGSVL.DataAccessLayer.Interfaces;
using QGSVL.EntityLayer.Data;
using QGSVL.EntityLayer.Entities.DataEntity;
using QGSVL_WebAPI.Models.BusinessEntities;
using QGSVL_WebAPI.Models.DataEntities;

namespace QGSVL.DataAccessLayer
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly ApplicationDbContext _context;
        public QuoteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// returns all quotes only for a requesting user
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Quote>> GetUserQuotes(string Email)
        {
            UserProfile user = await GetUserProfileByUserEmail(Email);
            IEnumerable<Quote> quotes = await _context.Quote.Include("Insurance")
                .Include("QuoteStatus").Include("PaybackTime").Include("Car").Include("Mileage").Where(x => x.User == user).OrderByDescending(x => x.Id).ToListAsync();
            return quotes;
        }

        public async Task<Quote> GenerateQuote(GenerateQuoteVM quote, string Email)
        {
            quote.Mileage = quote.Mileage * 1000;
            UserProfile userProfile = await GetUserProfileByUserEmail(Email);
            VehicleDetail vehicleDetail = await _context.VehicleDetail.Where(x => x.Id == Convert.ToInt32(quote.SelectedVehicle)).FirstOrDefaultAsync();
            Insurance insurance = await _context.Insurance.Where(x => x.Term == quote.PaybackTime).FirstOrDefaultAsync();
            Mileage mileage = await _context.Mileage.Where(x => x.MileageInKms == quote.Mileage).FirstOrDefaultAsync();
            QuoteStatus quoteStatus = await _context.QuoteStatus.Where(x => x.Name == "Pending").FirstOrDefaultAsync();
            PaybackTime paybackTime = await _context.PaybackTime.Where(x => x.PaybackInMonths == quote.PaybackTime).FirstOrDefaultAsync();

            if (!quote.IsMainDriver)
            {
                Driver driver = new Driver
                {
                    UserProile = userProfile,
                    Prefix = quote.Prefix,
                    FirstName = quote.FirstName,
                    LastName = quote.LastName,
                    DateOfBirth = quote.DateOfBirth
                };
                await _context.Driver.AddAsync(driver);
            }
            Quote quoteObj = new Quote
            {
                User = userProfile,
                Car = vehicleDetail,
                Date = DateTime.Now,
                Insurance = insurance,
                Mileage = mileage,
                TotalPrice = quote.Total,
                QuoteStatus = quoteStatus,
                PaybackTime = paybackTime
            };
            await _context.Quote.AddAsync(quoteObj);
            await _context.SaveChangesAsync();
            return quoteObj;
        }

        /// <summary>
        ///  returns currently logged in user profile
        /// </summary>
        /// <returns>User</returns>
        public async Task<UserProfile> GetUserProfileByUserEmail(string Email)
        {
            return await _context.UserProfile.Where(x => x.Email == Email).FirstOrDefaultAsync();
        }
    }
}
