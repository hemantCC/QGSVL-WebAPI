using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
    [Route("api/[controller]")]
    [ApiController]
    public class StepController : ControllerBase
    {
        private readonly IStepService _stepService;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserManager<user> _userManager;
        public StepController(IStepService _stepService,
            IWebHostEnvironment _hostEnvironment,
            UserManager<user> _userManager)
        {
            this._stepService = _stepService;
            this._hostEnvironment = _hostEnvironment;
            this._userManager = _userManager;
        }

        [HttpGet]
        [Route("CreditCheckValues")]
        public async Task<IActionResult> CreditCheckValues()
        {
            CreditCheckValuesVM values = await _stepService.CreditCheckValues(await GetCurrentUserEmail());
            return Ok(values);
        }

        [HttpPost]
        [Route("CreditCheck")]
        public async Task<IActionResult> CreditCheck(CreditCheckVM creditCheckVM)
        {
            if (await _stepService.CreditCheck(creditCheckVM, await GetCurrentUserEmail()))
                return Ok();
            else
                return BadRequest();
        }


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

        [HttpPost]
        [Route("SubmitDocuments")]
        public async Task<IActionResult> SubmitDocuments(IFormFile drivingLicense, IFormFile certificateOfResidence, IFormFile identificationProof, [FromForm]string quoteId)
        {
            string WwwRootPath = _hostEnvironment.WebRootPath;
            /*
             * Saves image to wwwroot/Images
             */
            //For DrivingLicense
            string FileName1 = Path.GetFileNameWithoutExtension(drivingLicense.FileName);
            string Extension1 = Path.GetExtension(drivingLicense.FileName);
            FileName1 = FileName1 + DateTime.Now.ToString("yymmssyyyy") + Extension1;
            string path1 = Path.Combine(WwwRootPath + "/Files/" + FileName1);
            using (var FileStream = new FileStream(path1, FileMode.Create))
            {
                await drivingLicense.CopyToAsync(FileStream);
            }
            Document DrivingLicense = new Document() { Path = FileName1, QuoteId = int.Parse(quoteId) };

            //For Certificate of Residence
            string FileName2 = Path.GetFileNameWithoutExtension(certificateOfResidence.FileName);
            string Extension2 = Path.GetExtension(certificateOfResidence.FileName);
            FileName2 = FileName2 + DateTime.Now.ToString("yymmssyyyy") + Extension2;
            string path2 = Path.Combine(WwwRootPath + "/Files/" + FileName2);
            using (var FileStream = new FileStream(path2, FileMode.Create))
            {
                await certificateOfResidence.CopyToAsync(FileStream);
            }
            Document CertificateOfResidence = new Document() { Path = FileName2, QuoteId = int.Parse(quoteId) };

            //For identificationProof
            string FileName3 = Path.GetFileNameWithoutExtension(identificationProof.FileName);
            string Extension3 = Path.GetExtension(identificationProof.FileName);
            FileName3 = FileName3 + DateTime.Now.ToString("yymmssyyyy") + Extension3;
            string path3 = Path.Combine(WwwRootPath + "/Files/" + FileName3);
            using (var FileStream = new FileStream(path3, FileMode.Create))
            {
                await identificationProof.CopyToAsync(FileStream);
            }
            Document IdentificationProof = new Document() { Path = FileName3, QuoteId = int.Parse(quoteId) };

            if (await _stepService.SubmitDocuments(DrivingLicense, CertificateOfResidence, IdentificationProof))
                return Ok();
            else
                return BadRequest();
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