using System.Collections.Generic;
using shopapp.business.Abstract;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository=productRepository;
        }
        public void Create(Product product)
        {
           _productRepository.Create(product);
        }

        public void Delete(Product product)
        {
             _productRepository.Delete(product);
        }

        public List<Product> GetAll()
        {
           return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
          return _productRepository.GetById(id);
        }

        public Product GetByIdWithCategories(int productId)
        {
           return _productRepository.GetByIdWithCategories(productId);
        }

        public int GetCountByCategory(string category)
        {
            return _productRepository.GetCountByCategory(category);
        }

        public List<Product> GetHomePageProducts()
        {
           return _productRepository.GetHomePageProducts();
        }

        public List<Product> GetProductByCategory(string name,int page,int pageSize)
        {
            return _productRepository.GetProductByCategory(name,page,pageSize);
        }

        public Product GetProductDetails(string url)
        {
           return _productRepository.GetProductDetails(url);
        }

        public List<Product> GetSearchResult(string q)
        {
            return _productRepository.GetSearchResult(q);
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }

        public void Update(Product entity, int[] categoryIds)
        {
           _productRepository.Update(entity,categoryIds);
        }
    }
}