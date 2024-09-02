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
            ProductVm vm = new ProductVm();
            vm.Products = _productBs.GetAll();
            vm.ProductPhoto = _productPhotoBs.GetAll();
            vm.Categories = _categoryBs.GetAll();

            return View(vm);
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
            p.ShortDesciription = vm.ShortDesciription;
            p.Price = vm.Price; 
            p.ProductName = vm.ProductName;
            p.Discount = vm.Discount;

            _productBs.Insert(p);

            return Json(new {isOk = true , productId=p.Id});
        }

        [HttpPost]
        public IActionResult PhotoUpload() 
        {
            IFormFileCollection files  = Request.Form.Files;

            var productId = Convert.ToInt32(Request.Form["prdId"].ToString());

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

                    ProductPhoto photo = new ProductPhoto();
                    photo.ProductId = productId;
                    photo.PhotoPath = "/AdminPanelContent/images/ProductPhotos/" + randomFileName;

                    _productPhotoBs.Insert(photo);
                    
                }
                return Json(new { IsOk=true});
            }

            return Json(new {IsOk=false});
        }

    }
}
