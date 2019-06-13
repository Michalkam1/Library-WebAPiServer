using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_WebAPiServer.Models;
using Database.Entities;

namespace Library_WebAPiServer.Domain.Services
{
    public interface IAuthorsServices
    {
        Task<IEnumerable<Author>> ListAsync();

        Task<Author> SaveAsync(Author author);
    }
}
