using FreshShop.Business.Abstract;
using FreshShop.Model.Entity;
using FreshShop.Model.ViewModel;
using FreshShop.MvcWebUI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FreshShop.MvcWebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ProductController : Controller
    {

        private readonly IProductBs _productBs;
        private readonly IProductPhotoBs _productPhotoBs;
        private readonly ICategoryBs _categoryBs;

        public ProductController(IProductBs productBs, IProductPhotoBs productPhotoBs , ICategoryBs categoryBs)
        {
            _productBs = productBs;
            _productPhotoBs = productPhotoBs;
            _categoryBs = categoryBs;
        }

        public IActionResult Index()
        {
            //dsfdsfsdfdsddgfdgfdgfdg
            return View();
        }

        [HttpGet]
        public IActionResult New()
        {

            List<SelectListItem> categories = _categoryBs.GetAll().Select(x => new SelectListItem()
            {
                Text= x.CategoryName,

                Value = x.Id.ToString()

            }).ToList();

            categories.Insert(0,new SelectListItem() { Text = "Seçiniz..." , Value= "-1"});

            return View(categories);
        }
        [HttpPost]
        public IActionResult New(NewProductVm vm)
        {
            Product p = new Product();

            p.CategoryId = vm.CategoryId;
            p.ShortDescription= vm.ShortDescription;
            p.Price = vm.Price; 
            p.ProductName = vm.ProductName;
            p.Discount = vm.Discount;

            _productBs.Insert(p);

            return Json(new {IsOk = true , ProductId=p.Id});
        }

        [HttpPost]
        public IActionResult PhotoUpload() 
        {
            IFormFileCollection files  = Request.Form.Files;

            if (files.Count>0)
            {
                foreach (var file in files) 
                {
                    var randomFileName = RandomValueGenerator.GeneratorFileName(Path.GetExtension(file.FileName));

                    string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AdminPanelContent/images/ProductPhotos", randomFileName);

                    using (var stream = new FileStream(uploadPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    
                }
            }

            return Json(new {});
        }

    }
}
