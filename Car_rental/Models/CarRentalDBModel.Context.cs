﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Car_rental.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CarRentalDBEntities : DbContext
    {
        public CarRentalDBEntities()
            : base("name=CarRentalDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<kategorie> kategories { get; set; }
        public virtual DbSet<marki> markis { get; set; }
        public virtual DbSet<modele> modeles { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<samochody> samochodies { get; set; }
        public virtual DbSet<uzytkownicy> uzytkownicies { get; set; }
        public virtual DbSet<wypozyczenia> wypozyczenias { get; set; }
    }
}