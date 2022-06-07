using System.Collections.Generic;
using System.Linq;
using shopapp.entity;

namespace shopapp.webui.Data
{
    public class ProductRepository
    {
        private static List<Product> _products = null;
        static ProductRepository()
        {
         _products = new List<Product>{
             new Product {ProductId=1, Name="iphone x",Description="güzel telefon",Price=6000,isApproved=true,ImageUrl="1.jpg",CategoryId=1},
                new Product {ProductId=2, Name="iphone x",Description="fena telefon",Price=6000,isApproved=true,ImageUrl="2.jpg",CategoryId=2},
                new Product {ProductId=3, Name="samsung galaxy note 9",Description="güzel telefon",Price=9000,isApproved=false,ImageUrl="3.jpg",CategoryId=2},
                new Product {ProductId=4,Name="samsung edge",Description="idare eder telefon",Price=8500,isApproved=false,ImageUrl="4.jpg",CategoryId=3},
                new Product {ProductId=5, Name="iphone 11",Description="iyi telefon",Price=7000,isApproved=true,ImageUrl="5.jpg",CategoryId=2},
         };   
        }
        public static List<Product> Products{
            get{
                return _products;
            }
        }
        public static void AddProduct(Product product){
            _products.Add(product);
        }
        public static Product GetProductById(int id){
            return _products.FirstOrDefault(x=>x.ProductId==id);
        }
        public static void EditProduct(Product product){
            foreach (var p in _products)
            {
                if(p.ProductId == product.ProductId){
                    p.Name = product.Name;
                    p.CategoryId= product.CategoryId;
                    p.Description=product.Description;
                    p.Price=product.Price;
                    p.ImageUrl=product.ImageUrl;
                }
            }  
        }
        public static void DeleteProduct(int id){
            var product = GetProductById(id);
            if(product != null){
                _products.Remove(product);
            }
        }
    }
}