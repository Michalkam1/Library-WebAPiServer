﻿using System;
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
                var authorName = databaseContext.Author.First().FirstName;
                var status = databaseContext.Status.First();


                foreach (var item in databaseContext.ItemStatus)
                {
                    
                    Console.WriteLine(item.Id);
                }

            }

            Console.WriteLine("Hello World");
        }
    }
}
