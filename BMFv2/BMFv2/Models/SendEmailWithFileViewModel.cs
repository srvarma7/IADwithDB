using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BMFv2.Models
{
    public class SendEmailWithFileViewModel
    {
        [Display(Name = "To Email")]
        [Required(ErrorMessage = "Please enter email.")]
        public string FromName { get; set; }

        [Display(Name = "Your Email")]
        [Required(ErrorMessage = "Please enter an email address.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string FromEmail { get; set; }

        [Display(Name = "Message")]
        [Required(ErrorMessage = "Please enter a Message.")]
        public string Message { get; set; }

        public HttpPostedFileBase Upload { get; set; }

    }
}