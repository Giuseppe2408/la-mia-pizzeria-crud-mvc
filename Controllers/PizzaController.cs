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

        //[HttpGet] action che fa visualizzare
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //action che salva nel db utilizzando il parametro

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


        //[HttpGet] action che fa visualizzare
        public IActionResult Edit(int id)
        {



            Pizza pizza = Db.Pizzas.Where(p => p.Id == id).FirstOrDefault();

            if (pizza == null)
            {
                return NotFound();
            }

            return View(pizza);

            
        }

        //sfrutta come parametro l'istanza e sfrutta il metodo Update della classe DBContext di Entity framework
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                return View(pizza);
            }

            if (pizza == null)
            {
                return NotFound();
            }

            Db.Update(pizza);
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
