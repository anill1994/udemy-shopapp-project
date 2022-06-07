using System.Collections.Generic;
using System.Linq;
using shopapp.entity;

namespace shopapp.webui.Data
{
    public class CategoryRepository
    {
        private static List<Category> _category = null;
        static CategoryRepository()
        {
            _category = new List<Category>{
                new Category{CategoryId=1,Name="Telefon"},
                new Category{CategoryId=2,Name="Kitap"},
                new Category{CategoryId=3,Name="Tablet"},
                new Category{CategoryId=4,Name="Bilgisayar"}
            };
        }
        public static List<Category> Categories{
            get{
                return _category;
            }
        }
        public static void AddCategory(Category category){
            _category.Add(category);
        }
        public static Category GetCategoryById(int id){
          return  _category.FirstOrDefault(x=>x.CategoryId==id);
        }
    }
}