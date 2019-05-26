using System;
using Database;
using AuthDatabase;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Library;");
            using (DatabaseContext databaseContext = new DatabaseContext(builder.Options))
            {
                var authorName = databaseContext.Authors.First().FirstName;
                var status = databaseContext.Statuses.First().;


                foreach (var item in databaseContext.ItemStatuses)
                {
                    
                    Console.WriteLine(item.Id);
                }

            }

            Console.WriteLine("Hello World");
        }
    }
}
