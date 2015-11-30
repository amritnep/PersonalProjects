using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using LoanManagementSystem.Models;

namespace LoanManagementSystem.DAL
{
    public class LoanContext : DbContext
    {
        public LoanContext():base("LoanContext")
        {

        }
        public DbSet<Collector> Collectors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerRating> CustomerRatings { get; set; }
        public DbSet<LoanContract> LoanContracts { get; set; }
        public DbSet<LoanPayment> LoanPayments { get; set; }
        public DbSet<LoanStatus> LoanStatuses { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        //public System.Data.Entity.DbSet<LoanManagementSystem.ViewModel.CustomerViewModel> CustomerViewModels { get; set; }
    }
}