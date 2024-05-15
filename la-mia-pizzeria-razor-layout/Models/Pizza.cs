namespace la_mia_pizzeria_razor_layout.Models
{
    public class Pizza
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public decimal Price { get; set; }

        public Pizza() { }

        public Pizza(string name, string description, string photo, decimal price)
        {
            this.Name = name;
            this.Description = description;
            this.Photo = photo;
            this.Price = price;
        }
    }
}
