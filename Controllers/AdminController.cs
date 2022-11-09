using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StoneClinic.Models;
using System.Data;
using System.Runtime.Intrinsics.Arm;
using System.Text;



namespace StoneClinic.Controllers
{
    public class AdminController : Controller
    {
        private readonly StoneClinicContext db;
        private readonly ISession session;
        public AdminController(StoneClinicContext _db, IHttpContextAccessor httpContextAccessor)
        {
            db = _db;
            session = httpContextAccessor.HttpContext.Session;//We use session to the verification of logins
        }
        public IActionResult Index()
        {
            var login = HttpContext.Session.GetString("uname");
            if (login != null)
            {
                return View();
            }
            else
            {

                return RedirectToAction("Login", "Admin");
            }
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AdminDatum a)
        {
            AdminDatum admindata = new AdminDatum();
            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(a), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync("https://localhost:7135/api/Admin", content))
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiresponse = await response.Content.ReadAsStringAsync();
                        admindata = JsonConvert.DeserializeObject<AdminDatum>(apiresponse);
                        HttpContext.Session.SetString("uname", admindata.Username);
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        HttpContext.Session.SetString("Error", "Error");
                        return RedirectToAction("login");
                    }
            }
        }
        public IActionResult AddDoctor()
        {
            var login = HttpContext.Session.GetString("uname");
            if (login != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public IActionResult AddDoctor(Doctordetail dd)
        {
            var login = HttpContext.Session.GetString("uname");
            if (login != null)
            {

                db.Doctordetails.Add(dd);
                db.SaveChanges();
                return RedirectToAction("AddDoctor");
            }
            else //if username not exists
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public IActionResult ViewDoctorDetails()
        {
            var login = HttpContext.Session.GetString("uname");
            if (login != null)
            {
                return View(db.Doctordetails.ToList());
            }
            else
            {

                return RedirectToAction("Login", "Admin");
            }
        }
        public IActionResult Editdoc(int id)
        {
            var login = HttpContext.Session.GetString("uname");
            if (login != null)
            {
                Doctordetail e = db.Doctordetails.Find(id);
                return View(e);
            }
            else
            {

                return RedirectToAction("Login", "Admin");
            }
        }
        [HttpPost]
        public IActionResult Editdoc(Doctordetail e)
        {
            var login = HttpContext.Session.GetString("uname");
            if (login != null)
            {
                db.Doctordetails.Update(e);
                db.SaveChanges();
                return RedirectToAction("ViewDoctorDetails");
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public IActionResult Deletedoc(int id)
        {
            var login = HttpContext.Session.GetString("uname");
            if (login != null)
            {

                Doctordetail e = db.Doctordetails.Find(id);
                return View(e);
            }
            else
            {

                return RedirectToAction("Login", "Admin");
            }
        }
        [HttpPost, ActionName("Deletedoc")]
        public IActionResult DeleteConfirmed(Doctordetail d)
        {
            var login = HttpContext.Session.GetString("uname");
            if (login != null)
            {
                var a = (from i in db.Appointments
                         where d.Doctorid == i.Doctorid
                         select i).FirstOrDefault();
                if (a == null)
                {
                    db.Doctordetails.Remove(d);
                    db.SaveChanges();
                    return RedirectToAction("ViewDoctorDetails");
                }
                else
                {
                    var doc = db.Doctordetails.Find(d.Doctorid);
                    ViewBag.deletedoctor = "Sorry!!! This doctor records cannot be deleted, as it has pending appointments with patients, It can be deleted only if appointment history deleted from Database";
                    return View(doc);
                }


            }
            else
            {

                return RedirectToAction("Login", "Admin");
            }
        }
        public IActionResult AddPatient()
        {
            var login = HttpContext.Session.GetString("uname");
            if (login != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        [HttpPost]
        public IActionResult AddPatient(Patient p)
        {
            var login = HttpContext.Session.GetString("uname");
            if (login != null)
            {
                var VAge = (DateTime.UtcNow.Ticks - p.Dob.Value.Ticks) / (864000000000 * 365);
                if (p.Age == VAge)
                {
                    db.Patients.Add(p);
                    db.SaveChanges();
                    return RedirectToAction("AddPatient");
                }
                else

                    ViewBag.pat = " Failed to add Patient, your dob doesnt match!!!";
                return View();
            }
            else
            {

                return RedirectToAction("Login", "Admin");
            }
        }
        public IActionResult ViewPatientDetails()
        {
            var login = HttpContext.Session.GetString("uname");
            if (login != null)
            {
                return View(db.Patients.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }

        }
        public IActionResult EditPat(int id)
        {
            var login = HttpContext.Session.GetString("uname");
            if (login != null)
            {
                Patient e = db.Patients.Find(id);
                return View(e);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        [HttpPost]
        public IActionResult EditPat(Patient ep)
        {
            var login = HttpContext.Session.GetString("uname");
            if (login != null)
            {
                db.Patients.Update(ep);
                db.SaveChanges();
                return RedirectToAction("ViewPatientDetails");
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public IActionResult DeletePat(int id)
        {
            var login = HttpContext.Session.GetString("uname");
            if (login != null)
            {
                Patient dp = db.Patients.Find(id);
                return View(dp);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }

        }
        [HttpPost, ActionName("Deletepat")]
        public IActionResult Delete(Patient dp)
        {
            var login = HttpContext.Session.GetString("uname");
            if (login != null)
            {
                var a = (from i in db.Appointments
                         where dp.Patientid == i.Patientid
                         select i).FirstOrDefault();
                if (a == null)
                {
                    db.Patients.Remove(dp);
                    db.SaveChanges();
                    return RedirectToAction("ViewPatientDetails");
                }
                else
                {
                    var pt = db.Patients.Find(dp.Patientid);
                    ViewBag.deletepatient = "Sorry!!! This patient records cannot be deleted as it has pending appointments, patient record can be deleted only if appointment history deleted";
                    return View(pt);
                }
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public IActionResult AddAppointment(int id)
        {
            HttpContext.Session.SetInt32("doc", id);
            Doctordetail dd = db.Doctordetails.Find(id);
            var login = HttpContext.Session.GetString("uname");
            if (login != null)
            {
                Appointmentfixing a = new();
                {
                    a.Doctorid = id;
                    a.Specialization = dd.Specialization;
                    a.VisitingHours = dd.VisitingHours;
                    a.Doctorname = dd.Firstname + " " + dd.Lastname;
                    a.patientlist = db.Patients.ToList();
                    a.appointmentlist = (from i in db.Appointments
                                         where i.Doctorid == id
                                         select i).ToList();
                }
                return View(a);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        [HttpPost]
        public IActionResult AddAppointment(Appointmentfixing apt)
        {
            Appointment a = new();
            var login = HttpContext.Session.GetString("uname");
            if (login != null)
            {
                var doc = HttpContext.Session.GetInt32("doc");
                Doctordetail dd = db.Doctordetails.Find(doc);
                {
                    a.Doctorid = dd.Doctorid;
                    a.Specialization = dd.Specialization;
                    a.Appointmenttime = apt.Appointmenttime;
                    a.Patientid = apt.Patientid;
                    a.Dateofvisit = apt.Dateofvisit;
                }
                db.Appointments.Add(a);
                db.SaveChanges();
                return RedirectToAction("ViewDoctorDetails", "Admin");
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public IActionResult ViewAppointments()
        {
            var login = HttpContext.Session.GetString("uname");
            if (login != null)
            {
                List<Appointment> appointmentlist = (from i in db.Appointments
                                                     where i.Dateofvisit >= DateTime.UtcNow
                                                     select i).ToList();  //for filtering out the past matter
                return View(appointmentlist);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public IActionResult CancelAppointment(int id)
        {
            var login = HttpContext.Session.GetString("uname");
            if (login != null)
            {
                Appointment dp = db.Appointments.Find(id);
                return View(dp);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        [HttpPost, ActionName("CancelAppointment")]
        public IActionResult CancelAppointment(Appointment dp)
        {
            var login = HttpContext.Session.GetString("uname");
            if (login != null)
            {
                db.Appointments.Remove(dp);
                db.SaveChanges();
                return RedirectToAction("ViewAppointments");
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public IActionResult Logout()
        {

            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Admin");
        }
        public IActionResult ViewAppointmentsAll()
        {
            return View(db.Appointments.ToList());
        }
    }
}



