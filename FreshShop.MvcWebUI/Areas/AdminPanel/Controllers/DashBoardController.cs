using FreshShop.Model.Entity;
using FreshShop.MvcWebUI.Extensions;
using Microsoft.AspNetCore.Mvc;
using FreshShop.MvcWebUI.ActionFilters;

namespace FreshShop.MvcWebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class DashBoardController : Controller
    {
        [ActiveManagerAF]
        public IActionResult Index()
        {
            return View();
        }
    }
}
