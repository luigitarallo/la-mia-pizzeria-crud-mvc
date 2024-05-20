using la_mia_pizzeria_razor_layout.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_razor_layout.Data
{
    public class PizzaManager
    {
        public static List<Pizza> GetAllPizzas()
        {
            using PizzaContext db = new PizzaContext();
            return db.Pizzas.ToList();
        }

        public static Pizza GetPizzaById(int id, bool includeReferences = true)
        {
            using PizzaContext db = new PizzaContext();
            if (includeReferences)
                return db.Pizzas.Where(p => p.PizzaId==id).Include(p => p.Category).FirstOrDefault();
            return db.Pizzas.FirstOrDefault(p => p.PizzaId == id);
        }

        public static List<Category> GetCategories()
        {
            using PizzaContext db = new PizzaContext();
            return db.Categories.ToList();
        }

        public static int CountAllPizzas()
        {
            using PizzaContext db = new PizzaContext();
            return db.Pizzas.Count();
        }

        public static void InsertPizza(Pizza pizza)
        {
            using PizzaContext db = new PizzaContext();
            db.Pizzas.Add(pizza);
            db.SaveChanges();
        }

        public static bool UpdatePizza(int id, Action<Pizza> edit)
        {
            using PizzaContext db = new PizzaContext();
            Pizza pizza = db.Pizzas.FirstOrDefault(p=>p.PizzaId ==id);

            if (pizza == null)
                return false;
            edit(pizza);
            db.SaveChanges();
            return true;
        }

        public static bool UpdatePizza(int id, string name, string description, string photo, decimal price, int? categoryId)
        {
            using PizzaContext db = new PizzaContext();
            Pizza pizza = db.Pizzas.FirstOrDefault(p => p.PizzaId == id);

            if (pizza == null)
                return false;

            pizza.Name = name;
            pizza.Description = description;
            pizza.Photo = photo;
            pizza.Price = price;
            pizza.CategoryId = categoryId;

            db.SaveChanges();

            return true;
        }

        public static bool DeletePizza(int id)
        {
            using PizzaContext db = new PizzaContext();

            Pizza pizza = db.Pizzas.FirstOrDefault(p => p.PizzaId == id);

            if (pizza == null)
                return false;

            db.Pizzas.Remove(pizza);
            db.SaveChanges();

            return true;
        }

        public static void Seed()
        {
            if (CountAllPizzas() == 0)
            {
                InsertPizza(new Pizza("Margherita", "Pomodoro, fiordilatte e basilico", "~/img/margherita.jpg", 5.5m));
                InsertPizza(new Pizza("Marinara", "Pomodoro, origano ed aglio", "~/img/marinara.jpg", 4.5m));
                InsertPizza(new Pizza("Diavola", "Pomodoro, fiordilatte e salame piccante", "~/img/diavola.jpg", 6m));
                InsertPizza(new Pizza("Carrettiera", "Friarielli, fiordilatte e salsiccia", "~/img/salsiccia-friarielli.jpg", 6.5m));
                InsertPizza(new Pizza("Pizza fritta", "Pizza ripiena di cicoli, ricotta, mozzarella e pomodoro, fritta in olio evo", "~/img/fritta.jpg", 6m));
                InsertPizza(new Pizza("Bufalina", "Margherita con mozzarella di bufala dop", "~/img/bufalina.jpg", 6.5m));
            }
        }
    }
}
