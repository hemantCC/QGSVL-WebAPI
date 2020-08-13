using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QGSVL.DataAccessLayer.Interfaces;
using QGSVL.EntityLayer.Data;
using QGSVL.EntityLayer.Entities.DataEntity;
using QGSVL_WebAPI.Models.BusinessEntities;
using QGSVL_WebAPI.Models.DataEntities;

namespace QGSVL.DataAccessLayer
{
    public class StepRepository : IStepRepository
    {
        private readonly UserManager<user> _userManager;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public StepRepository(UserManager<user> userManager,
            IMapper mapper,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
        }

        public async Task<CreditCheckValuesVM> CreditCheckValues(string Email)
        {
            UserProfile userProfile = await GetUserProfileByUserEmail(Email);
            RegisterUserVM user = new RegisterUserVM
            {
                Prefix = userProfile.Prefix,
                FirstName = userProfile.FirstName,
                LastName = userProfile.LastName,
                Email = userProfile.Email,
                Contact = userProfile.Contact,
                DateOfBirth = userProfile.DateOfBirth
            };
            CreditCheckValuesVM values = new CreditCheckValuesVM
            {
                maritalStatuses = await _context.MaritalStatus.ToListAsync(),
                nationalities = await _context.Nationality.ToListAsync(),
                employmentStatuses = await _context.EmploymentStatus.ToListAsync(),
                contractTypes = await _context.ContractType.ToListAsync(),
                propertyStatuses = await _context.PropertyStatus.ToListAsync(),
                user = user
            };
            return values;
        }

        public async Task<bool> CreditCheck(CreditCheckVM creditCheckVM, string Email)
        {

            //check if record already exits
            UserProfile userProfile = await GetUserProfileByUserEmail(Email);
            bool recordExists = await _context.EmployementDetail.Where(x => x.UserProfile == userProfile).AnyAsync();

            /*
             Mapping all data
             */

            MaritalStatus maritalStatus = await _context.MaritalStatus.Where(x => x.Name == creditCheckVM.PersonalDetails.MaritalStatus).FirstOrDefaultAsync();
            Nationality nationality = await _context.Nationality.Where(x => x.Name == creditCheckVM.PersonalDetails.Nationality).FirstOrDefaultAsync();
            ContractType contractType = await _context.ContractType.Where(x => x.Name == creditCheckVM.EmploymentDetails.ContractType).FirstOrDefaultAsync();
            PropertyStatus propertyStatus = await _context.PropertyStatus.Where(x => x.Name == creditCheckVM.EmploymentDetails.PropertyStatus).FirstOrDefaultAsync();

            //Mapping Userprofile from PersonalDetails
            userProfile.MaritalStatus = maritalStatus;
            userProfile.Nationality = nationality;
            userProfile.RegistrationNumber = creditCheckVM.PersonalDetails.RegistrationNumber;
            userProfile.AddressLine1 = creditCheckVM.PersonalDetails.AddressLine1;
            userProfile.AddressLine2 = creditCheckVM.PersonalDetails.AddressLine2;
            userProfile.AddressLine3 = creditCheckVM.PersonalDetails.AddressLine3;
            userProfile.PostCode = creditCheckVM.PersonalDetails.PostCode;
            userProfile.City = creditCheckVM.PersonalDetails.City;
            userProfile.LivedSince = creditCheckVM.PersonalDetails.LivedSince;

            //Mapping to EmplomentDetails and RentalDetails
            EmployementDetail employementDetail = new EmployementDetail
            {
                UserProfile = userProfile,
                EmployerName = creditCheckVM.EmploymentDetails.EmployerName,
                ContractType = contractType,
                AddressLine1 = creditCheckVM.EmploymentDetails.AddressLine1,
                AddressLine2 = creditCheckVM.EmploymentDetails.AddressLine2,
                PostCode = creditCheckVM.EmploymentDetails.PostCode,
                City = creditCheckVM.EmploymentDetails.City,
                StartDate = creditCheckVM.EmploymentDetails.StartDate,
            };
            RentDetail rentDetail = new RentDetail
            {
                User = userProfile,
                NetIncomeInMonths = creditCheckVM.EmploymentDetails.NetIncome,
                RentalIncome = creditCheckVM.EmploymentDetails.RentalIncome,
                PropertyStatus = propertyStatus,
                MonthlyRent = creditCheckVM.EmploymentDetails.MonthlyRent,
                CreditCost = creditCheckVM.EmploymentDetails.CreditCost,
            };

            //save object if record does not exist 
            if (!recordExists)
            {
                _context.UserProfile.Update(userProfile);
                _context.EmployementDetail.Add(employementDetail);
                _context.RentDetail.Add(rentDetail);
                await _context.SaveChangesAsync();
                return true;
            }

            //modify object if record exist 
            if (recordExists)
            {
                EmployementDetail DomainEmployeeDetails = await _context.EmployementDetail.Where(x => x.UserProfile == userProfile).FirstOrDefaultAsync();
                _context.UserProfile.Update(userProfile);
                _context.EmployementDetail.Update(employementDetail);
                _context.RentDetail.Update(rentDetail);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DirectDebit(BankDetailVM bankDetailVM, string Email)
        {
            user User = await _context.User.Where(x => x.UserName == Email).FirstOrDefaultAsync();
            BankDetail bankDetail = _mapper.Map<BankDetailVM, BankDetail>(bankDetailVM);
            bankDetail.User = User;
            bankDetail.QuoteId = 1;

            _context.BankDetails.Add(bankDetail);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> SubmitDocuments(Document drivingLicense, Document certificateOfResidence, Document identificationProof)
        {
            drivingLicense.Type = await _context.DocumentTypes.Where(x => x.Name == "Driving License").FirstOrDefaultAsync();
            certificateOfResidence.Type = await _context.DocumentTypes.Where(x => x.Name == "Certificate Of Residence").FirstOrDefaultAsync();
            identificationProof.Type = await _context.DocumentTypes.Where(x => x.Name == "Identification Proof").FirstOrDefaultAsync();
            await _context.Documents.AddRangeAsync(drivingLicense, certificateOfResidence, identificationProof);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        ///  returns currently logged in user profile
        /// </summary>
        /// <returns>User</returns>
        public async Task<UserProfile> GetUserProfileByUserEmail(string Email)
        {
            return await _context.UserProfile.Where(x => x.Email == Email).FirstOrDefaultAsync();
        }

    }
}
