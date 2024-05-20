﻿using la_mia_pizzeria_razor_layout.Models;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_razor_layout.Data
{
    public class PizzaContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=db_pizza;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}
