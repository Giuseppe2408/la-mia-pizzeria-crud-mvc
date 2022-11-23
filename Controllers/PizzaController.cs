using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Models.Form;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        PizzaDbContext Db { get; set; }

        public PizzaController()
        {
            Db = new PizzaDbContext();
        }


        public IActionResult Index()
        {

            List<Pizza> pizzaList = Db.Pizzas.Include(pizza => pizza.Category).ToList();
            return View(pizzaList);
        }

        public IActionResult Show(int id)
        {

            Pizza pizza = Db.Pizzas.Where(p => p.Id == id).FirstOrDefault();

            return View(pizza);
        }

        //[HttpGet] action che fa visualizzare
        public IActionResult Create()
        {
            PizzaForm formData = new PizzaForm();

            formData.Pizza = new Pizza();
            formData.Categories = Db.Categories.ToList();

            return View(formData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //action che salva nel db utilizzando il parametro

        public IActionResult Create(PizzaForm formData)
        {
           

            if (!ModelState.IsValid)
            {
                formData.Categories = Db.Categories.ToList();
                return View();
            }


            Db.Add(formData.Pizza);

            Db.SaveChanges();


            return RedirectToAction("Index");
        }

        //public IActionResult Edit()
        //{
        //    return View();
        //}


        //[HttpGet] action che fa visualizzare
        public IActionResult Edit(int id)
        {
            
            Pizza pizza = Db.Pizzas.Where(p => p.Id == id).FirstOrDefault();

            if (pizza == null)
            {
                return NotFound();
            }

            PizzaForm pizzaForm = new PizzaForm();

            pizzaForm.Pizza = pizza;
            pizzaForm.Categories = Db.Categories.ToList();

            return View(pizzaForm);

            
        }

        //sfrutta come parametro l'istanza e sfrutta il metodo Update della classe DBContext di Entity framework
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, PizzaForm formData)
        {
            formData.Pizza.Id = id;
            if (!ModelState.IsValid)
            {
                formData.Categories = Db.Categories.ToList();
                return View(formData);
            }

            if (formData == null)
            {
                return NotFound();
            }

            Db.Update(formData.Pizza);
            Db.SaveChanges();

            return RedirectToAction("Index");


        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Pizza pizza = Db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

            if (pizza == null)
            {
                return NotFound();
            }

            Db.Remove(pizza);
            Db.SaveChanges();
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
