using BookAutomation.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAutomation.Business.DTOs
{
    public class CategoryDTO
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
