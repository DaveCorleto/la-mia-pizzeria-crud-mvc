
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Quic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Test_MVC_2
{

    

    public class AppDbContext : DbContext
    {
        const string _connectionString = "Data Source=localhost;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Initial Catalog=PizzeriaDB;";

        //Unica tab delle pizze
        public DbSet<Pizza> Pizzas { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString); // Configura l'opzione di connessione
        }

    }
 }
