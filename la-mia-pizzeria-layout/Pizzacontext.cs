using Microsoft.EntityFrameworkCore;
using Test_MVC_2.Models;

namespace Test_MVC_2
{



    public class PizzaContext : DbContext
    {
        
        //Unica tab delle pizze
        public DbSet<Pizza> Pizzas { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        public const string _connectionString = "Data Source=localhost;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Initial Catalog=PizzeriaDB;";



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString); // Configura l'opzione di connessione
        }

    }
 }
