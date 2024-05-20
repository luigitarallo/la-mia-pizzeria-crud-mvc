using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_razor_layout.Models
{
    public class PizzaFormModel
    {
        public Pizza Pizza { get; set; }
        public List<Category>? Categories { get; set; }

        public PizzaFormModel() { }
        public PizzaFormModel(Pizza pizza, List<Category> categories) 
        {
            this.Pizza = pizza;
            this.Categories = categories;
        }

    }
}
