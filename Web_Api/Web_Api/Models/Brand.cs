using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public long BrandId { get; set; }
        public string? BrandName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
