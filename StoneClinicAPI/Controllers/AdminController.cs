using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using StoneClinicAPI.Models;
using static System.Net.Mime.MediaTypeNames;

namespace StoneClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly StoneClinicContext db;
        
        public AdminController(StoneClinicContext _db)
        {   
            db = _db;
        }
        [HttpGet]
        public IActionResult GetLogin()
        {
            return Ok(db.AdminData.ToList());
        }
        [HttpPost]
        public IActionResult Login(AdminDatum a)
        {
            var login = (from i in db.AdminData
                         where i.Username == a.Username && i.Password == a.Password
                         select i).SingleOrDefault();  //using linq statement for validating login credentials
            if (login != null)
            {
                return Ok(login);
            }
            else
            {
                return BadRequest();
            }
            
            }
       
    }
}
