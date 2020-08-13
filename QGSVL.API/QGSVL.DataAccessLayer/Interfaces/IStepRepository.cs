using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QGSVL.EntityLayer.Entities.DataEntity;
using QGSVL_WebAPI.Models.BusinessEntities;
using QGSVL_WebAPI.Models.DataEntities;

namespace QGSVL.DataAccessLayer.Interfaces
{
    public interface IStepRepository
    {
        Task<CreditCheckValuesVM> CreditCheckValues(string Email);
        Task<bool> CreditCheck(CreditCheckVM creditCheckVM, string Email);
        Task<bool> DirectDebit(BankDetailVM bankDetailVM, string Email);
        Task<bool> SubmitDocuments(Document drivingLicense, Document certificateOfResidence, Document identificationProof);
        Task<UserProfile> GetUserProfileByUserEmail(string Email);
    }
}
