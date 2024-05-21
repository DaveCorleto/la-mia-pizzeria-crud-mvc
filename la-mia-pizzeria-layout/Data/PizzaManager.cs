using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Test_MVC_2.Models;

namespace Test_MVC_2.Data

{
    public static class PizzaManager
    {
        //Uso dell'enum per gestire meglio nei metodi i vari tipi di risultato
        public enum ResultType
        {
            OK,
            Exception,
            NotFound
        }
        public static int ContaTuttelePizze()
        {
            //Creo un istanza temporanea di PizzaContext
            //e con la direttiva using comunico di chiudermi la "connessione"

            using PizzaContext db = new PizzaContext();
            return db.Pizzas.Count();
        }

        //Questo mi ritorna una Lista di tutte le pizze
        public static List<Pizza> RecuperaTutteLePizze()
        {
            using PizzaContext db = new PizzaContext();
            return db.Pizzas.ToList();
        }
        //Recupera la pizza dall'id
        public static Pizza RecuperaPizzaDaId(int id, bool includeReferences = true)
        {
            using PizzaContext db = new PizzaContext();
            //Se l'elemento pizza che sto recuperando dal db include una category mi verrà
            //restituita anche l'informazione della category

            if (includeReferences)
                return db.Pizzas.Where(x=>x.Id == id).Include(p=>p.Category).FirstOrDefault();

            //Altrimenti mi viene restituito solo l'elemento pizza con valore di category null

            return db.Pizzas.FirstOrDefault(p => p.Id == id);
        }


        public static void InserisciPizza(Pizza pizza)
        {
            using PizzaContext db = new PizzaContext();
            db.Pizzas.Add(pizza);
            db.SaveChanges();
        }


        //public static bool EditaPizza(int id, string name, string description, string url, float price)
        //{
        //    using PizzaContext db = new PizzaContext();
        //    var pizza = db.Pizzas.FirstOrDefault(p => p.Id == id);

        //    if (pizza == null)
        //    {
        //        return false;

        //    }

        //    pizza.Name = name;
        //    pizza.Description = description;
        //    pizza.Url = url;
        //    pizza.Price = price;
        //    db.SaveChanges();
        //    return true;
        //}

        //Alla Update (EditaPizza) Anzichè i parametri singoli gli passo direttamente l'oggetto Pizza

        public static bool EditaPizza(int id, Pizza pizza)
        {
            try
            {

                using PizzaContext db = new PizzaContext();
                //Assegno alla var pizzadamodificare il valore della query che mi restituisce la pizza che corrisponde a questo id

                var pizzaDaModificare = db.Pizzas.FirstOrDefault(p => p.Id == id);

                //Se la pizza in questione non esiste il valore mi ritorna null

                if (pizzaDaModificare == null)
                    return false;

                //altrimenti aggiorno i valori delle proprietà dell'oggetto pizza con i valori che gli passo 
                //dalla view update tramite form 
                    
                pizzaDaModificare.Name = pizza.Name;
                pizzaDaModificare.Description = pizza.Description;
                pizzaDaModificare.Price = pizza.Price;
                pizzaDaModificare.CategoryId = pizza.CategoryId;

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool PiallaPizza(int id)
        {
            try
            {
               //Qui recupero la pizza selezionata con il metodo Rec...NON creo un nuovo context del db perchè sta già lavorando quello
               //che utilizza RecuperaPizzaDaId...

                var pizzaDaCancellare = RecuperaPizzaDaId(id, false); // db.Pizzas.FirstOrDefault(p => p.Id == id);
                if (pizzaDaCancellare == null)
                    return false;

                //qui invece DEVO creare un nuovo contesto per essere sicuro che la rimozione dell'oggetto pizza venga tracciato dal DB'

                using PizzaContext db = new PizzaContext();
                db.Remove(pizzaDaCancellare);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static void PopolaDB()
        {
            if (PizzaManager.ContaTuttelePizze() == 0)
            {
                //string name, string description, string url, float price

                PizzaManager.InserisciPizza(new Pizza("Margherita", "Farina 0 Pomodoro mozzarella olio basilico", "img/pizza-1.jpg", 5.5f));
                PizzaManager.InserisciPizza(new Pizza("Moenese", "Farina 0 Pomodoro Puzzone funghi olio basilico", "img/pizza-2.jpg", 5.5f));
                PizzaManager.InserisciPizza(new Pizza("Schmidt", "Pomodoro mozzarella uovo pancetta e cetriolini", "img/pizza-3.jpg" ,9.5f));
                PizzaManager.InserisciPizza(new Pizza("Capricciosa", "Farina 0 Pomodoro mozzarella prosciutto cotto carciofi funghi olive olio", "img/pizza-4.jpg", 8.0f));
                PizzaManager.InserisciPizza(new Pizza("Quattro Formaggi", "Farina 0 Mozzarella gorgonzola parmigiano fontina olio", "img/pizza-5.jpg", 7.5f));
                PizzaManager.InserisciPizza(new Pizza("Diavola", "Farina 0 Pomodoro mozzarella salame piccante olio basilico", "img/pizza-6.jpg", 6.5f));

            }

        }

        //Perchè non vuole public?

        public static List<Category> GetAllCategories()
        {
            using PizzaContext db = new PizzaContext();
            return db.Categories.ToList();
        }

    }
}
