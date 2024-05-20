using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Test_MVC_2.Data;
using Test_MVC_2.Models;

namespace Test_MVC_2.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {


            List<Pizza> pizze = new List<Pizza> { };
                
                pizze = PizzaManager.RecuperaTutteLePizze();

            return View(pizze);
        }

        public IActionResult Show(int id)
        {

            var pizza = PizzaManager.RecuperaPizzaDaId(id);
            return View(pizza);

        }

        public IActionResult Create()
        {
            //return View("Create");

            PizzaFormModel model = new PizzaFormModel();

            //Istanzio una pizza

            model.Pizza = new Pizza();
            model.Categories = PizzaManager.();
            return View(model);

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

        [HttpGet]
        public IActionResult Update(int id)
        {
            var pizzaDaEditare = PizzaManager.RecuperaPizzaDaId(id);
            if (pizzaDaEditare == null)
            {
                return NotFound();
            }
            else
            {
                return View(pizzaDaEditare);

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", pizza);
            }


            if (PizzaManager.EditaPizza(id, pizza.Name, pizza.Description, pizza.Url, pizza.Price))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (PizzaManager.PiallaPizza(id))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }

        }

    }
}
