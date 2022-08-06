using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class User
    {
        public string UserId { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string? PassWord { get; set; }
        public string? Role { get; set; }
    }
}
