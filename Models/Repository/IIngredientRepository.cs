namespace la_mia_pizzeria_static.Models.Repository
{
    public interface IIngredientRepository
    {
        List<Ingredient> All();
        void Create(Ingredient ingredient);
        void Delete(Ingredient ingredient);
        Ingredient GetById(int id);
        void Update(Ingredient ingredient, Ingredient formData);
    }
}