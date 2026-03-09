using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data.Services.Interface;
using WebApp.Models;
using WebApp.WebManager;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICompanys _companys;
        private readonly ISessionManager _sessionManager;

        public HomeController(ILogger<HomeController> logger, ICompanys _companys, ISessionManager _sessionManager)
        {
            _logger = logger;
            this._companys = _companys;
            this._sessionManager = _sessionManager;
        }

        public IActionResult Index()
        {

            return View();

        }

        public IActionResult Test()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
