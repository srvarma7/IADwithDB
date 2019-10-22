//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BMFv2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Review
    {

        [Required]
        [Display(Name = "Review Id")]
        public string ReviewId { get; set; }

        [Required]
        [Display(Name = "Rating")]
        public Nullable<int> Rating { get; set; }

        [Required]
        [Display(Name = "Comment")]
        public string RatingComment { get; set; }

        [Required]
        [Display(Name = "User Id")]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Booking Id")]
        public string BookingId { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Booking Booking { get; set; }
    }
}
