using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
using System.Xml.Linq;

namespace Test_MVC_2
{
    public class Pizza
    {
        //        Una pizza avrà le seguenti informazioni :

        //un nome
        //una descrizione
        //una foto(url)
        //un prezzo Modifichiamo quindi la view Index.cshtml generata in automatico da.Net Core
        //scrivendo l’html che serve a noi per mostrare l’elenco delle pizze (possiamo creare una tabella
        //con bootstrap o una qualche grafica a nostro piacimento che mostri l’elenco delle pizze...
        //proviamo un po’ di creatività se vogliamo!)
        //Piccolo suggerimento : ricordatevi di inserire il seguente codice all’inizio della vostra view
        //@ { Lay
        //out = null; }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
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
