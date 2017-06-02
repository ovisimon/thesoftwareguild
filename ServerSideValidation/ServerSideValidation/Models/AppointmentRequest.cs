using ServerSideValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServerSideValidation.Models
{
    [NoGarfieldMondays(ErrorMessage = "Garfield cannot come on Mondays!")]
    public class AppointmentRequest
    {
        [Required(ErrorMessage = "Please enter a name")]
        public string ClientName { get; set; }

        [Required(ErrorMessage ="Please enter a date")]
        
        [FutureDate(ErrorMessage = "Must be a future date!")]
        public DateTime Date { get; set; }

        [MustBeTrueAttribute(ErrorMessage = "You must accept the terms and conditions!")]
        public bool TermsAccepted { get; set; }
    }
}