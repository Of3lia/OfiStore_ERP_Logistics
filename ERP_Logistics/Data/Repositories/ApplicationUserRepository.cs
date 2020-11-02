using ERP_Logistics.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Logistics.Data.Repositories
{
    public class ApplicationUserRepository : GenericRepository<ApplicationUser, StoreContext>
    {
        private readonly ApplicationSettings _appSettings;
        private readonly StoreContext context;
        public ApplicationUserRepository(IOptions<ApplicationSettings> appSettings, StoreContext context) : base(context)
        {
            _appSettings = appSettings.Value;
            this.context = context;
        }

        public async Task<ApplicationUser> GetUserProfile(string userid)
        {

            return await context.ApplicationUsers
                                .Where(u => u.Id.ToString() == userid)
                                .Include(a => a.Address)
                                .FirstOrDefaultAsync();
        }

        public async Task<ApplicationUser> Register(ApplicationUser item)
        {
            var applicationUser = await context.ApplicationUsers.AddAsync(new ApplicationUser()
            {
                UserName = item.UserName,
                Email = item.Email,
                FullName = item.FullName,
                Role = UserRoles.Customer,
                Password = BCrypt.Net.BCrypt.HashPassword(item.Password),
                Address = new Address() { City="", Country="", Door = "", PostalCode = "", Street = "", StreetNumber = 0}
            });

            await context.SaveChangesAsync();
            return applicationUser.Entity;
        }

        public async Task<string> Login(ApplicationUser item)
        {
            var user = await context.ApplicationUsers.Where(u => u.UserName == item.UserName).FirstOrDefaultAsync();
            bool verified = BCrypt.Net.BCrypt.Verify(item.Password, user.Password);
            if (user != null && verified)
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("userid", user.Id.ToString()),
                        new Claim("role",user.Role.ToString()),
                        //new Claim("Role", user.Role.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);

                return token;
            }

            return "Error";
        }

        public async Task<List<ApplicationUser>> GetUsersProfiles([FromBody] ListModel listModel)
        {
            string role = "";

            switch (listModel.Role)
            {
                case UserRoles.Admin:
                    role = "0";
                    break;
                case UserRoles.Employee:
                    role = "1";
                    break;
                case UserRoles.Customer:
                    role = "2";
                    break;
                default:
                    role = "";
                    break;
            }

            return await context.ApplicationUsers
                .Where(u => ((string)((object)u.Role)).Contains(role))
                .Where(u => u.UserName.Contains(listModel.SearchUserName))
                .Skip(listModel.Skip)
                .Take(listModel.Take)
                //.AsNoTracking()
                .ToListAsync();
        }

        public async Task<ApplicationUser> UpdateUser(ApplicationUser userData)
        {
            var user = await context.ApplicationUsers.Where(u => u.Id == userData.Id).FirstOrDefaultAsync();

            if (user != null)
            {
                user.UserName = userData.UserName;
                user.FullName = userData.FullName;
                user.Email = userData.Email;

                if (user.Role != userData.Role)
                {
                    user.Role = userData.Role;
                }
                await context.SaveChangesAsync();

                return user;
            }
            return null;//not found
        }
    }
}
