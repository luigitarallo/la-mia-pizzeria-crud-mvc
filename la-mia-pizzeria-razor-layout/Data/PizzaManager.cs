using la_mia_pizzeria_razor_layout.Models;

namespace la_mia_pizzeria_razor_layout.Data
{
    public class PizzaManager
    {
        public static List<Pizza> GetAllPizzas()
        {
            using PizzaContext db = new PizzaContext();
            return db.Pizzas.ToList();
        }

        public static Pizza GetPizzaById(int id)
        {
            using PizzaContext db = new PizzaContext();
            Pizza pizza = db.Pizzas.FirstOrDefault(p => p.PizzaId == id);
            if (pizza == null)
            {
                return null;
            }
            return pizza;
        }
    }
}
