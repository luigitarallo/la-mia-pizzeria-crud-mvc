using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria_razor_layout.Models;
using la_mia_pizzeria_razor_layout.Data;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_razor_layout.Controllers
{
    public class PizzaController : Controller
    {

        public IActionResult Index()
        {
            return View(PizzaManager.GetAllPizzas());
        }

        public IActionResult ShowPizza(int id)
        {
            Pizza pizza = PizzaManager.GetPizzaById(id);
            if (pizza != null)
                return View("Show", pizza);
            else
                return View("errore");
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", pizza);
            }

            PizzaManager.InsertPizza(pizza);
            return RedirectToAction("Index");
        }

    }
}
