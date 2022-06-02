using MyFirstProjectMVC1.Interfaces;
using MyFirstProjectMVC1.Models;

namespace MyFirstProjectMVC1.Mapping
{
    public class CategoryMapper : IMapper<Entities.Category, CategoryModel>
    {
        public CategoryModel MapFromEntityToModel(Entities.Category source) => new CategoryModel
        {
           
            Name = source.Name,
            Description = source.Description,
            Code = source.Code,
            Id = source.Id,
        };

        public Entities.Category MapFromModelToEntity(CategoryModel source)
        {
            var entity = new Entities.Category();

            MapFromModelToEntity(source, entity);

            return entity;
        }

        public void MapFromModelToEntity(CategoryModel source, Entities.Category target)
        {
            target.Name = source.Name;
            target.Description = source.Description;
            target.Code = source.Code; 
            target.Id = source.Id;
        }
    }
}
