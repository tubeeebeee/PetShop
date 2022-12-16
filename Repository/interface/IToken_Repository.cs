using PetShop.Models.CustomerModel;

namespace PetShop.Repository
{
    public interface IToken_Repository
    {
        string BuildToken(string key, string issuer, CustomerLoginModel user);
        bool ValidateToken(string key, string issuer, string audience, string token);
    }
}
