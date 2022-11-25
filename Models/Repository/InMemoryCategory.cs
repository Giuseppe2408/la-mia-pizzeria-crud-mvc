using lamiapizzeriastatic.Migrations;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Models.Repository
{
    public class InMemoryCategory : IDbCategoryRepository
    {
        public List<Category> Categories = new List<Category>();


        public List<Category> All()
        {
            return Categories;
        }

        public void Createcat(Category category)
        {
            category.Id = Categories.Count;
            Categories.Add(category);
        }

        public void DeleteCat(Category category)
        {
            throw new NotImplementedException();
        }

        public Category GetByIdWithPizza(int id)
        {
            Category category = Categories.Where(c => c.Id == id).FirstOrDefault();
            
            Categories.Add(category.Pizzas);
            
            return category;
        }

        public Category GetCatById(int id)
        {
            return Categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public void UpdateCat(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
