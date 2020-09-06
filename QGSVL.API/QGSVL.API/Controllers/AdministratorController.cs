using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QGSVL.BusinessLogicLayer.Interfaces;
using QGSVL_WebAPI.Models.BusinessEntities;
using QGSVL_WebAPI.Models.DataEntities;

namespace QGSVL.API.Controllers
{
    [Authorize(Roles="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private readonly IAdministratorService _administratorService;
        public AdministratorController(IAdministratorService _administratorService)
        {
            this._administratorService = _administratorService;
        }


        /// <summary>
        /// returns all the quotes
        /// </summary>
        /// <returns>List of quotes</returns>
        [HttpGet]
        [Route("GetAllQuotes")]
        public async Task<IActionResult> GetAllQuotes()
        {
            List<QuoteVM> quotesVMs = await _administratorService.GetAllQuotes();
            if (quotesVMs == null)
            {
                return NotFound("No Records Found");
            }
            return Ok(quotesVMs);
        }

        /// <summary>
        /// returns all the available quote statuses 
        /// </summary>
        /// <returns>List of quote statuses</returns>
        [HttpGet]
        [Route("GetAllQuoteStatus")]
        public async Task<IActionResult> GetAllQuoteStatus()
        {
            IEnumerable<QuoteStatus> quoteStatuses = await _administratorService.GetAllQuoteStatus();
            if (quoteStatuses == null)
            {
                return NotFound("No Statuses Found.");
            }
            return Ok(quoteStatuses);
        }

        /// <summary>
        /// edits the existing quote status of a user
        /// </summary>
        /// <param name="editStatusVM"></param>
        /// <returns>status code</returns>
        [HttpPost]
        [Route("EditQuoteStatus")]
        public async Task<IActionResult> EditQuoteStatus(EditStatusVM editStatusVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _administratorService.EditQuoteStatus(editStatusVM);
                if (result)
                    return Ok("Edit Successful");
                else
                    return BadRequest("Internal Server Error");
            }
            else return BadRequest("Invalid Model State");
        }
    }
}