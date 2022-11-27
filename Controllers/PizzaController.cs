using Azure;
using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Models.Form;
using la_mia_pizzeria_static.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {

        private IPizzaRepository pizzaRepository;

        private ICategoryRepository categoryRepository;

        private IIngredientRepository ingredientRepository;

        public PizzaController(IPizzaRepository _pizzaRepository, ICategoryRepository _categoryRepository, IIngredientRepository _ingredientRepository)
        {
            pizzaRepository = _pizzaRepository;
            categoryRepository = _categoryRepository;
            ingredientRepository = _ingredientRepository;
        }


        public IActionResult Index()
        {

            List<Pizza> pizzaList = pizzaRepository.All();
            return View(pizzaList);

        }

        public IActionResult Show(int id)
        {

            Pizza pizza = pizzaRepository.GetById(id);

            return View(pizza);
        }

        //[HttpGet] action che fa visualizzare
        public IActionResult Create()
        {
            PizzaForm formData = new PizzaForm();

            formData.Pizza = new Pizza();
            formData.Categories = categoryRepository.All();
            formData.Ingredients = new List<SelectListItem>();

            List<Ingredient> ingredientList = ingredientRepository.All();

            foreach (Ingredient ingredient in ingredientList)
            {
                //nella tabella ingredienti aggiungo dei selectItem riempiendo la Lista di selectItem
                formData.Ingredients.Add(new SelectListItem(ingredient.Title, ingredient.Id.ToString()));
            }

            return View(formData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //action che salva nel db utilizzando il parametro

        public IActionResult Create(PizzaForm formData)
        {
            

            if (!ModelState.IsValid)
            {
                formData.Categories = categoryRepository.All();
                formData.Ingredients = new List<SelectListItem>();
                

                List<Ingredient> ingredientList = ingredientRepository.All();

                foreach (Ingredient ingredient in ingredientList)
                {
                    //nella tabella ingredienti aggiungo dei selectItem riempiendo la Lista di selectItem
                    formData.Ingredients.Add(new SelectListItem(ingredient.Title, ingredient.Id.ToString()));
                }

                return View();
            }

            

            pizzaRepository.Create(formData.Pizza, formData.SelectedIngredients);


            return RedirectToAction("Index");
        }

        //public IActionResult Edit()
        //{
        //    return View();
        //}


        //[HttpGet] action che fa visualizzare
        public IActionResult Edit(int id)
        {
            
            Pizza pizza = pizzaRepository.GetById(id);

            if (pizza == null)
            {
                return NotFound();
            }

            PizzaForm pizzaForm = new PizzaForm();

            pizzaForm.Pizza = pizza;
            pizzaForm.Categories = categoryRepository.All();
            pizzaForm.Ingredients = new List<SelectListItem>();

            List<Ingredient> ingredientList = ingredientRepository.All();

            foreach (Ingredient ingredient in ingredientList)
            {
                pizzaForm.Ingredients.Add(new SelectListItem(
                    ingredient.Title,
                    ingredient.Id.ToString(),
                    pizza.Ingredients.Any(i => i.Id == ingredient.Id))
                    );
            }



            return View(pizzaForm);

            
        }

        //sfrutta come parametro l'istanza e sfrutta il metodo Update della classe DBContext di Entity framework
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, PizzaForm formData)
        {
            
            if (!ModelState.IsValid)
            {
                formData.Pizza.Id = id;
                formData.Categories = categoryRepository.All();
                formData.Ingredients = new List<SelectListItem>();

                List<Ingredient> ingredientList = ingredientRepository.All();

                foreach (Ingredient ingredient in ingredientList)
                {
                    //nella tabella ingredienti aggiungo dei selectItem riempiendo la Lista di selectItem
                    formData.Ingredients.Add(new SelectListItem(ingredient.Title, ingredient.Id.ToString()));
                }


                return View(formData);
            }

            Pizza pizzaItem = pizzaRepository.GetById(id);

            if (pizzaItem == null)
            {
                return NotFound();
            }

            pizzaRepository.Update(pizzaItem, formData.Pizza, formData.SelectedIngredients);

            return RedirectToAction("Index");


        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Pizza pizza = pizzaRepository.GetById(id);

            if (pizza == null)
            {
                return NotFound();
            }

            pizzaRepository.MyRemove(pizza);
            return RedirectToAction("Index");
        }


        //passo sia l'id che l'istanza e poi cambio i dati singolarmente facendo prima la query e poi assegnandoli

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(int id, Pizza formData)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        return View(formData);
        //    }

        //    if (formData == null)
        //    {
        //        return NotFound();
        //    }

        //    Pizza pizza = Db.Pizzas.Where(p => p.Id == id).FirstOrDefault();

        //    pizza.Nome = formData.Nome;
        //    pizza.Image = formData.Image;
        //    pizza.Price = formData.Price;
        //    pizza.Description = formData.Description;



        //    Db.SaveChanges();



        //    return RedirectToAction("Index");


        //}
    }  
}
