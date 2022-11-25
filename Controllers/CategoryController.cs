using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Controllers
{
    public class CategoryController : Controller
    {
        
        private DbCategoryRepository categoryRepository;

        public CategoryController()
        {
            categoryRepository = new DbCategoryRepository();
        }


        public IActionResult Index()
        {
            List<Category> categories = categoryRepository.All();   
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

           categoryRepository.Createcat(category);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Category category = categoryRepository.GetCatById(id);
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

            categoryRepository.UpdateCat(category);
            

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Category category = categoryRepository.GetByIdWithPizza(id);

            //Pizza pizza = Db.Pizzas.Where(p => p.CategoryId == id).FirstOrDefault();

            if (category.Pizzas.Count == 0)
            {
                categoryRepository.DeleteCat(category);

                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }


        }
    }
}
