using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace StoneClinic.Models
{
    public partial class Doctordetail
    {
        public int Doctorid { get; set; }
        [Required]
        
        
        [DataType(DataType.Text)]

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabets are Allowed")]
        public string? Firstname { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [DataType(DataType.Text)]

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabets are Allowed")]
        public string? Lastname { get; set; }
        [Required]
       
        public string? Sex { get; set; }
        [Required]
        
        public string? Specialization { get; set; }
        [Required]
        
        public string? VisitingHours { get; set; }
    }
}
