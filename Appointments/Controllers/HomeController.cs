using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Appointments.Models;


namespace Appointments.Controllers
{
    public class HomeController : Controller
    {
        DBContext _db = new DBContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                //Save user date in Database
                _db.Appointments.Add(appointment);
                _db.SaveChanges();
                Utilities.SendEmailNotification(appointment, "This is to confirm that you have an appointment on ");
                return View("Confirmation", appointment);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Amend()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Amend(string email)
        {
                var model = from r in _db.Appointments
                            where r.Email == email
                            select r;
            if (model.Any())
            {
                return View("AmendAppointment", model.First());
            }
            else
            {
                ViewBag.Message = "No appointments could be found for anyone with this email address. Please try again.";
                return View();
            }
        }

        public ActionResult SaveChanges(Appointment appointment)
        {
            
            var app = from r in _db.Appointments
                              where r.Email == appointment.Email
                              select r;

            _db.Appointments.Remove(app.First());
            _db.Appointments.Add(appointment);
            _db.SaveChanges();
            Utilities.SendEmailNotification(appointment, "This is to confirm that your appoitmnet has been amended to ") ;
            return View("AmendConfirmation", appointment);
        }
        public ActionResult DeleteAppointment(Appointment appointment)
        {
            var app = from r in _db.Appointments
                      where r.Email == appointment.Email
                      select r;

            _db.Appointments.Remove(app.First());
            _db.SaveChanges();
            Utilities.SendEmailNotification(appointment, "This is to confirm that your appoitmnet has been canceled. ");
            return View("DeleteConfirmation", appointment);
        }

        public ActionResult Contact()
        {

            return View();
        }
        public ActionResult About()
        {
           
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if(_db != null){
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
        
    }

}