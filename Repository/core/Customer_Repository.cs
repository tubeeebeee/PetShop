using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using PetShop.Areas.Customer.Models;
using PetShop.Data;
using PetShop.Models.CommonModel;
using PetShop.Models.CustomerModel;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Repository.core
{
    public class Customer_Repository : ICustomer_Repository
    {
        private readonly IConfiguration _config;
        private readonly DataContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Customer_Repository(IConfiguration config, DataContext db, IHttpContextAccessor httpContextAccessor)
        {
                _config = config;
                _db = db;
            _httpContextAccessor = httpContextAccessor;
        }

        private string GenerateJSONWebToken(CustomerLoginModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: "http://localhost:5000/", audience: "http://localhost:5000/", claims: null, expires: DateTime.Now.AddMinutes(60), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<ResponseModel> Login(CustomerLoginModel customerModel)
        {
            try
            {
                var tokenString = "";
                var customer = await _db.Customers.Where(x => x.Email == customerModel.Email && x.Enabled && x.Deleted == false).FirstOrDefaultAsync();
                
                if (customer != null)
                {
                    bool verified = BCrypt.Net.BCrypt.Verify(customerModel.Password, customer.Password);
                    tokenString = verified == true ? GenerateJSONWebToken(customerModel) : "";

                    
                    if (string.IsNullOrEmpty(tokenString))
                    {
                        return new ResponseModel { IsError = true, ResponseCode = "404", Message = "login fail", Token = "" };
                    }

                    //_httpContextAccessor.HttpContext.Request.Headers.Add("Authorization", $"Bearer {tokenString}");

                    return new ResponseModel { IsError = false, ResponseCode = "200", Message = "login success",Token = tokenString };

                }
                return new ResponseModel { IsError = true, ResponseCode = "404", Message = "login fail", Token = ""};
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
