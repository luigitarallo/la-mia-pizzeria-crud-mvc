﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace la_mia_pizzeria_razor_layout.Models
{
    [Table("pizza")]
    [Index(nameof(Name), IsUnique=true)]
    public class Pizza
    {
        [Key] public int PizzaId { get; set; }
        [Required(ErrorMessage ="Pizza name is mandatory")]
        [StringLength(25, ErrorMessage = "Pizza name has to be under 25 letters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pizza description is mandatory")]

        public string Description { get; set; }

        [Required(ErrorMessage ="Pizza photo is mandatory")]
        public string Photo { get; set; }

        [Price(ErrorMessage = "Invalid price format or value.")]
        public decimal Price { get; set; }

        public Pizza() { }

        public Pizza(string name, string description, string photo, decimal price)
        {
            this.Name = name;
            this.Description = description;
            this.Photo = photo;
            this.Price = price;
        }

        public Pizza(int pizzaId, string name, string description, string photo, decimal price)
        {
            PizzaId = pizzaId;
            Name = name;
            Description = description;
            Photo = photo;
            Price = price;
        }
    }
}
