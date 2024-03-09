using BookAutomation.Data.Abstract;
using BookAutomation.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAutomation.Data.Concrete
{
    public class CategoryRepository : PgGenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(PostgreSqlContext context) : base(context)
        {
        }

        public async Task<List<Category>> GetNameAsync(string name)
        {
            return await _context.Categories.Where(c => c.Name.ToLower() == name.ToLower()).ToListAsync();
        }

        //public async Task<List<Category>> GetSubcategoriesAsync(int parentId)
        //{
        //    return await _context.Categories.Where(c => c.SubCategoryId == parentId).ToListAsync();
        //}
    }
}
