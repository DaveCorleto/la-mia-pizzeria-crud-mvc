using Microsoft.Extensions.Hosting;

namespace Test_MVC_2.Models
{
    public class PizzaFormModel
    {
        public Pizza Pizza { get; set; }
        public List<Category>? Categories { get; set; }

        public PizzaFormModel() { }

        public PizzaFormModel(Pizza p, List<Category> c)
        {
            this.Pizza = p;
            this.Categories = c;
        }
    }
}