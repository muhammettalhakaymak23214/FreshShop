using FreshShop.Model.Entity;
using FreshShop.MvcWebUI.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FreshShop.MvcWebUI.Areas.AdminPanel.Components
{
    public class LayoutSideBarViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
           
            Manager activeManager = HttpContext.Session.GetObject<Manager>("ActiveManager")!;

            return View(activeManager);
        }
    }
}
