using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;


namespace StoneClinic.Models
{
    public partial class AdminDatum
    {
        
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string Username { get; set; } = null!;               
        public string? Password { get; set; }
    }
}
