using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data.Services;
using WebApp.Models.Dto;
using static WebApp.ViewModels.Account;

namespace WebApp.Controllers
{
    
    public class UserController : Controller
    {
        private readonly IAccountsvr _accountsvr;
        public UserController(IAccountsvr _accountsvr)
        {
            this._accountsvr = _accountsvr;
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
                var valLogin = new ValidateUser()
                {
                    Email = vwLogin.Email,
                    Password = vwLogin.Password
                };

                if (await _accountsvr.ValidateAccount(valLogin))
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

        [HttpPost]
        public async Task<IActionResult> Register(Register nwAccount)
        {
            try { 
            
                if (ModelState.IsValid)
                {
                    
                    if (await _accountsvr.RegisterAccount(nwAccount)) 
                    {
                        return RedirectToAction("Index");
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
