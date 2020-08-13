using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QGSVL.BusinessLogicLayer.Interfaces;
using QGSVL.EntityLayer.Entities.DataEntity;
using QGSVL_WebAPI.Models.BusinessEntities;
using QGSVL_WebAPI.Models.DataEntities;

namespace QGSVL.API.Controllers
{
    [Authorize(Roles="User")]
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService _quoteService;
        private readonly UserManager<user> _userManager;
        public QuoteController(IQuoteService _quoteService,
            UserManager<user> _userManager)
        {
            this._quoteService = _quoteService;
            this._userManager = _userManager;
        }

        /// <summary>
        /// returns all quotes only for a requesting user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUserQuotes")]
        public async Task<IActionResult> GetUserQuotes()
        {
            IEnumerable<Quote> quotes = await _quoteService.GetUserQuotes(await GetCurrentUserEmail());
            if (quotes == null)
            {
                return NotFound("No Quotes Found");
            }
            return Ok(quotes);
        }

        [HttpPost]
        [Route("GenerateQuote")]
        public async Task<IActionResult> GenerateQuote(GenerateQuoteVM quote)
        {
            Quote quoteObj = await _quoteService.GenerateQuote(quote, await GetCurrentUserEmail());
            return Ok(quoteObj);
        }

        /// <summary>
        ///  returns currently logged in user profile
        /// </summary>
        /// <returns>User</returns>
        [NonAction]
        public async Task<string> GetCurrentUserEmail()
        {
            var id = "";
            var userCaimList = User.Claims.ToList();   //gets current User
            foreach (var item in userCaimList)
            {
                id = item.Value;
                break;
            }
            user user = await _userManager.FindByIdAsync(id);
            return user.Email;
        }
    }
}