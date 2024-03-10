using BookAutomation.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAutomation.Business.ROs
{
    public class BookRO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public DateTime PublishDate { get; set; }
        public CategoryRO Category { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
