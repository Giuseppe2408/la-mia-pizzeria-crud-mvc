using Azure;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_static.Models.Repository
{
    public class InMemoryPizzaRepository : IPizzaRepository
    {
        public static List<Pizza> Pizzas = new List<Pizza>();

        public List<Pizza> All()
        {
            return Pizzas;   
        }

        public void Create(Pizza pizza, List<int> selectedIngredients)
        {
            pizza.Id = selectedIngredients.Count;
            pizza.Category = new Category() { Id = 1, Title = "Fake cateogry" };

            //simulazione da implentare con ListTagRepository
            pizza.Ingredients= new List<Ingredient>();

            IngredientToPizza(pizza, selectedIngredients);
            //fine simulazione

            Pizzas.Add(pizza);
        }

        private static void IngredientToPizza(Pizza pizza, List<int> selectedIngredients)
        {
            pizza.Category = new Category() { Id = 1, Title = "Fake cateogry" };

            foreach (int ingredientId in selectedIngredients)
            {
                pizza.Ingredients.Add(new Ingredient() { Id = ingredientId, Title = "Fake ingredient " + ingredientId });
            }
        }

        public Pizza GetById(int id)
        {
            Pizza pizza = Pizzas.Where(p => p.Id == id).FirstOrDefault();

            pizza.Category = new Category() { Id = 1, Title = "Fake category" };
            pizza.Ingredients = new List<Ingredient>(); 

            return pizza;
        }

        public void MyRemove(Pizza pizza)
        {
            throw new NotImplementedException();
        }

        public void Update(Pizza pizza, Pizza formData, List<int> selectedIngredients)
        {
            throw new NotImplementedException();
        }
    }
}
