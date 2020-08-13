using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QGSVL.BusinessLogicLayer.Interfaces;
using QGSVL.DataAccessLayer.Interfaces;
using QGSVL.EntityLayer.Entities.DataEntity;
using QGSVL_WebAPI.Models.BusinessEntities;
using QGSVL_WebAPI.Models.DataEntities;

namespace QGSVL.BusinessLogicLayer
{
    public class StepService : IStepService
    {
        private readonly IStepRepository _stepRepository;
        public StepService(IStepRepository _stepRepository)
        {
            this._stepRepository = _stepRepository;
        }
        public async Task<bool> CreditCheck(CreditCheckVM creditCheckVM,string Email)
        {
            return await _stepRepository.CreditCheck(creditCheckVM, Email);
        }

        public async Task<CreditCheckValuesVM> CreditCheckValues(string Email)
        {
            return await _stepRepository.CreditCheckValues(Email);
        }

        public async Task<bool> DirectDebit(BankDetailVM bankDetailVM, string Email)
        {
            return await _stepRepository.DirectDebit(bankDetailVM, Email);
        }

        public async Task<bool> SubmitDocuments(Document drivingLicense, Document certificateOfResidence, Document identificationProof)
        {
            return await _stepRepository.SubmitDocuments(drivingLicense, certificateOfResidence, identificationProof);
        }
    }
}
