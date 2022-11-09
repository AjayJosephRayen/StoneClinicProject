using System;
using System.Collections.Generic;

namespace StoneClinicAPI.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Patientid { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? Sex { get; set; }
        public int? Age { get; set; }
        public DateTime? Dob { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
