using Azure;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_static.Models.Repository
{
    public class InMemoryPizzaRepository : IPizzaRepository
    {
        public static List<Pizza> Pizzas = new List<Pizza>();

        public static InMemoryCategory inMemoryCategory;

        public static inMemoryIngredient inMemoryIngredient;
        //ricordarsi di fare l'implementazione interfaccia e assegnare la Variabile di tipo  interfaccia
        public List<Pizza> All()
        {
            return Pizzas;   
        }

        public void Create(Pizza pizza, List<int> selectedIngredients)
        {
            pizza.Id = selectedIngredients.Count;
            pizza.Category = inMemoryCategory.GetById(pizza.CategoryId);

            //simulazione da implentare con ListTagRepository
            pizza.Ingredients = inMemoryIngredient.All();

            IngredientToPizza(pizza, selectedIngredients);
            //fine simulazione

            Pizzas.Add(pizza);
        }

        private static void IngredientToPizza(Pizza pizza, List<int> selectedIngredients)
        {
            //pizza.Category = inMemoryCategory.GetById(pizza.CategoryId);

            foreach (int ingredientId in selectedIngredients)
            {
                Ingredient ingredient = inMemoryIngredient.GetById(ingredientId);
                pizza.Ingredients.Add(ingredient);
            }
        }

        public Pizza GetById(int id)
        {
            Pizza pizza = Pizzas.Where(p => p.Id == id).FirstOrDefault();

            pizza.Category = inMemoryCategory.GetById(pizza.CategoryId);
            pizza.Ingredients = inMemoryIngredient.All(); 

            return pizza;
        }

        public void MyRemove(Pizza pizza)
        {
            Pizzas.Remove(pizza);
        }

        public void Update(Pizza pizza, Pizza formData, List<int> selectedIngredients)
        {
            pizza = formData;

            pizza.Ingredients = new List<Ingredient>();

            if (selectedIngredients == null)
            {
                selectedIngredients = new List<int>();
            }

            IngredientToPizza(pizza, selectedIngredients);
        }
    }
}
