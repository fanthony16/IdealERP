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

                _sessionManager.SaveSessionObject(vwLogin.Email, "email");
                _sessionManager.SaveSessionObject(vwLogin.Password,"pwd");
                

                var validAccount = await _accountsvr.ValidateAccount(valLogin);

                if (validAccount != null && validAccount.Email.ToString() != "")
                {

                    var sessionValues = new Dictionary<string, string>
                    {
                        ["user"] = $"{validAccount.FirstName} {validAccount.LastName}",
                        ["page_title"] = "Dashboard",
                        ["userid"] = validAccount.UserID.ToString(),
                        ["organisationid"] = validAccount.OrganisationID.ToString()
                    };

                    foreach (var item in sessionValues)
                    {
                        _sessionManager.SaveSessionObject(item.Value, item.Key);
                    }

                    return RedirectToAction("Index","Home");

                }
                else
                {
                    if (validAccount.err == null)
                    {
                        ViewData["Message"] = validAccount.message;
                    }
                    else
                    {
                        ViewData["Message"] = validAccount.err.Message;
                    }
                    
                }

            }
            _sessionManager.ClearAllSession();
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
                    if (registeredUser != null && registeredUser.Email != "")
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
                    ViewData["Message"] = registeredUser.err.Message;
                }
                
            }
            catch (Exception ex)
            {

            }
            
            return View();
        }

        public IActionResult LogOut()
        {
            return View();
        }
    }
}
