using System.Collections.Generic;
using shopapp.entity;

namespace shopapp.data.Abstract
{
    public interface IProductRepository:IRepository<Product>
    {
        List<Product> GetProductByCategory(string name,int page,int pageSize);
        List<Product> GetHomePageProducts();
        Product GetProductDetails(string url);
        int GetCountByCategory(string category);
        List<Product> GetSearchResult(string q);
        Product GetByIdWithCategories(int productId);
        void Update(Product entity, int[] categoryIds);
    }
}