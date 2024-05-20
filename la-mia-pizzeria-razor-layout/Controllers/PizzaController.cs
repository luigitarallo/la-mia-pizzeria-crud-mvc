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
            PizzaFormModel model = new PizzaFormModel();
            model.Pizza = new Pizza();
            model.Categories = PizzaManager.GetCategories();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaFormModel data)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", data);
            }

            PizzaManager.InsertPizza(data.Pizza);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            
            Pizza pizzaToEdit = PizzaManager.GetPizzaById(id);

            if (pizzaToEdit == null)
            {
                return NotFound();
            }
            else
            {
                return View(pizzaToEdit);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Pizza data)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", data);
            }

            bool result = PizzaManager.UpdatePizza(id, pizzaToEdit =>
            {
                pizzaToEdit.Name = data.Name;
                pizzaToEdit.Description = data.Description;
                pizzaToEdit.Photo = data.Photo;
                pizzaToEdit.Price = data.Price;
            });

            if (result == true)
                return RedirectToAction("Index");
            else
                return NotFound(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (PizzaManager.DeletePizza(id))
                return RedirectToAction("Index");
            else
                return NotFound();
        }
    }
}
