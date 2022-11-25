using la_mia_pizzeria_static.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.SqlServer.Server;

namespace la_mia_pizzeria_static.Models.Repository
{
    public class DbIngredientRepository : IDbIngredientRepository
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


        public void CreateIng(Ingredient ingredient)
        {
            db.Ingredients.Add(ingredient);
            db.SaveChanges();
        }

        public void UpdateIng(Ingredient ingredient)
        {
            db.Update(ingredient);
            db.SaveChanges();

        }



        public void DeleteIng(Ingredient ingredient)
        {
            db.Remove(ingredient);
            db.SaveChanges();
        }
    }
}
