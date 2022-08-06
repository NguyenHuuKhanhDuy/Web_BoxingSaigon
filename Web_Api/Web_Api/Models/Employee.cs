using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Orders = new HashSet<Order>();
        }

        public long? Id { get; set; }
        public string EmployeeId { get; set; } = null!;
        public string? Name { get; set; }
        public string? ContactEmp { get; set; }
        public string? Address { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
