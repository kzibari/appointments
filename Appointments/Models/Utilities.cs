using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Appointments.Models
{
    public class Utilities
    {
        public static void SendEmailNotification(Appointment appointment, string message)
        {
            //send email notofication to user
            try
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.SmtpPort = 587;
                WebMail.UserName = "kzibari@gmail.com";
                WebMail.Password = "KoKo2072";
                WebMail.From = "kzibari@gmail.com";
                WebMail.EnableSsl = true;
                WebMail.Send(appointment.Email, "Your Appointment", "Hello " + appointment.Name  +",<br><br>"+ message+ appointment.TheDate.ToString("dd MMMM yyyy") + " at " + appointment.TheTime + ".");

            }
            catch (Exception ex) { }
        }
        public static List<SelectListItem> GetDropDownListTimes()
        {
            List<SelectListItem> times = new List<SelectListItem>();
            times.Add(new SelectListItem { Text = "09:00" });
            times.Add(new SelectListItem { Text = "09:30" });
            times.Add(new SelectListItem { Text = "10:00" });
            times.Add(new SelectListItem { Text = "10:30" });
            times.Add(new SelectListItem { Text = "11:00" });
            times.Add(new SelectListItem { Text = "11:30" });
            times.Add(new SelectListItem { Text = "12:00" });
            times.Add(new SelectListItem { Text = "12:30" });
            times.Add(new SelectListItem { Text = "13:00" });
            times.Add(new SelectListItem { Text = "13:30" });
            times.Add(new SelectListItem { Text = "14:00" });
            times.Add(new SelectListItem { Text = "14:30" });
            times.Add(new SelectListItem { Text = "15:00" });
            times.Add(new SelectListItem { Text = "15:30" });
            times.Add(new SelectListItem { Text = "16:00" });
            times.Add(new SelectListItem { Text = "16:30" });


            return times;
        }
    }
}