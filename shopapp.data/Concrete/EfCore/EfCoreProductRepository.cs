using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.data.Concrete.EfCore
{
    public class EfCoreProductRepository : EfCoreGenericRepository<Product, ShopContext>, IProductRepository
    {
        public Product GetByIdWithCategories(int productId)
        {
            using(var context = new ShopContext())
            {
               return context.Products.Where(i=>i.ProductId==productId)
                                        .Include(i=>i.ProductCategories)
                                            .ThenInclude(i=>i.Category)
                                                .FirstOrDefault();
            }
        }

        public int GetCountByCategory(string category)
        {
           using(var context = new ShopContext())
            {
                var products = context.Products.Where(i=>i.isApproved).AsQueryable();
                if(!string.IsNullOrEmpty(category)){
                    products = products
                                .Include(i=>i.ProductCategories)
                                    .ThenInclude(i=>i.Category)
                                    .Where(i=>i.ProductCategories.Any(a=>a.Category.Url==category));
                }
                return products.Count();
            }
        }

        public List<Product> GetHomePageProducts()
        {
            using(var context = new ShopContext())
            {
                return context.Products
                                    .Where(i=>i.isApproved && i.isHome).ToList();
            }
        }

        public List<Product> GetProductByCategory(string name,int page,int pageSize)
        {
            using(var context = new ShopContext())
            {
                var products = context.Products.Where(i=>i.isApproved).AsQueryable();
                if(!string.IsNullOrEmpty(name)){
                    products = products
                                .Include(i=>i.ProductCategories)
                                    .ThenInclude(i=>i.Category)
                                    .Where(i=>i.ProductCategories.Any(a=>a.Category.Url==name));
                }
                return products.Skip((page-1)*pageSize).Take(pageSize).ToList();
            }
        }

        public Product GetProductDetails(string url)
        {
            using(var context = new ShopContext()){
              return context.Products
                            .Where(i=>i.Url==url)
                                .Include(p=>p.ProductCategories)
                                    .ThenInclude(c=>c.Category).FirstOrDefault();
           }
        }

        public List<Product> GetSearchResult(string q)
        {
              using(var context = new ShopContext())
            {
                var products = context.Products
                .Where(i=>i.isApproved && (i.Name.ToLower().Contains(q.ToLower()) || i.Description.ToLower().Contains(q.ToLower()))).AsQueryable();
                return products.ToList();
            }
        }

        public void Update(Product entity, int[] categoryIds)
        {
            using(var context = new ShopContext()){
               var product= context.Products .Include(i=>i.ProductCategories)
                                    .FirstOrDefault(i=>i.ProductId==entity.ProductId);
                if(product!=null){
                    product.Name=entity.Name;
                    product.Description=entity.Description;
                    product.Price = entity.Price;
                    product.ImageUrl = entity.ImageUrl;
                    product.Url = entity.Url;
                    product.ProductCategories = categoryIds.Select(catid=> new ProductCategory(){
                        ProductId = entity.ProductId,
                        CategoryId=catid
                    }).ToList();
                    context.SaveChanges();
                }
            }
        }
    }
}