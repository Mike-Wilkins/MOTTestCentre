﻿using KwikFitTestCentreApi.Models;
using Microsoft.EntityFrameworkCore;

namespace KwikFitTestCentreApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<MOTStatusDetails> MOTStatus { get; set; }
        public DbSet<MOTTestCertificateDetails> MOTTestCertificateDetails { get; set; }
        public DbSet<AuthorisedMOTTesters> AuthorisedMOTTesters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MOTStatusDetails>().
                HasKey(msd => msd.Id);

            modelBuilder.Entity<MOTTestCertificateDetails>().
               HasKey(msd => msd.Id);

            modelBuilder.Entity<AuthorisedMOTTesters>().
               HasKey(msd => msd.Id);
        }
    }
}
