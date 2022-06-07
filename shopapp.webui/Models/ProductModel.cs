using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using shopapp.entity;

namespace shopapp.webui.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        [Display(Name="Name",Prompt="Enter product name")]
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public bool isApproved { get; set; }
        public bool isHome { get; set; }
        public int? CategoryId { get; set; }
        public List<Category> SelectedCategory { get; set; }

    }
}