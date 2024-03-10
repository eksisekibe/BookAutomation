using BookAutomation.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAutomation.Entity.Concrete
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public DateTime PublishDate { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
