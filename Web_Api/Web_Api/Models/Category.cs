using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public long CategoryId { get; set; }
        public long? ParentId { get; set; }
        public string? CategoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
