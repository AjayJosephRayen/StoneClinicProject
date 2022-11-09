using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StoneClinic.Models
{
    public partial class Appointment
    {
        [Display(Name = "Patient ID")]
        public int? Patientid { get; set; }
        [Display(Name = "Doctor ID")]
        public int? Doctorid { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name = "Date of Visit")]
        public DateTime? Dateofvisit { get; set; }
        [Display(Name = "Appointment ID")]
        public int Appointmentid { get; set; }
        [Display(Name = "Specialization")]
        public string? Specialization { get; set; }
        [Display(Name = "Appointment Time")]
        public int? Appointmenttime { get; set; }
    }
}
