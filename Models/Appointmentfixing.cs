using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace StoneClinic.Models
{
    public class Appointmentfixing
    {
       
        public int Patientid { get; set; }

        [Display(Name = "Doctor ID")]
        public int Doctorid { get; set; }
        public List<Appointment> appointmentlist { get; set; }//list of appointment
        public List<Patient> patientlist { get; set; }//list of patients

        [Display(Name = "Doctor's Name")]
        public string? Doctorname { get; set; }
        public string? Specialization { get; set; }
        
        public int? Appointmenttime { get; set; }
       
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? Dateofvisit { get; set; }
        public int Appointmentid { get; set; }
        public string? Patientname { get; set; }
        [Display(Name = "Visiting Hours")]
        public string? VisitingHours { get; set; }

    }
}
