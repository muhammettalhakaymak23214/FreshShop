using FreshShop.Business.Abstract;
using FreshShop.Model.Entity;
using FreshShop.Model.ViewModel;
using FreshShop.MvcWebUI.Extensions;
using FreshShop.MvcWebUI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;


namespace FreshShop.MvcWebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ManagerController : Controller
    {
        private readonly IManagerBs _managerBs; 

        public ManagerController(IManagerBs managerBs)
        {
            _managerBs = managerBs;
        }

        [HttpGet]
        public IActionResult Login()
        {
            string? cookie_UN = Request.Cookies["ActiveManagerUN_CK"];
            string? cookie_PW = Request.Cookies["ActiveManagerPW_CK"];
            if ((!string.IsNullOrEmpty(cookie_UN)) && (!string.IsNullOrEmpty(cookie_PW)))
            {
                ViewData["cookie_UN"] = cookie_UN;
                ViewData["cookie_PW"] = cookie_PW;
                ViewData["chIsChecked"] = true;
            }
            else
            {
                ViewData["chIsChecked"] = false;
            }

            return View();
        }

        [HttpPost]
        public IActionResult Login(ManagerLogInVm vm)
        {
            if (!ModelState.IsValid)
            {
                var errorMessages = "";
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errorMessages += error.ErrorMessage + "<br/>";
                    }
                }
                return Json(new {isOk = false , Message = errorMessages});
            }

            Manager manager = _managerBs.Login(vm.UserName!,vm.Password!);

            if (manager != null) {
                if (vm.RememberMe)
                {
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.Now.AddDays(2);  
                    Response.Cookies.Append("ActiveManagerUN_CK",vm.UserName!,options);
                    Response.Cookies.Append("ActiveManagerPW_CK", vm.Password!,options);
                }
                else
                {
                    Response.Cookies.Delete("ActiveManagerUN_CK");
                    Response.Cookies.Delete("ActiveManagerPW_CK");
                }

               
                HttpContext.Session.SetObject("ActiveManager", manager);

                return Json(new {IsOk = true});
            }

            return Json(new { IsOk= false,Massage="Kullanıcı Bulunumadı"});
        }

        [HttpPost]
        public IActionResult ForgatPassword(ManagerForgatPasswordVm vm)
        {
            Manager manager = _managerBs.GetByEmail(vm.Email);

            if (manager != null)
            {
                string message = $"Sayın {manager.FullName}. Şifreniz : <b>{manager.Password}</b>";
                MailHelper.SendMail(vm.Email,"Şifreniz" , message);
                return Json(new { IsOk = true, Message = "Şifreniz email hesabınıza gönderilmiştir." });
            }
            else
            {
                return Json(new { IsOk = false, Message = "Bu email hesabı ile kayıt bulunamadı." });
            }

        }

        public IActionResult Index()
        {
            List<Manager> managers = _managerBs.GetAll();
            return View(managers);
        }
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public IActionResult New(Manager vm)
        {
            _managerBs.Insert(vm);
            return Json(new {isOk=true,Message="Yönetici başarıyla yüklendi."});
        }
        [HttpPost]
        public IActionResult PhotoUpload()
        {
            IFormFileCollection files = Request.Form.Files;
            if (files.Count > 0)
            {
                var fileName = files[0].FileName;
                var contentType = files[0].ContentType;
                var length = files[0].Length;

                if (!contentType.StartsWith("image/"))
                {
                    return Json(new { isOk = false, Message = "Lütfen resim dosyası seçiniz." });
                }

                var randomFileName = RandomValueGenerator.GeneratorFileName(Path.GetExtension(fileName));

                string uploadPath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/AdminPanelContent/images/ManagerPhotos", randomFileName);

                using (var stream = new FileStream(uploadPath,FileMode.Create))
                {
                    files[0].CopyTo(stream);
                }
                return Json(new {isOk = true ,photoPath = "/AdminPanelContent/images/ManagerPhotos/"+randomFileName});
            }
            else
            {
                return Json(new {isOk=false,Message="Lütfen fotoğraf seçiniz."});
            }

            return Json(new {  });
        }
        [HttpPost]
        public IActionResult PhotoUpload2()
        {
            IFormFileCollection files = Request.Form.Files;
            var eskiPhotoPath = Request.Form["eskiPhotoPath"].ToString();
            if (files.Count > 0)
            {
                var fileName = files[0].FileName;
                var contentType = files[0].ContentType;
                var length = files[0].Length;
                

                if (!contentType.StartsWith("image/"))
                {
                    return Json(new { isOk = false, Message = "Lütfen resim dosyası seçiniz." });
                }

                var randomFileName = RandomValueGenerator.GeneratorFileName(Path.GetExtension(fileName));

                string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AdminPanelContent/images/ManagerPhotos", randomFileName);

                using (var stream = new FileStream(uploadPath, FileMode.Create))
                {
                    files[0].CopyTo(stream);
                }
                return Json(new { isOk = true, photoPath = "/AdminPanelContent/images/ManagerPhotos/" + randomFileName, silinsinmi = 1 });
            }
            else
            {
                return Json(new { isOk = true, photoPath = eskiPhotoPath ,silinsinmi=0});
                
            }

            return Json(new { });
        }
        [HttpGet]
        public IActionResult Update(String updateManagerId)
        {
            Manager updateManager =_managerBs.GetById(int.Parse(updateManagerId));
            //_managerBs.Delete(updateManager);
            return Json(new { 
                isOk = true,
                id = updateManager.Id,
                fullName = updateManager.FullName,
                userName = updateManager.UserName,
                password = updateManager.Password,
                email = updateManager.Email,
                photoPath = updateManager.PhotoPath,
            });
        }
        [HttpPost]
        public IActionResult Update(Manager vm)
        {
            _managerBs.Update(vm);
            return Json(new { isOk = true, Message = "Yönetici başarıyla yüklendi." });
        }
        [HttpPost]
        public IActionResult Delete(String deleteManagerId)
        {
            Manager deletedManager = _managerBs.GetById(int.Parse(deleteManagerId));
            DeletePhoto(deletedManager.PhotoPath);
            _managerBs.Delete(deletedManager);
            return Json(new { isOk = true, message = "Yönetici silindi." });
        }

        [HttpGet]
        public IActionResult DeletePhoto(String photoPath)
        {
            if (!string.IsNullOrEmpty(photoPath) && photoPath.StartsWith("/"))
            {
                photoPath = photoPath.TrimStart('/');
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", photoPath);

            // Dosyanın var olup olmadığını kontrol edin
            if (System.IO.File.Exists(filePath))
            {
                // Dosyayı sil
                System.IO.File.Delete(filePath);
                return Json(new { isOk = true, message = "Fotoğraf silindi." });
            }
            return Json(new { isOk = true, message = "Photo silindi." });
        }



      
    }
}
