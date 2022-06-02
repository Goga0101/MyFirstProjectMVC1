using MyFirstProjectMVC1.Entities;
using MyFirstProjectMVC1.Models;

namespace MyFirstProjectMVC1.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
        GetCategoryResponse GetCategory(GetCategoryRequest request);
        CreateCategoryResponse CreateCategory(CategoryModel request);
        UpdateCategoryResponse UpdateCategory(UpdateCategoryRequest request);
        DeleteCategoryResponse DeleteCategory(DeleteCategoryRequest request);
    }
}






