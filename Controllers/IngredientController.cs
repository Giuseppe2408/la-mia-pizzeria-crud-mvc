using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Models.Form;
using la_mia_pizzeria_static.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Controllers
{
    public class IngredientController : Controller
    {

        PizzaDbContext Db { get; set; }


        private DbIngredientRepository ingredientRepository;
        public IngredientController()
        {
            Db = PizzaDbContext.Instance;
            ingredientRepository = new DbIngredientRepository();
        }


        public IActionResult Index()
        {
            List<Ingredient> ingredients = ingredientRepository.All();
            return View(ingredients);
        }

        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ingredient ingredient)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            ingredientRepository.Create(ingredient);

            return RedirectToAction("Index");
            
        }

        public IActionResult Edit(int id)
        {
            Ingredient ingredient = ingredientRepository.GetById(id);


            return View(ingredient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Ingredient ingredient)
        {
            ingredient.Id = id;

            ingredientRepository.Update(ingredient);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Ingredient ingredient = Db.Ingredients.Where(i => i.Id == id).Include(i => i.Pizza).FirstOrDefault();

            if (ingredient.Pizza.Count == 0)
            {
                ingredientRepository.Delete(ingredient);

                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }

            
        }
    }
}
