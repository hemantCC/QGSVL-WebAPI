using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using QGSVL.DataAccessLayer.Interfaces;
using QGSVL.EntityLayer.Data;
using QGSVL.EntityLayer.Entities.DataEntity;
using QGSVL_WebAPI.Models.BusinessEntities;
using QGSVL_WebAPI.Models.DataEntities;

namespace QGSVL.DataAccessLayer
{
    public class AccountRepository : IAccountRepository
    {

        private readonly SignInManager<user> _signInManager;
        private readonly UserManager<user> _userManager;
        private readonly ApplicationSettings _applicationSettings;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public AccountRepository(SignInManager<user> signInManager,
            UserManager<user> userManager,
            IOptions<ApplicationSettings> applicationSettings,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _applicationSettings = applicationSettings.Value;
            _roleManager = roleManager;
            _context = context;
        }


        /// <summary>
        /// registers a new user 
        /// </summary>
        /// <param name="registerUserVM"></param>
        /// <returns>StatusCode</returns>
        public async Task<bool> Register(RegisterUserVM registerUserVM)
        {
            //call this line when roles are needed to be populated into the database 
            await PopulateRoles();
            var role = _roleManager.FindByNameAsync("User").Result; //Gets Role from Identity Role
            user user = new user()
            {
                UserName = registerUserVM.Email,
                Email = registerUserVM.Email,
                PhoneNumber = registerUserVM.Contact,
                Prefix = registerUserVM.Prefix,
                FirstName = registerUserVM.FirstName,
                LastName = registerUserVM.LastName
            };

            //creates user with user details
            var result = await _userManager.CreateAsync(user, registerUserVM.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, role.Name); // assigns role as User
                UserProfile userProfile = new UserProfile
                {
                    Email = registerUserVM.Email,
                    Prefix = registerUserVM.Prefix,
                    FirstName = registerUserVM.FirstName,
                    LastName = registerUserVM.LastName,
                    DateOfBirth = registerUserVM.DateOfBirth,
                    Contact = registerUserVM.Contact
                };
                _context.UserProfile.Add(userProfile);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// logs in the user with particular role
        /// </summary>
        /// <param name="loginVM"></param>
        /// <returns></returns>
        public async Task<string> Login(LoginVM loginVM)
        {
            var user = await _userManager.FindByEmailAsync(loginVM.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginVM.Password))
            {
                //Get the role of the user
                var role = await _userManager.GetRolesAsync(user);
                IdentityOptions _options = new IdentityOptions();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserId", user.Id.ToString()),
                        new Claim(_options.ClaimsIdentity.RoleClaimType, role.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                        _applicationSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256),
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);

                return token;
            }
            else
                return null;
        }

        //At the Initial Registration It populates Roles into AspNetRoles
        public async Task<bool> PopulateRoles()
        {
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (!await _roleManager.RoleExistsAsync("User"))
            {
                await _roleManager.CreateAsync(new IdentityRole("User"));
            }

            return true;

        }
    }
}
