namespace la_mia_pizzeria_static.Models.Repository
{
    public interface ICategoryRepository
    {
        List<Category> All();
        void Create(Category category);
        void Delete(Category category);
        Category GetByIdWithPizza(int id);
        Category GetById(int id);
   
        void Update(Category category, Category formData);
    }
}