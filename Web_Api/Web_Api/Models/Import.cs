using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class Import
    {
        public long? Id { get; set; }
        public string ImportId { get; set; } = null!;
        public DateTime? ImportDate { get; set; }
        public string? SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public string? Note { get; set; }
        public int? ImportStatus { get; set; }
        public string? ImportById { get; set; }
        public string? ImportByName { get; set; }

        public virtual Supplier? Supplier { get; set; }
    }
}
