using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using PetShop.Models.CustomerModel;
using PetShop.Areas.Customer.Models;

namespace PetShop.Repository.core
{
    public class Token_Repository: IToken_Repository
    {
        private const double EXPIRY_DURATION_MINUTES = 30;

        public string BuildToken(string key, string issuer, Customer user)
        {
            var claims = new[] {
                new Claim("FullName", user.FirstName + " " + user.LastName),
                new Claim("Pid", user.Pid.ToString()),
                new Claim("Email", user.Email),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims,
                expires: DateTime.Now.AddMinutes(EXPIRY_DURATION_MINUTES), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
        public bool IsTokenValid(string key, string issuer, string token)
        {
            var mySecret = Encoding.UTF8.GetBytes(key);
            var mySecurityKey = new SymmetricSecurityKey(mySecret);
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = issuer,
                    ValidAudience = issuer,
                    IssuerSigningKey = mySecurityKey,
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool ValidateToken(string key, string issuer, string audience, string token)
        {
            throw new NotImplementedException();
        }
    }
}
