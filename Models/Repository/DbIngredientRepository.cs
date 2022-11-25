using la_mia_pizzeria_static.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.SqlServer.Server;

namespace la_mia_pizzeria_static.Models.Repository
{
    public class DbIngredientRepository : IIngredientRepository
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

        public Ingredient GetById(int id)
        {
            return db.Ingredients.Find(id);
        }


        public void Create(Ingredient ingredient)
        {
            db.Ingredients.Add(ingredient);
            db.SaveChanges();
        }

        public void Update(Ingredient ingredient, Ingredient formData)
        {
            ingredient.Title = formData.Title;  
            db.SaveChanges();

        }



        public void Delete(Ingredient ingredient)
        {
            db.Remove(ingredient);
            db.SaveChanges();
        }
    }
}
