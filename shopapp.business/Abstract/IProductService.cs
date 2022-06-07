using System.Collections.Generic;
using shopapp.entity;

namespace shopapp.business.Abstract
{
    public interface IProductService
    {
         List<Product> GetProductByCategory(string name,int page,int pageSize);
         Product GetProductDetails(string url);
         List<Product> GetHomePageProducts();
         Product GetById(int id); 
         List<Product> GetAll();
         void Create(Product product);
         void Update(Product product);
         void Delete(Product product);
        int GetCountByCategory(string category);
        List<Product> GetSearchResult(string q);
        Product GetByIdWithCategories(int productId);
        void Update(Product entity, int[] categoryIds);
    }
}