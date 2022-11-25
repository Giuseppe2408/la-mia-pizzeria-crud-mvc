using la_mia_pizzeria_static.Data;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Models.Repository
{
    public class DbCategoryRepository : ICategoryRepository
    {

        private PizzaDbContext db;

        public DbCategoryRepository()
        {
            db = PizzaDbContext.Instance;
        }

        public List<Category> All()
        {
            return db.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return db.Categories.Where(cat => cat.Id == id).FirstOrDefault();

        }

        public void Create(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void Update(Category category, Category formData)
        {
            category.Title = formData.Title;
            db.SaveChanges();
        }

        public Category GetByIdWithPizza(int id)
        {
            return db.Categories.Where(c => c.Id == id).Include(c => c.Pizzas).FirstOrDefault();
        }

        public void Delete(Category category)
        {
            db.Remove(category);
            db.SaveChanges();

        }
    }
}
