using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class OrderDetail
    {
        public string? OrderId { get; set; }
        public string? IdProduct { get; set; }
        public string? FullName { get; set; }
        public int? Quantity { get; set; }
        public long? Price { get; set; }
        public double? Discount { get; set; }
        public double? SubTotal { get; set; }

        public virtual Product? IdProductNavigation { get; set; }
        public virtual Order? Order { get; set; }
    }
}
