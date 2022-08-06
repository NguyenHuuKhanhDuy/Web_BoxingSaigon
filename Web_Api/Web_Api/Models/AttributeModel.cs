using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class AttributeModel
    {
        public AttributeModel()
        {
            Products = new HashSet<Product>();
        }

        public long AttributesId { get; set; }
        public string? AttributesName { get; set; }
        public string? AttributesValue { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
