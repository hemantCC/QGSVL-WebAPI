using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QGSVL.BusinessLogicLayer.Interfaces;
using QGSVL_WebAPI.Models.BusinessEntities;
using QGSVL_WebAPI.Models.DataEntities;

namespace QGSVL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private readonly IAdministratorService _administratorService;
        public AdministratorController(IAdministratorService _administratorService)
        {
            this._administratorService = _administratorService;
        }

        [HttpGet]
        [Route("GetAllQuotes")]
        public async Task<IActionResult> GetAllQuotes()
        {
            List<QuoteVM> quotesVMs = await _administratorService.GetAllQuotes();
            return Ok(quotesVMs);
        }

        [HttpGet]
        [Route("GetAllQuoteStatus")]
        public async Task<IActionResult> GetAllQuoteStatus()
        {
            IEnumerable<QuoteStatus> quoteStatuses = await _administratorService.GetAllQuoteStatus();
            return Ok(quoteStatuses);
        }

        [HttpPost]
        [Route("EditQuoteStatus")]
        public async Task<IActionResult> EditQuoteStatus(EditStatusVM editStatusVM)
        {
            if (await _administratorService.EditQuoteStatus(editStatusVM))
                return Ok();
            else
                return BadRequest();
        }
    }
}