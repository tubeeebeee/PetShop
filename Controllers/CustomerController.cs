using Facebook;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PetShop.Models.CustomerModel;
using PetShop.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PetShop.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomer_Repository _rep;
        private readonly IToken_Repository _tokenService;
        private readonly IConfiguration _config;
        
        public CustomerController(ICustomer_Repository rep, IToken_Repository tokenService, IConfiguration config)
        {
            _rep = rep;
            _tokenService = tokenService;
            _config = config;
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
            if(!string.IsNullOrEmpty(response.Token))
            {
                HttpContext.Session.SetString("Token", response.Token);
                return RedirectToAction("SettingAccount");
            }
            else
            {
                return Json(JsonConvert.SerializeObject(response));
            }
        }
        [HttpPost]
        public IActionResult LoginWithFacebook(string token)
        {
            var absolutepath = Directory.GetCurrentDirectory();
            var filePath = Path.Combine(absolutepath + "\\wwwroot\\");
            var client = new Facebook.FacebookClient(token);
            dynamic response = client.Get("me?fields=id,name,email,picture");
            string fileName = response["name"];
            var url = response["picture"]["data"]["url"];
           
            using (WebClient c = new WebClient())
            {
                c.DownloadFile(new Uri(url), filePath + fileName + ".jpg");
               
            }
            return Json("");
        }

        [Authorize]
        [HttpGet]
        public IActionResult SettingAccount()
        {
            string token = HttpContext.Session.GetString("Token");
            if (token == null)
            {
                return (RedirectToAction("Login"));
            }
            if (!_tokenService.IsTokenValid(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), token))
            {
                return (RedirectToAction("Login"));
            }


            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                // or
                ViewBag.Pid = identity.FindFirst("Pid").Value;
                ViewBag.FullName = identity.FindFirst("FullName").Value;
                ViewBag.Email = identity.FindFirst("Email").Value;
                

            }
            ViewBag.Message = token;
            return View();
            
        }
    }
}
