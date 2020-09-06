using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QGSVL_WebAPI.Models.BusinessEntities;

namespace QGSVL.DataAccessLayer.Interfaces
{
    //handles account related actions
    public interface IAccountRepository
    {
        /// <summary>
        /// saves the registration user's data into the database
        /// </summary>
        /// <param name="registerUserVM"></param>
        /// <returns>boolean</returns>
        Task<bool> Register(RegisterUserVM registerUserVM);

        /// <summary>
        /// log in the user and send generated token 
        /// </summary>
        /// <param name="loginVM"></param>
        /// <returns>token</returns>
        Task<string> Login(LoginVM loginVM);

        /// <summary>
        /// populates the role after the database creating
        /// </summary>
        /// <returns></returns>
        Task<bool> PopulateRoles();
    }
}
