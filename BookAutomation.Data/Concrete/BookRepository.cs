using BookAutomation.Data.Abstract;
using BookAutomation.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookAutomation.Data.Concrete
{
    public class BookRepository : PgGenericRepository<Book>, IBookRepository
    {
        public BookRepository(PostgreSqlContext context) : base(context)
        {
        }

        public async Task<List<Book>> GetByAuthorAsync(string author)
        {
            return await _context.Books.Where(g => g.Author.ToLower().Contains(author.ToLower())).ToListAsync();
        }

        public async Task<List<Book>> GetByGenreAsync(string genre)
        {
            return await _context.Books.Where(g => g.Genre.ToLower().Contains(genre.ToLower())).ToListAsync();
        }

        public async Task<List<Book>> GetByNameAsync(string name)
        {
            return await _context.Books.Where(n => n.Name.ToLower().StartsWith(name.ToLower()) || n.Name.ToLower().Contains(name.ToLower())).ToListAsync();
        }
        public async Task<List<Book>> GetCategoryBooksAsync(int categoryId)
        {
            return await _context.Categories.Where(c => c.Id == categoryId).SelectMany(c => c.Books).ToListAsync();
        }

        public Task<User> GetLastModifiedByAsync(int bookId)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetLastModifiedUserNameAsync(int bookId)
        {
            var book = await _context.Books.Include(b => b.LastModifiedBy).FirstOrDefaultAsync(b => b.Id == bookId);

            if (book != null && book.LastModifiedBy != null)
            {
                return $"{book.LastModifiedBy.FirstName} {book.LastModifiedBy.LastName}";
            }
            else
            {
                return "Bilinmiyor";
            }
        }

    }
}
