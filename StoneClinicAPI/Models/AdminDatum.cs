using System;
using System.Collections.Generic;

namespace StoneClinicAPI.Models
{
    public partial class AdminDatum
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string Username { get; set; } = null!;
        public string? Password { get; set; }
    }
}
