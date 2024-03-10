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
        public string Name { get; set; }
        public string Description { get; set; }

        public int? ParentCategoryId { get; set; }
        public Category? ParentCategory { get; set; }
    }
}
