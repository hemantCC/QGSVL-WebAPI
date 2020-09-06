using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QGSVL_WebAPI.Models.BusinessEntities;
using QGSVL_WebAPI.Models.DataEntities;

namespace QGSVL.DataAccessLayer.Interfaces
{
    public interface IAdministratorRepository
    {
        /// <summary>
        /// gives quote status 
        /// </summary>
        /// <returns>list of quote status</returns>
        Task<IEnumerable<QuoteStatus>> GetAllQuoteStatus();

        /// <summary>
        /// gives all the quotes of all the users
        /// </summary>
        /// <returns></returns>
        Task<List<QuoteVM>> GetAllQuotes();

        /// <summary>
        /// edits the existing quote for a user into the database
        /// </summary>
        /// <param name="editStatusVM"></param>
        /// <returns>boolean</returns>
        Task<bool> EditQuoteStatus(EditStatusVM editStatusVM);
    }
}
