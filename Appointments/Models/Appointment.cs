using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Appointments.Models
{
    public class Appointment
    {

        public int? ID { get; set; }
        [Required(ErrorMessage ="Enter your name")]
        [StringLength(50, MinimumLength =3, ErrorMessage ="Invalid name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Enter your email address")]
        [EmailAddress]
        public string Email { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage ="Enter a date")]
        public DateTime TheDate{ get; set; }
        [Required(ErrorMessage ="Enter a time")]
        public string TheTime { get; set; }
    }
}