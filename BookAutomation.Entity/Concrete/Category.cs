using BookAutomation.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAutomation.Entity.Concrete
{
    public class Category : BaseEntity
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public int? SubCategoryId { get; set; }
        //public List<Category> Subcategories { get; set; }

        //public Category SubCategory { get; set; }
        public string? Book { get; set; }
        public string? SubCategory { get; set; }
        public List<Book> Books { get; set; }
    }
}
