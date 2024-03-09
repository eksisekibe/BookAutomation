using BookAutomation.Business.DTOs;
using BookAutomation.Business.ROs;
using BookAutomation.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAutomation.Business.Abstract
{
    public interface ICategoryService : IService<CategoryRO, CategoryDTO>, IResponser<Category, CategoryRO>, IValidator<Category>
    {
        Task<List<CategoryRO>> GetNameAsync(string name);
        //Task<List<CategoryRO>> GetSubcategoriesAsync(int parentId);
    }
}
