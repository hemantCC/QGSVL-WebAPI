using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QGSVL_WebAPI.Models.BusinessEntities;

namespace QGSVL.BusinessLogicLayer.Interfaces
{
    public interface IAccountService
    {
        Task<bool> Register(RegisterUserVM registerUserVM);
        Task<string> Login(LoginVM loginVM);
    }
}
