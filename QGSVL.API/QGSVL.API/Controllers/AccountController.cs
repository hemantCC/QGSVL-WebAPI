using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QGSVL.BusinessLogicLayer.Interfaces;
using QGSVL.DataAccessLayer.Interfaces;
using QGSVL_WebAPI.Models.BusinessEntities;

namespace QGSVL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        /// <summary>
        /// registers a new user 
        /// </summary>
        /// <param name="registerUserVM"></param>
        /// <returns>StatusCode</returns>
        [HttpPost]
        [Route("Register")]
        //POST : api/Account/Register
        public async Task<IActionResult> Register([FromBody]RegisterUserVM registerUserVM)
        {
            if (await _accountService.Register(registerUserVM))
                return Ok();
            else
                return BadRequest();
        }


        /// <summary>
        /// logs in the user with particular role
        /// </summary>
        /// <param name="loginVM"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        //POST : api/Account/Login
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            string token = await _accountService.Login(loginVM);
            if (token != null)
                return Ok(new { token });
            else
                return BadRequest(new { message = "Username or Password is incorrect." });
        }
    }
}