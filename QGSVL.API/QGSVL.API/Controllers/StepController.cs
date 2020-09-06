using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QGSVL.BusinessLogicLayer.Interfaces;
using QGSVL.EntityLayer.Entities.DataEntity;
using QGSVL_WebAPI.Models.BusinessEntities;
using QGSVL_WebAPI.Models.DataEntities;

namespace QGSVL.API.Controllers
{
    [Authorize(Roles = "User")]
    [Route("api/[controller]")]
    [ApiController]
    public class StepController : ControllerBase
    {
        private readonly IStepService _stepService;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserManager<user> _userManager;
        private readonly Random _random;
        string WwwRootPath;
        public StepController(IStepService _stepService,
            IWebHostEnvironment _hostEnvironment,
            UserManager<user> _userManager)
        {
            this._stepService = _stepService;
            this._hostEnvironment = _hostEnvironment;
            this._userManager = _userManager;
            WwwRootPath = _hostEnvironment.WebRootPath;
            _random = new Random();
        }


        /// <summary>
        /// returns all the drop down values of creditcheck page from database
        /// </summary>
        /// <returns>complex type</returns>

        [HttpGet]
        [Route("CreditCheckValues")]
        public async Task<IActionResult> CreditCheckValues()
        {
            CreditCheckValuesVM values = await _stepService.CreditCheckValues(await GetCurrentUserEmail());
            return Ok(values);
        }

        /// <summary>
        /// submits the creditcheck values of a user into the database
        /// </summary>
        /// <param name="creditCheckVM"></param>
        /// <returns>status code</returns>

        [HttpPost]
        [Route("CreditCheck")]
        public async Task<IActionResult> CreditCheck(CreditCheckVM creditCheckVM)
        {
            if (await _stepService.CreditCheck(creditCheckVM, await GetCurrentUserEmail()))
                return Ok();
            else
                return BadRequest();
        }

        /// <summary>
        /// submits the direct debit value of a user into the database
        /// </summary>
        /// <param name="bankDetailVM"></param>
        /// <returns>status code</returns>

        [HttpPost]
        [Route("DirectDebit")]
        public async Task<IActionResult> DirectDebit([FromBody]BankDetailVM bankDetailVM)
        {
            if (!ModelState.IsValid || bankDetailVM.IbanNumber == null || bankDetailVM.QuoteId == null)
            {
                return BadRequest("Invalid Model State");
            }
            if (await _stepService.DirectDebit(bankDetailVM, await GetCurrentUserEmail()))
                return Ok();
            else
                return BadRequest();

        }

        /// <summary>
        /// saves the documents in the wwwroot and other values into the database
        /// </summary>
        /// <param name="drivingLicense"></param>
        /// <param name="certificateOfResidence"></param>
        /// <param name="identificationProof"></param>
        /// <param name="quoteId"></param>
        /// <remarks>it gives unique name to the documents for its identification</remarks>
        /// <remarks>path of document is stored in the database</remarks>
        /// <returns></returns>

        [HttpPost]
        [Route("SubmitDocuments")]
        public async Task<IActionResult> SubmitDocuments(IFormFile drivingLicense, IFormFile certificateOfResidence, IFormFile identificationProof, [FromForm]string quoteId)
        {
            Document DrivingLicense = await CreateDocument(drivingLicense, quoteId);
            Document CertificateOfResidence = await CreateDocument(certificateOfResidence, quoteId);
            Document IdentificationProof = await CreateDocument(identificationProof, quoteId);

            if (await _stepService.SubmitDocuments(DrivingLicense, CertificateOfResidence, IdentificationProof))
                return Ok();
            else
                return BadRequest();
        }

        /// <summary>
        /// saves the file in the wwwroot folder
        /// </summary>
        /// <param name="file"></param>
        /// <param name="quoteId"></param>
        /// <returns>Document</returns>
        [NonAction]
        public async Task<Document> CreateDocument(IFormFile file, string quoteId)
        {
            string FileName = Path.GetFileNameWithoutExtension(file.FileName);
            string Extension = Path.GetExtension(file.FileName);
            FileName = FileName + _random.Next(0,1000000).ToString() + Extension;
            string path1 = Path.Combine(WwwRootPath + "/Files/" + FileName);
            using (var FileStream = new FileStream(path1, FileMode.Create))
            {
                await file.CopyToAsync(FileStream);
            }
            Document document = new Document() { Path = FileName, QuoteId = int.Parse(quoteId) };
            return document;
        }

        /// <summary>
        ///  returns currently logged in user Email
        /// </summary>
        /// <returns>Email</returns>
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