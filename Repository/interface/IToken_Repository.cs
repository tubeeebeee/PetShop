using PetShop.Areas.Customer.Models;
using PetShop.Models.CustomerModel;

namespace PetShop.Repository
{
    public interface IToken_Repository
    {
        string BuildToken(string key, string issuer, Customer user);
        bool IsTokenValid(string key, string issuer, string token);
    }
}
