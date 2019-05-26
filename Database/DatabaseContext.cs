﻿using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Database
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DatabaseContext()
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<ItemStatus> ItemStatuses { get; set; }
        public virtual DbSet<LibraryItem>  LibraryItems { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}