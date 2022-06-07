using System.Linq;
using Microsoft.AspNetCore.Mvc;
using shopapp.business.Abstract;
using shopapp.entity;
using shopapp.webui.Data;

namespace shopapp.webui.Controllers
{
    public class ProductController:Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // public IActionResult List(int? id,string q){
        //    var products = ProductRepository.Products;
        //     if(id != null){
        //         products = products.Where(x=>x.CategoryId==id).ToList();
        //     }
        //     if(!string.IsNullOrEmpty(q)){
        //         products = products.Where(i=>i.Name.ToLower().Contains(q.ToLower()) || i.Description.ToLower().Contains(q.ToLower())).ToList();
        //     }
        //     var ProductViewModel = new ProductViewModel(){
        //          Products = _productService.GetAll()
        //     };
        //     return View(ProductViewModel);
        // }
         public IActionResult Details(int id){
             
            return View(ProductRepository.GetProductById(id));
        }
        public IActionResult Create(){
             //   ViewBag.Categories = new SelectList(CategoryRepository.Categories,"CategoryId","Name");
                return View(new Product());
        }
        [HttpPost]
        public IActionResult Create(Product product){
            // if(ModelState.IsValid){
            //     ProductRepository.AddProduct(product);
            //     return RedirectToAction("list");
            // }
            // ViewBag.Categories = new SelectList(CategoryRepository.Categories,"CategoryId","Name");
            // return View(product);
            return View();
        }
         public IActionResult Edit(int id){
          //  ViewBag.Categories = new SelectList(CategoryRepository.Categories,"CategoryId","Name");
            return View(ProductRepository.GetProductById(id));
        }
        [HttpPost]
        public IActionResult Edit(Product product){

          //  ProductRepository.EditProduct(product);
            return RedirectToAction("list");
        }
        [HttpPost]
        public IActionResult Delete(int ProductId){
            ProductRepository.DeleteProduct(ProductId);
            return RedirectToAction("list");
        }
    }
}