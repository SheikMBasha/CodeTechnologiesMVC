﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CodeTechnologiesMVC
{
    using CodeTechnologiesMVC.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class sadiqEntities2 : DbContext
    {
        public sadiqEntities2()
            : base("name=sadiqEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<academy> academies { get; set; }
        public DbSet<account> accounts { get; set; }
        public DbSet<candidate> candidates { get; set; }
        public DbSet<client> clients { get; set; }
        public DbSet<code> codes { get; set; }
        public DbSet<confighiredprometric> confighiredprometrics { get; set; }
        public DbSet<examnature> examnatures { get; set; }
        public DbSet<exam> exams { get; set; }
        public DbSet<examstraining> examstrainings { get; set; }
        public DbSet<expens> expenses { get; set; }
        public DbSet<institute> institutes { get; set; }
        public DbSet<mail> mails { get; set; }
        public DbSet<pricing> pricings { get; set; }
        public DbSet<prometric> prometrics { get; set; }
        public DbSet<prometricpromotion> prometricpromotions { get; set; }
        public DbSet<trainingaccount> trainingaccounts { get; set; }
        public DbSet<vendor> vendors { get; set; }
        public DbSet<voucher> vouchers { get; set; }

        public virtual List<client> GetAllClients()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<client>("call GetAllClients();").ToList();
        }

        public virtual List<string> GetAllExamCodes()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<string>("call GetAllExamCodes();").ToList();
        }

        public virtual List<vendor> GetAllVendors()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<vendor>("call GetAllVendors();").ToList();
        }

        public virtual List<MailViewModel> GetMailDetails()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<MailViewModel>("call GetMailDetails();").ToList();
        }
    }
}
