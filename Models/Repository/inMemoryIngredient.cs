using lamiapizzeriastatic.Migrations;

namespace la_mia_pizzeria_static.Models.Repository
{
    public class inMemoryIngredient : IIngredientRepository
    {
        public static List<Ingredient> Ingredients = new List<Ingredient>();

        public List<Ingredient> All()
        {
            return Ingredients;
        }

        public void Create(Ingredient ingredient)
        {
            ingredient.Id = Ingredients.Count;
            Ingredients.Add(ingredient);
        }

        public void Delete(Ingredient ingredient)
        {
            Ingredients.Remove(ingredient);
        }

        public Ingredient GetById(int id)
        {
            return Ingredients.Where(i => i.Id == id).FirstOrDefault();
        }

        public void Update(Ingredient ingredient, Ingredient formData)
        {
            ingredient.Title = formData.Title;

            Ingredients.Add(ingredient);
        }
    }
}
