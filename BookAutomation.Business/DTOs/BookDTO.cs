using BookAutomation.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAutomation.Business.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public DateTime PublishDate { get; set; }
        public int CategoryId { get; set; }
        public CategoryDTO Category { get; set; }
        public int LastModifiedById { get; set; }
        public UserDTO LastModifiedBy { get; set; }
    }
}
