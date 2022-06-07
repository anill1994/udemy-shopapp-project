using System.Linq;
using Microsoft.AspNetCore.Mvc;
using shopapp.business.Abstract;
using shopapp.webui.Models;

namespace shopapp.webui.Controllers
{
    public class ShopController:Controller
    {
        private IProductService _productService;
        public ShopController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult List(string category,int page=1){
            const int pageSize = 2; 
            var productViewModel = new ProductViewModel(){
                PageInfo=new PageInfo {
                  TotalItems = _productService.GetCountByCategory(category),
                  ItemsPerPage=pageSize,
                  CurrentCategory=category,
                  CurrentPage=page  
                },
                Products = _productService.GetProductByCategory(category,page,pageSize)
            };
            return View(productViewModel);
        }
        public IActionResult Details(string url){
            if(url==null){
                return NotFound();
            }
            var product = _productService.GetProductDetails(url);
               if(product==null){
                return NotFound();
            }
            return View(new ProductDetailModel(){
                Product = product,
                Categories = product.ProductCategories.Select(i=>i.Category).ToList()
            });
        }
        public IActionResult Search(string q){
             var productViewModel = new ProductViewModel(){
                Products = _productService.GetSearchResult(q)
            };
            return View(productViewModel);
        }
    }
}