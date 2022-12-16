using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Newtonsoft.Json;
using PetShop.Models.CustomerModel;
using PetShop.Repository;
using System.Net;
using System.Threading.Tasks;

namespace PetShop.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomer_Repository _rep;
        
        public CustomerController(ICustomer_Repository rep)
        {
            _rep = rep;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(CustomerLoginModel customer)
        {
            var response = await _rep.Login(customer);
            return Json(JsonConvert.SerializeObject(response));
        }
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> SettingAccount(string token)
        {
            return View();
        }
    }
}
