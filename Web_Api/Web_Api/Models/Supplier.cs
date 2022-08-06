using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Imports = new HashSet<Import>();
        }

        public long? Id { get; set; }
        public string SupplierId { get; set; } = null!;
        public string? Name { get; set; }
        public string? ContactSup { get; set; }
        public string? Address { get; set; }

        public virtual ICollection<Import> Imports { get; set; }
    }
}
