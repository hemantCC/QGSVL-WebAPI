using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QGSVL.BusinessLogicLayer.Interfaces;
using QGSVL.DataAccessLayer.Interfaces;
using QGSVL_WebAPI.Models.BusinessEntities;
using QGSVL_WebAPI.Models.DataEntities;

namespace QGSVL.BusinessLogicLayer
{
    public class AdministratorService : IAdministratorService
    {
        private readonly IAdministratorRepository _administratorRepository;

        public AdministratorService(IAdministratorRepository _administratorRepository)
        {
            this._administratorRepository = _administratorRepository;
        }

        public async Task<bool> EditQuoteStatus(EditStatusVM editStatusVM)
        {
            return await _administratorRepository.EditQuoteStatus(editStatusVM);
        }


        public async Task<IEnumerable<QuoteStatus>> GetAllQuoteStatus()
        {
            return await _administratorRepository.GetAllQuoteStatus();
        }


        public async Task<List<QuoteVM>> GetAllQuotes()
        {
            return await _administratorRepository.GetAllQuotes();
        }
    }
}
