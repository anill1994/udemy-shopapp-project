using System.Linq;
using Microsoft.EntityFrameworkCore;
using shopapp.entity;

namespace shopapp.data.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed(){
            ShopContext context = new ShopContext();
            if(context.Database.GetPendingMigrations().Count()==0){
                if(context.Categories.Count()==0){
                  context.Categories.AddRange(Categories);
                }
                if(context.Products.Count()==0){
                  context.Products.AddRange(Products);
                  context.AddRange(ProductCategories);
                }
           
            }
            context.SaveChanges();
        }
        private static Category[] Categories={
          new Category(){Name="Telefon",Url="telefon"},  
          new Category(){Name="Elektronik",Url="elektronik"},  
          new Category(){Name="Kitap",Url="kitap"},
          new Category(){Name="Spor",Url="spor"},
        };
        private static Product[] Products={
            new Product() {Name="iphone x",Description="güzel telefon",Price=6000,Url="iphone-x", ImageUrl="1.jpg", isApproved=true},
            new Product() {Name="iphone 10",Description="fena telefon",Price=6000,Url="iphone-10",ImageUrl="2.jpg",isApproved=true},
            new Product() {Name="samsung galaxy 9",Description="güzel telefon",Price=9000,Url="samsung-galax-9",ImageUrl="1.jpg",isApproved=false},
            new Product() {Name="samsung edge",Description="idare eder telefon",Price=8500,Url="samsung-edge",ImageUrl="3.jpg",isApproved=false},
            new Product() {Name="iphone 11",Description="iyi telefon",Price=7000,Url="iphone-11",ImageUrl="4.jpg",isApproved=true},
        };
        private static ProductCategory[] ProductCategories={
            new ProductCategory(){Product=Products[0],Category=Categories[0]},
            new ProductCategory(){Product=Products[1],Category=Categories[1]},
            new ProductCategory(){Product=Products[2],Category=Categories[1]},
            new ProductCategory(){Product=Products[2],Category=Categories[0]},
            new ProductCategory(){Product=Products[3],Category=Categories[1]},
            new ProductCategory(){Product=Products[0],Category=Categories[2]},
            new ProductCategory(){Product=Products[4],Category=Categories[3]},
            new ProductCategory(){Product=Products[0],Category=Categories[1]},
        };
    }
}