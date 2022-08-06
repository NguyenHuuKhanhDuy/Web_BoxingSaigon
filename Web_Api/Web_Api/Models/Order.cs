using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class Order
    {
        public long? Id { get; set; }
        public string OrderId { get; set; } = null!;
        public DateTime? OrderDate { get; set; }
        public string? SoldById { get; set; }
        public string? SoldByName { get; set; }
        public double? Total { get; set; }
        public double? Discount { get; set; }
        public double? TotalPayment { get; set; }
        public string? CustomerId { get; set; }
        public string? CustomerName { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Employee? SoldBy { get; set; }
    }
}
