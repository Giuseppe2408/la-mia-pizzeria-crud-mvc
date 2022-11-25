namespace la_mia_pizzeria_static.Models.Repository
{
    public interface IDbCategoryRepository
    {
        List<Category> All();
        void Createcat(Category category);
        void DeleteCat(Category category);
        Category GetByIdWithPizza(int id);
        Category GetCatById(int id);
        void UpdateCat(Category category);
    }
}