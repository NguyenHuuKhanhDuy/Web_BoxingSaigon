using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public long? Id { get; set; }
        public string CustomerId { get; set; } = null!;
        public string? Name { get; set; }
        public string? ContactNumber { get; set; }
        public string? Address { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
