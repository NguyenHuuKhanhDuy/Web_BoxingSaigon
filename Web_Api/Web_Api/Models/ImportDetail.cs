using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class ImportDetail
    {
        public string? ImportId { get; set; }
        public string? IdProduct { get; set; }
        public string? FullName { get; set; }
        public int? Quantity { get; set; }

        public virtual Product? IdProductNavigation { get; set; }
        public virtual Import? Import { get; set; }
    }
}
