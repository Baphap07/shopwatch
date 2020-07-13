using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShowWatch.Models;
using ShowWatch.ViewModels;

namespace ShowWatch.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ICategoryReposirory categoryReposirory;

        public HomeController(IProductRepository productRepository, IWebHostEnvironment webHostEnvironment,
                                            ICategoryReposirory categoryReposirory)
        {
            this.productRepository = productRepository;
            this.webHostEnvironment = webHostEnvironment;
            this.categoryReposirory = categoryReposirory;
        }

        public ViewResult Index()
        {
            var products = productRepository.Gets();
            return View(products);
        }
        public ViewResult Details(int id)
        {
            try
            {
                int.Parse(id.ToString());
                var ProductNotFound = productRepository.Get(id);
                if (ProductNotFound == null)
                {
                    //ViewBag.Id = id;
                    return View("~/Views/Error/ProductNotFound.cshtml", id);
                }
                var detailViewModel = new HomeDetailViewModel()
                {
                    Product = productRepository.Get(id),
                    TitleName = "Product Detail"
                };

                return View(detailViewModel);
            }
            catch(Exception e)
            {
                throw e;
            }
         
        }
        [Authorize]
        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.Categorys = GetCategories();
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(HomeCreateViewModel model)
        {
            
            var product = new Product()
            {
                Name = model.Name,
                Brand=model.Brand,
                Radius=model.Radius,
                Thickness=model.Thickness,
                Cord=model.Cord,
                Glasses=model.Glasses,
                water_proof=model.water_proof,
                Guarantee=model.Guarantee,
                Price=model.Price,
                CategoryId=model.CategoryId

            };
            var fileName = string.Empty;
            if (model.AvatarPath != null)
            {
                string uploadFoder = Path.Combine(webHostEnvironment.WebRootPath, "img");
                fileName = $"{Guid.NewGuid()}_{ model.AvatarPath.FileName}";
                var filePath = Path.Combine(uploadFoder, fileName);
                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    model.AvatarPath.CopyTo(fs);
                }
            }
            else
            {
                fileName = "anh9.jpg";
            }
           
            product.Avatar = fileName;
            var newPrd = productRepository.Create(product);
                return RedirectToAction("Details", new { id = newPrd.Id });
            
            
        }
      
        [HttpGet]
        public IActionResult Edit(int id)
        {
            
            var product = productRepository.Get(id);
            if (product == null)
            {
                //ViewBag.Id = id;
                return View("~/Views/Error/ProductNotFound.cshtml", id);
            }
            var ediPro = new HomeEditViewModel()
            {
                Avatar=product.Avatar,
                Name = product.Name,
                Brand = product.Brand,
                Radius = product.Radius,
                Thickness = product.Thickness,
                Cord = product.Cord,
                Glasses = product.Glasses,
                water_proof = product.water_proof,
                Guarantee = product.Guarantee,
                Price = product.Price,
                CategoryId=product.CategoryId
            };
            return View(ediPro);
        }
       
        [HttpPost]
        public IActionResult Edit(HomeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = new Product()
                {
                    Name = model.Name,
                    Brand = model.Brand,
                    Radius = model.Radius,
                    Thickness = model.Thickness,
                    Cord = model.Cord,
                    Glasses = model.Glasses,
                    water_proof = model.water_proof,
                    Guarantee = model.Guarantee,
                    Price = model.Price,
                    Id=model.Id,
                    Avatar=model.Avatar,
                    CategoryId=model.CategoryId

                };
                var fileName = string.Empty;
                if (model.AvatarPath != null)
                {
                    string uploadFoder = Path.Combine(webHostEnvironment.WebRootPath, "img");
                    fileName = $"{Guid.NewGuid()}_{ model.AvatarPath.FileName}";
                    var filePath = Path.Combine(uploadFoder, fileName);
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        model.AvatarPath.CopyTo(fs);
                    }
                    product.Avatar = fileName;
                   
                    if (!string.IsNullOrEmpty(model.Avatar))
                    {
                        string delFile = Path.Combine(webHostEnvironment.WebRootPath, "img", model.Avatar);
                        System.IO.File.Delete(delFile);
                    }
                }


                if (productRepository.Edit(product) != null)
                {
                    return RedirectToAction("Details", new { id = model.Id });
                }
            }
          
            return View();
        }
        [Authorize]
        public IActionResult Delete(int id)
        {
           
            if (productRepository.Delete(id))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        private List<Category> GetCategories()
        {
            return categoryReposirory.Gets().ToList();
        }

    }
}
