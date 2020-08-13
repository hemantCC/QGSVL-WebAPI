using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QGSVL_WebAPI.Models.BusinessEntities;

namespace QGSVL.DataAccessLayer.Interfaces
{
    public interface IAccountRepository
    {
        Task<bool> Register(RegisterUserVM registerUserVM);
        Task<string> Login(LoginVM loginVM);
        Task<bool> PopulateRoles();
    }
}
