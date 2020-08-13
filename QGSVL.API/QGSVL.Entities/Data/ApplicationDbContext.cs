using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QGSVL.EntityLayer.Entities.DataEntity;
using QGSVL_WebAPI.Models.DataEntities;

namespace QGSVL.EntityLayer.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<user> User { get; set; }
        public DbSet<BankDetail> BankDetails { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<MaritalStatus> MaritalStatus { get; set; }
        public DbSet<Nationality> Nationality { get; set; }
        public DbSet<EmploymentStatus> EmploymentStatus { get; set; }
        public DbSet<ContractType> ContractType { get; set; }
        public DbSet<PropertyStatus> PropertyStatus { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<Driver> Driver { get; set; }
        public DbSet<EmployementDetail> EmployementDetail { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<IncludedServices> IncludedServices { get; set; }
        public DbSet<Insurance> Insurance { get; set; }
        public DbSet<Mileage> Mileage { get; set; }
        public DbSet<PaybackTime> PaybackTime { get; set; }
        public DbSet<Quote> Quote { get; set; }
        public DbSet<RentDetail> RentDetail { get; set; }
        public DbSet<QuoteStatus> QuoteStatus { get; set; }
        public DbSet<VehicleDetail> VehicleDetail { get; set; }
    }
}
