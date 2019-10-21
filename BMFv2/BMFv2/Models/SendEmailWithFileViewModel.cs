using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BMFv2.Models
{
    public class SendEmailWithFileViewModel
    {
        [Required(ErrorMessage = "Please enter your Name.")]
        public string FromName { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Please enter an email address.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string FromEmail { get; set; }

        [Required(ErrorMessage = "Please enter a Message.")]
        public string Message { get; set; }

        public HttpPostedFileBase Upload { get; set; }

    }
}