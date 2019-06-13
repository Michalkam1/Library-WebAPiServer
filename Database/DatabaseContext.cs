using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Database
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        //public DatabaseContext()
        //{
        //}
        public DatabaseContext(): base()//: base("Library")
        {
            
        }

        //protected override void Seed(DatabaseContext databaseContext)
        //{

        //}

    //    protected override void Seed(DatabaseContext dbContext)
    //    {
    //        base.Seed(dbContext);
    //        db.Set<Workout>().Add(new Workout { Id = 1, Name = "My First workout user1" })

        //}

        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<ItemStatus> ItemStatus { get; set; }
        public virtual DbSet<LibraryItem>  LibraryItem { get; set; }
        public virtual DbSet<Status> Status { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<LibraryItem>()
                    .Property(e => e.ItemType)
                    //.HasOne(e => e.Author)
                    
                    .HasConversion(
                        v => v.ToString(),
                        v => (LibraryItemType)Enum.Parse(typeof(LibraryItemType), v));
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
