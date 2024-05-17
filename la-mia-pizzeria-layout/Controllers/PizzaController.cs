﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test_MVC_2.Data;
using Test_MVC_2.Models;

namespace Test_MVC_2.Controllers
{
    public class PizzaController : Controller
    {
        //Istanzio il DBContext per renderlo accessibile qui

        //public AppDbContext _context;

        //public PizzaController(Pizzacontext context)
        //{
        //    _context = context;
        //}
        public IActionResult Index()
        {
            List<Pizza> pizze = PizzaManager.RecuperaTutteLePizze();

            //Pizza margherita = new Pizza("Margherita", "Pomodoro e Mozzarella", "img/pizza-1.jpg", 5.90f);
            //pizze.Add(margherita);

            //Pizza capricciosa = new Pizza("Capricciosa", "Pomodoro, Mozzarella, funghi e carciofini", "img/pizza-2.jpg", 7.90f);
            //pizze.Add(capricciosa);

            //Pizza salamino = new Pizza("Salamino", "Pomodoro mozzarella e salamino", "img/pizza-3.jpg", 8.90f);
            //pizze.Add(salamino);

            //Pizza moenese = new Pizza("Moenese", "Pomodoro, Mozzarella, puzzone e funghi", "img/pizza-4.jpg", 11.90f);
            //pizze.Add(moenese);

            //Pizza montanara = new Pizza("Montanara", "Fontina e pancetta", "img/pizza-5.jpg", 9.90f);
            //pizze.Add(montanara);

            //Pizza deaKhalì = new Pizza("Dea Khalì", "Polpo, Patate, limone e prezzemolo", "img/pizza-6.jpg", 10.90f);
            //pizze.Add(deaKhalì);
            //Index questo caso faccio vedere la view Index anche se di 
            //default non ci sarebbe bisogno di specificarlo

            return View("Index", pizze);
        }
        public IActionResult Show(int id)
        {

            var pizza = PizzaManager.RecuperaPizzaDaId(id);
            return View(pizza);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", pizza);
            }
            PizzaManager.InserisciPizza(pizza);
            return RedirectToAction("Index");

        }



    }
}
