using MessagePack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace StoneClinic.Models
{
    public partial class Patient
    {

       
        public int Patientid { get; set; }
       
        [Required]
        [StringLength(60, MinimumLength = 3)]

        [Display(Name = "First Name")]
        [DataType(DataType.Text)]
        
        [RegularExpression(@"^[a-zA-Z /'/]+$", ErrorMessage = "Only Alphabets are Allowed")]

        public string? Fname { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [DataType(DataType.Text)]

        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Only Alphabets are Allowed")]
        public string? Lname { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public string? Sex { get; set; }
       
        [Required]
       
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? Dob { get; set; }
        [Required]
       
       
        public int? Age { get; set; }
    }
}
