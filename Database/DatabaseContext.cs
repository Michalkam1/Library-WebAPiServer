using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace Database
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
            //lazy loading
        }

        public DatabaseContext(): base()
        {
        }

        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<ItemStatus> ItemStatus { get; set; }
        public virtual DbSet<LibraryItem>  LibraryItem { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        //public virtual DbSet<LibraryItemType> LibraryItemTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            

            builder.Entity<Author>().ToTable("Author");
            builder.Entity<Author>().HasKey(a => a.Id);
            builder.Entity<Author>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Author>().Property(a => a.LastName).IsRequired();

            builder.Entity<LibraryItem>().ToTable("LibraryItem");
            builder.Entity<LibraryItem>().HasKey(l => l.Id);
            builder.Entity<LibraryItem>().Property(l => l.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<LibraryItem>().Property(l => l.Id).IsRequired();
            builder.Entity<LibraryItem>().Property(l => l.Title).IsRequired();
            builder.Entity<LibraryItem>().HasOne(l => l.Author);

            //builder.Entity<LibraryItem>().Property(l => l.ItemType).HasConversion(
            //    e => e.ToString(),
            //    e => (LibraryItemType)Enum.Parse(typeof(LibraryItemType), e));

            //var converter = new EnumToStringConverter<LibraryItemType>();
            //builder.Entity<LibraryItem>().Property(l => l.ItemType).HasConversion(converter);

            base.OnModelCreating(builder);

        }
    }
}
