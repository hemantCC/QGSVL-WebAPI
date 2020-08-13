using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QGSVL.BusinessLogicLayer.Interfaces;
using QGSVL.DataAccessLayer.Interfaces;
using QGSVL_WebAPI.Models.BusinessEntities;

namespace QGSVL.BusinessLogicLayer
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<bool> Register(RegisterUserVM registerUserVM)
        {
            return await _accountRepository.Register(registerUserVM);
        }

        public async Task<string> Login(LoginVM loginVM)
        {
            return await _accountRepository.Login(loginVM);
        }
    }
}
