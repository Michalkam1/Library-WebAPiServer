using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_WebAPiServer.Models;
using Database.Entities;

namespace Library_WebAPiServer.Domain.Services
{
    public interface IAuthorsRepository
    {
        Task<IEnumerable<Author>> ListAsync();
        Task AddAsync(Author author);
        Task<Author> FindByIdAsync(int id);
        void Update(Author author);
        void Remove(Author author);
    }
}
