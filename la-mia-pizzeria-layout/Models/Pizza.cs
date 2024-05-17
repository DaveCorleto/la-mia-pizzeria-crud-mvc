using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Xml.Linq;

namespace Test_MVC_2.Models
{
    [Table("pizzas")]
    public class Pizza
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [StringLength(30, ErrorMessage = "Massimo 30 caratteri")]
        [MinLength(3)]

        public string Name { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [StringLength(100, ErrorMessage = "Massimo 100 caratteri")]
        [MinLength(5)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Url { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [Range(0.01, 999.99, ErrorMessage = "Il prezzo deve essere compreso tra 0,01 e 999,99.")]
        public float Price { get; set; }

        public Pizza(string name, string description, string url, float price)
        {
            Name = name;
            Description = description;
            Url = url;
            Price = price;
        }
        public Pizza() { }
    }



}
