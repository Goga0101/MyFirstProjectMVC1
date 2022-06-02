using Microsoft.EntityFrameworkCore;
using MyFirstProjectMVC1.Data;
using MyFirstProjectMVC1.Entities;
using MyFirstProjectMVC1.Interfaces;
using MyFirstProjectMVC1.Mapping;
using MyFirstProjectMVC1.Models;

namespace MyFirstProjectMVC1.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly MyFirstProjectMVC1Context _context;
        private readonly IMapper<Entities.Category, CategoryModel> _categoryMapper;

        public CategoryService(MyFirstProjectMVC1Context context)
        {
            _categoryMapper = new CategoryMapper();
            _context = context;
        }
 
        public CreateCategoryResponse CreateCategory(CategoryModel category)
        {
            var categoryAlreadyExists = _context.Categories.Any(p => p.Id == category.Id);

            if (categoryAlreadyExists)    
            {
                throw new DbUpdateException($"Category with id '{category.Id}' already exist.");   
            }

            var categoryEntity = _categoryMapper.MapFromModelToEntity(category);

            var newCategory = _context.Categories.Add(categoryEntity);

            _context.SaveChanges();
             
            return new CreateCategoryResponse { CreatedCategory = category };
        }

        public GetCategoryResponse GetCategory(GetCategoryRequest getCategoryRequest)
        {
            var category = _context.Categories.Find(getCategoryRequest.Id); // get from base, we have entity type object
            var categoryModel = _categoryMapper.MapFromEntityToModel(category); // using mapper to get category Model
            var response = new GetCategoryResponse { Category = categoryModel };

            return response;
        }

        public UpdateCategoryResponse UpdateCategory(UpdateCategoryRequest updateCategoryRequest)
        {
            var existingCategoryToUpdate = _context.Categories.Find(updateCategoryRequest.CategoryToUpdate.Id);

            if (existingCategoryToUpdate == null)
            {
                throw new DbUpdateException($"Category with Id {updateCategoryRequest.CategoryToUpdate.Id} does not exist ");
            }

            _categoryMapper.MapFromModelToEntity(updateCategoryRequest.CategoryToUpdate, existingCategoryToUpdate);
            _context.SaveChanges();

            return new UpdateCategoryResponse { UpdatedCategory = updateCategoryRequest.CategoryToUpdate };
        }

        public DeleteCategoryResponse DeleteCategory(DeleteCategoryRequest deleteCategoryRequest)
        {
            var categoryToDelete = _context.Categories.Find(deleteCategoryRequest.Id);
            if (categoryToDelete == null)
            {
                throw new DbUpdateException($"Category with id '{deleteCategoryRequest.Id}' doesn't exist.");
            }

            _context.Categories.RemoveRange(_context.Categories);
            _context.SaveChanges();

            return new DeleteCategoryResponse();
        }



        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories;
        }
        // var category = _context.Categories.Find(getCategoryRequest.Id); 
        // IEnumerable<Category>
        // List<Category>
    }
}
