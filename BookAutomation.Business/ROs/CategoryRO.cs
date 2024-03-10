using BookAutomation.Business.DTOs;
using BookAutomation.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAutomation.Business.ROs
{
    public class CategoryRO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryRO ParentCategory { get; set; }
    }
}
