using System;
using System.Collections.Generic;

namespace StoneClinicAPI.Models
{
    public partial class Appointment
    {
        public int? Patientid { get; set; }
        public int? Doctorid { get; set; }
        public TimeSpan? Appointmenttime { get; set; }
        public DateTime? Dateofvisit { get; set; }
        public int Appointmentid { get; set; }

        public virtual Doctordetail? Doctor { get; set; }
        public virtual Patient? Patient { get; set; }
    }
}
