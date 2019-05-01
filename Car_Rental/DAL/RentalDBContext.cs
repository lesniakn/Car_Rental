using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Car_Rental.Models;

namespace Car_Rental.DAL
{
    public class RentalDBContext : DbContext
    {
        public RentalDBContext() : base("RentalDBContext")
        {
        }
        public DbSet<Cars> Samochody { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}