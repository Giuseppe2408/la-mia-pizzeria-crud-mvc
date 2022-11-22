using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;

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

            List<Pizza> pizzaList = Db.Pizzas.ToList();

            return View(pizzaList);
        }

        public IActionResult Show(int id)
        {

            Pizza pizza = Db.Pizzas.Where(p => p.Id == id).FirstOrDefault();

            return View(pizza);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }


            Db.Add(pizza);

            Db.SaveChanges();


            return RedirectToAction("Index");
        }

        //public IActionResult Edit()
        //{
        //    return View();
        //}


        //[HttpPost]
        //public IActionResult Edit(Pizza pizza)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }


        //    Db.Add(pizza);

        //    Db.SaveChanges();


        //    return RedirectToAction("Index");
        //}
    }  
}
