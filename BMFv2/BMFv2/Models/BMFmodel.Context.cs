﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BMFEntities : DbContext
    {
        public BMFEntities()
            : base("name=BMFEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
    }
}
