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
            using PizzaContext db = new PizzaContext();

            if (!db.Pizzas.Any())
            {
                List<Pizza> pizzasForDb = new List<Pizza>
                {
                    new Pizza("Margherita", "Pomodoro, fiordilatte e basilico", "~/img/margherita.jpg", 5.5m),
                    new Pizza("Marinara", "Pomodoro, origano ed aglio", "~/img/marinara.jpg", 4.5m),
                    new Pizza("Diavola", "Pomodoro, fiordilatte e salame piccante", "~/img/diavola.jpg", 6m),
                    new Pizza("Carrettiera", "Friarielli, fiordilatte e salsiccia", "~/img/salsiccia-friarielli.jpg", 6.5m),
                    new Pizza("Pizza fritta", "Pizza ripiena di cicoli, ricotta, mozzarella e pomodoro, fritta in olio evo", "~/img/fritta.jpg", 6m),
                    new Pizza("Bufalina", "Margherita con mozzarella di bufala dop", "~/img/bufalina.jpg", 6.5m),
                };
                foreach (Pizza pizza in pizzasForDb)
                {
                    db.Add(pizza);
                }
                db.SaveChanges();
            }

            List<Pizza> pizzas = db.Pizzas.ToList();
            return View("Index", pizzas);
        }

        public IActionResult ShowPizza(int id)
        {
            using PizzaContext db = new PizzaContext();
            Pizza pizza = db.Pizzas.FirstOrDefault(p => p.PizzaId == id);
            if (pizza == null)
            {
                return NotFound();
            }
            return View("Show", pizza);
        }
    }
}
