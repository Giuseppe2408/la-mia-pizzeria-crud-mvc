using lamiapizzeriastatic.Migrations;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Models.Repository
{
    public class InMemoryCategory : ICategoryRepository
    {
        public static List<Category> Categories = new List<Category>();


        public List<Category> All()
        {
            return Categories;
        }

        public void Create(Category category)
        {
            category.Id = Categories.Count;
            Categories.Add(category);
        }

        public void Delete(Category category)
        {
            Categories.Remove(category);
        }

        public Category GetByIdWithPizza(int id)
        {

            //fare include a mano qui
            Category category = Categories.Where(c => c.Id == id).FirstOrDefault();



            return category;
        }

        public Category GetById(int id)
        {
            return Categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public void Update(Category category, Category formData)
        {
            category.Title = formData.Title;

            Categories.Add(category);
        }
    }
}
