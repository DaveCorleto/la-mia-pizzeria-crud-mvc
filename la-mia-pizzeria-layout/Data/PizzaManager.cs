using Test_MVC_2.Models;

namespace Test_MVC_2.Data

{
    public static class PizzaManager
    {
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
        public static Pizza RecuperaPizzaDaId(int id)
        {
            using PizzaContext db = new PizzaContext();
            return db.Pizzas.FirstOrDefault(p => p.Id == id);
        }

        public static void InserisciPizza(Pizza pizza)
        {
            using PizzaContext db = new PizzaContext();
            db.Pizzas.Add(pizza);
            db.SaveChanges();
        }

        public static bool EditaPizza(int id, string name, string description, string url, float price)
        {
            using PizzaContext db = new PizzaContext();
            var pizza = db.Pizzas.FirstOrDefault(p => p.Id == id);

            if (pizza == null)
            {
                return false;

            }

            pizza.Name = name;
            pizza.Description = description;
            pizza.Url = url;
            pizza.Price = price;
            db.SaveChanges();

            return true;
        }

        public static bool PiallaPizza(int id)
        {
            using PizzaContext db = new PizzaContext();
            var pizzaDaPiallare = db.Pizzas.FirstOrDefault(p => p.Id == id);

            if (pizzaDaPiallare == null)
            {
                return false;
            }
            else
            {
                db.Pizzas.Remove(pizzaDaPiallare);
                db.SaveChanges();
                return true;
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
    }
}
