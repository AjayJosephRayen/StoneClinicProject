using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace StoneClinic.Models
{
    public class Appointmentinfo
    {
        
        public int Patientid { get; set; }
        public string Patientname { get; set; }
        public int Doctorid { get; set; }
        public string Doctorname { get; set; }
        public string Specialization { get; set; }
        public TimeSpan? Appointmenttime { get; set; }
        public DateTime? Dateofvisit { get; set; }
        public string VisitingHours { get; set; }
        public int Appointmentid { get; set; }
    }
}
