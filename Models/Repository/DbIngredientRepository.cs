using la_mia_pizzeria_static.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.SqlServer.Server;

namespace la_mia_pizzeria_static.Models.Repository
{
    public class DbIngredientRepository
    {
        private PizzaDbContext db;

        public DbIngredientRepository()
        {
            db = PizzaDbContext.Instance;
        }

        public List<Ingredient> All()
        {
            return db.Ingredients.ToList();
        }

        public Ingredient GetIngById(int id)
        {
            return db.Ingredients.Find(id);
        }

   
        //public void Createcat(Category category)
        //{
        //    db.Ingredients.Add(category);
        //    db.SaveChanges();
        //}

        //public void UpdateCat(Category category)
        //{
        //    db.Update(category);
        //    db.SaveChanges();
        //}

        //public Category GetByIdWithPizza(int id)
        //{
        //    return db.Ingredients.Where(c => c.Id == id).Include(c => c.Pizzas).FirstOrDefault();
        //}

        //public void DeleteCat(Category category)
        //{
        //    db.Remove(category);
        //    db.SaveChanges();

    }
    }
}
