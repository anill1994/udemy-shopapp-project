using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using shopapp.business.Abstract;
using shopapp.entity;
using shopapp.webui.Models;

namespace shopapp.webui.Controllers
{
    public class AdminController:Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        public AdminController(IProductService productService,ICategoryService categoryService)
        {
            _productService=productService;
            _categoryService = categoryService;
        }
        public IActionResult ProductList(){
            var productViewModel = new ProductViewModel(){
                Products = _productService.GetAll()
            };
            return View(productViewModel);
        }
        
        public IActionResult CreateProduct(){
            return View();
        }
        [HttpPost]
          public IActionResult CreateProduct(ProductModel model){
            var entity = new Product(){
                Name=model.Name,
                Url=model.Url,
                Description=model.Description,
                ImageUrl=model.ImageUrl,
                Price=model.Price
            };
            _productService.Create(entity);
            var msg = new AlertMessage(){
                AlertType = "success",
                Message = $"{entity.Name} isimli ürün eklendi"
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);

            return RedirectToAction("productlist");
        }
        public IActionResult ProductEdit(int? id){
            if(id==null){
                return NotFound();
            }
           var product= _productService.GetByIdWithCategories((int)id);
           if(product==null){
               return NotFound();
           }
            var entity = new ProductModel(){
                ProductId = product.ProductId,
                Name = product.Name,
                Description=product.Description,
                Url=product.Url,
                ImageUrl=product.ImageUrl,
                Price=product.Price,
                SelectedCategory = product.ProductCategories.Select(i=>i.Category).ToList()
            };
            ViewBag.Categories = _categoryService.GetAll();
            return View(entity);
        }
        [HttpPost]
          public IActionResult ProductEdit(ProductModel model,int[] categoryIds){
            var entity = _productService.GetByIdWithCategories(model.ProductId);
            if(entity==null){
                return NotFound();
            }
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.Url = model.Url;
            entity.Price = model.Price;
            entity.ImageUrl = model.ImageUrl;

            _productService.Update(entity,categoryIds);
             var msg = new AlertMessage(){
                AlertType = "warning",
                Message = $"{entity.Name} isimli ürün güncellendi"
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);

            return RedirectToAction("productlist");
        }
        [HttpPost]
        public IActionResult DeleteProduct(int? productId){
           var entity = _productService.GetById((int)productId);
            if(entity!=null){
                _productService.Delete(entity);
            }
            var msg = new AlertMessage(){
                AlertType = "danger",
                Message = $"{entity.Name} isimli ürün silindi"
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);
            return RedirectToAction("productlist");
        }
        public IActionResult CategoryList(){
            var categoryListViewModel = new CategoryListViewModel(){
                Categories = _categoryService.GetAll()
            };
            return View(categoryListViewModel);
        }
         public IActionResult CategoryCreate(){
            return View();
        }
        [HttpPost]
          public IActionResult CategoryCreate(CategoryModel model){
            var entity = new Category(){
                Name=model.Name,
                Url=model.Url,
            };
            _categoryService.Create(entity);
            var msg = new AlertMessage(){
                AlertType = "success",
                Message = $"{entity.Name} isimli category eklendi"
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);

            return RedirectToAction("categorylist");
        }
        public IActionResult CategoryEdit(int? id){
            if(id==null){
                return NotFound();
            }
           var category= _categoryService.GetCategoryWithProducts((int)id);
           if(category==null){
               return NotFound();
           }
            var entity = new CategoryModel(){
                CategoryId = category.CategoryId,
                Name = category.Name,
                Url=category.Url,
                Products = category.ProductCategories.Select(i=>i.Product).ToList()
            };
            return View(entity);
        }
        [HttpPost]
          public IActionResult CategoryEdit(CategoryModel model){
            var entity = _categoryService.GetCategoryWithProducts(model.CategoryId);
            if(entity==null){
                return NotFound();
            }
            entity.Name = model.Name;
            entity.Url = model.Url;
            _categoryService.Update(entity);
             var msg = new AlertMessage(){
                AlertType = "warning",
                Message = $"{entity.Name} isimli category güncellendi"
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);

            return RedirectToAction("categorylist");
        }
        [HttpPost]
        public IActionResult CategoryDelete(int? categoryId){
           var entity = _categoryService.GetById((int)categoryId);
            if(entity!=null){
                _categoryService.Delete(entity);
            }
            var msg = new AlertMessage(){
                AlertType = "danger",
                Message = $"{entity.Name} isimli category silindi"
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);
            return RedirectToAction("categorylist");
        }
        public IActionResult DeleteFromCategory(int productId,int categoryId){
            _categoryService.DeleteFromCategory(productId,categoryId);
            return Redirect("/admin/categories/"+categoryId);
        }
    }
}