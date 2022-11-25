namespace la_mia_pizzeria_static.Models.Repository
{
    public interface IDbIngredientRepository
    {
        List<Ingredient> All();
        void CreateIng(Ingredient ingredient);
        void DeleteIng(Ingredient ingredient);
        Ingredient GetIngById(int id);
        void UpdateIng(Ingredient ingredient);
    }
}