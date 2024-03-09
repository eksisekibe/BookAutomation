using BookAutomation.Business.DTOs;
using BookAutomation.Business.ROs;
using BookAutomation.Entity.Concrete;

namespace BookAutomation.Business.Profiles
{
    public class CategoryProfile : AutoMapper.Profile
    {
        public CategoryProfile() 
        {
            CreateMap<Category, CategoryRO>();
            CreateMap<CategoryDTO, Category>();
        }
    }
}
