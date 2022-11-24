namespace la_mia_pizzeria_static.Models
{
    public class Ingredient
    {
        public int Id { get; set; }

        public string Title { get; set; }

        //relazione con la pizza
        public List<Pizza>? Pizza { get; set; }


    }
}
