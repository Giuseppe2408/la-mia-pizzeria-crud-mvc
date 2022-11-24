﻿using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Models.Form;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Controllers
{
    public class IngredientController : Controller
    {

        PizzaDbContext Db { get; set; }

        public IngredientController()
        {
            Db = new PizzaDbContext();
        }


        public IActionResult Index()
        {
            List<Ingredient> ingredients = Db.Ingredients.ToList();
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

            Db.Add(ingredient);
            Db.SaveChanges();

            return RedirectToAction("Index");
            
        }

        public IActionResult Edit(int id)
        {
            Ingredient ingredient = Db.Ingredients.Find(id);


            return View(ingredient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Ingredient ingredient)
        {
            ingredient.Id = id;

            Db.Update(ingredient);
            Db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Ingredient ingredient = Db.Ingredients.Where(i => i.Id == id).Include(i => i.Pizza).FirstOrDefault();

            if (ingredient.Pizza.Count == 0)
            {
                Db.Remove(ingredient);
                Db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }
    }
}
