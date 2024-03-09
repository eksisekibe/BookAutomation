using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAutomation.Entity.Abstract
{
    public class BaseEntity
    {
        [Key] 
        public int Id { get; set; }
        public bool? Deleted { get; set; } = false;
        public DateTimeOffset? Created_at { get; protected set; } = DateTimeOffset.Now;
        public DateTimeOffset? Updated_at { get; set; }
    }
}
