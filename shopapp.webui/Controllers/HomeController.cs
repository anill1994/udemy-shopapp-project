using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using shopapp.business.Abstract;
using shopapp.webui.Models;

namespace shopapp.webui.Controllers
{
    public class HomeController:Controller
    {
        private IProductService _productService;
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index(){
            // List<Product> products = new List<Product>()
            // {
            //     new Product {Name="iphone x",Description="güzel telefon",Price=6000,isApproved=true},
            //     new Product {Name="iphone x",Description="fena telefon",Price=6000,isApproved=true},
            //     new Product {Name="samsung galaxy note 9",Description="güzel telefon",Price=9000,isApproved=false},
            //     new Product {Name="samsung edge",Description="idare eder telefon",Price=8500,isApproved=false},
            //     new Product {Name="iphone 11",Description="iyi telefon",Price=7000,isApproved=true},
            // };
            
            var ProductViewModel = new ProductViewModel(){
                 Products = _productService.GetHomePageProducts()
            };
            return View(ProductViewModel);
        } 
          public IActionResult About(){
            return View();
        } 
    }
}