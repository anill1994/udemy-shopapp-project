using System;
using System.Collections.Generic;

namespace shopapp.entity
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public bool isApproved { get; set; }
        public bool isHome { get; set; }
        public int? CategoryId { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
