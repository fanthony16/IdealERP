using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data.Services;
using WebApp.Models.Dto;
using WebApp.WebManager;
using static WebApp.ViewModels.Account;

namespace WebApp.Controllers
{
    
    public class UserController : Controller
    {
        private readonly IAccountsvr _accountsvr;
        private readonly ISessionManager _sessionManager;
        public UserController(IAccountsvr _accountsvr, ISessionManager _sessionManager)
        {
            this._accountsvr = _accountsvr;
            this._sessionManager = _sessionManager;
        }
        public IActionResult Index()
        {

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Index(Login vwLogin)
        {
            if (ModelState.IsValid)
            {
                var valLogin = new User.ValidateUser()
                {
                    Email = vwLogin.Email,
                    Password = vwLogin.Password
                };

                if (await _accountsvr.ValidateAccount(valLogin) is not null)
                {
                    
                    return RedirectToAction("Index","Home");

                }

            }
            ViewData["Message"] = "User name or Password is Incorrect";
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Welcome()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register nwAccount)
        {
            try { 
            
                if (ModelState.IsValid)
                {

                    var registeredUser = await _accountsvr.RegisterAccount(nwAccount);
                    if (registeredUser != null)
                    {

                        var sessionValues = new Dictionary<string, string>
                        {
                            ["user"] = $"{nwAccount.First_name} {nwAccount.Last_name}",
                            ["page_title"] = string.Empty,
                            ["userid"] = registeredUser.UserID.ToString()
                        };

                        foreach (var item in sessionValues)
                        {
                            _sessionManager.SaveSessionObject(item.Value, item.Key);
                        }

                        return RedirectToAction("Welcome");

                    }
                }

            }
            catch (Exception ex)
            {

            }
            //return RedirectToAction("Register", ModelState);
            return View();
        }

        public IActionResult LogOut()
        {
            return View();
        }
    }
}
