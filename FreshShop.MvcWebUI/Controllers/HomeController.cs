using FreshShop.Business.Abstract;
using FreshShop.Business.Concrete;
using FreshShop.Model.Entity;
using FreshShop.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FreshShop.MvcWebUI.Controllers
{
    public class HomeController  : Controller
    {
        private readonly IManagerBs _managerBs;
        public HomeController(IManagerBs managerBs)
        {
            _managerBs = managerBs;
        }

        public IActionResult Index()
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
