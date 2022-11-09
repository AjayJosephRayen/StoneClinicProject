using System;
using System.Collections.Generic;

namespace StoneClinicAPI.Models
{
    public partial class Doctordetail
    {
        public Doctordetail()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Doctorid { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Sex { get; set; }
        public string? Specialization { get; set; }
        public string? VisitingHours { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
