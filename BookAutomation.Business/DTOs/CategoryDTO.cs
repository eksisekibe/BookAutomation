﻿using BookAutomation.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAutomation.Business.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public int? SubCategoryId { get; set; }
        //public List<CategoryDTO> Subcategories { get; set; }
        public string? SubCategory { get; set; }
        public string? Book { get; set; }
        public List<BookDTO> Books { get; set; }

        
    }
}