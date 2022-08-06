using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class Product
    {
        public long? Id { get; set; }
        public string IdProduct { get; set; } = null!;
        public string? Name { get; set; }
        public string? FullName { get; set; }
        public long? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public long? BrandId { get; set; }
        public string? BrandName { get; set; }
        public long? Price { get; set; }
        public long? OnHand { get; set; }
        public string? Img { get; set; }
        public long? AttributesId { get; set; }
        public string? AttributesName { get; set; }
        public string? AttributesValue { get; set; }

        public virtual AttributeModel? Attributes { get; set; }
        public virtual Brand? Brand { get; set; }
        public virtual Category? Category { get; set; }
    }
}
