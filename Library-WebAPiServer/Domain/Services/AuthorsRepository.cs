using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Database.Entities;
using Library_WebAPiServer.Domain.Persistance;
using Library_WebAPiServer.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_WebAPiServer.Domain.Services
{
    public class AuthorsRepository : BaseRepository, IAuthorsRepository
    {
        public AuthorsRepository(DatabaseContext context): base(context) { }

        public async Task AddAsync(Author author)
        {
            await _context.AddAsync(author);
        }

        public async Task<Author> FindByIdAsync(int id)
        {
            return await _context.Author.FindAsync(id);
        }

        public async Task<IEnumerable<Author>> ListAsync()
        {
            return await _context.Author.ToListAsync();
        }

        public void Remove(Author author)
        {
            throw new NotImplementedException();
        }

        public void Update(Author author)
        {
            throw new NotImplementedException();
        }
    }
}

