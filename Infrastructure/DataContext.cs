﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Owner>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<PortfolioItem>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Owner>().HasData(
                    new Owner()
                    {
                        Id = Guid.NewGuid(),
                        Avatar = "avatar.jpeg",
                        FullName = "MOHAMED MAGDY",
                        Profil = "FULL STACK .NET DEVELOPER"
                    }
                );
        }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<PortfolioItem> PortfolioItems { get; set; }
    }
}
