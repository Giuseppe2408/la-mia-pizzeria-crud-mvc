using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Controllers
{
    public class CategoryController : Controller
    {
        PizzaDbContext Db { get; set; }

        public CategoryController()
        {
            Db = new PizzaDbContext();
        }


        public IActionResult Index()
        {
            List<Category> categories = Db.Categories.ToList();   
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {

            if (!ModelState.IsValid)
                return View();

            Db.Categories.Add(category);
            Db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Category category = Db.Categories.Where(cat => cat.Id == id).FirstOrDefault();

            if(category == null)
            {
                return NotFound();
            }

            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Category category)
        {
            category.Id = id;

            if (!ModelState.IsValid)
                return View();

            Db.Update(category);
            Db.SaveChanges();
            

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Category category = Db.Categories.Where(c => c.Id == id).Include(c => c.Pizzas).FirstOrDefault();

            //Pizza pizza = Db.Pizzas.Where(p => p.CategoryId == id).FirstOrDefault();

            if (category.Pizzas.Count == 0)
            {                
                Db.Remove(category);
                Db.SaveChanges();
                             
                return RedirectToAction("Index");
            } else
            {
                return NotFound();
            }


            
        }
    }
}
