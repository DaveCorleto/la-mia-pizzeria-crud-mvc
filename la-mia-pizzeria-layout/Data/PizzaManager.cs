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


    }
}
