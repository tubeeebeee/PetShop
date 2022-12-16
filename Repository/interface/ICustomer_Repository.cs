using PetShop.Models.CommonModel;
using PetShop.Models.CustomerModel;
using System.Threading.Tasks;

namespace PetShop.Repository
{
    public interface ICustomer_Repository
    {
        Task<ResponseModel> Login(CustomerLoginModel customer);
    }
}
