using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Models
{
    public class Category
    {
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "Non può essere più lungo di 50 caratteri")]
        public string Title { get; set; }

        public List<Pizza>? Pizzas { get; set; }


    }
}
