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
    public class LibraryItemRepository : BaseRepository, ILibraryItemRepository
    {
        public LibraryItemRepository(DatabaseContext context): base(context) { }

        private readonly IAuthorsRepository _authorsRepository;

        public async Task AddAsync(LibraryItem libItem)
        {
            await _context.LibraryItem.AddAsync(libItem);
        }

        public async Task<LibraryItem> FindByIdAsync(int id)
        {
            return await _context.LibraryItem
                .Include(a => a.Author)
                .FirstOrDefaultAsync(a => a.Author.Id == id);
        }

        public async Task<IEnumerable<LibraryItem>> ListAsync()
        {
            return await _context.LibraryItem.Include(a => a.Author)
                                             .ToListAsync();
        }

        public void Remove(LibraryItem libItem)
        {
            throw new NotImplementedException();
        }

        public void Update(LibraryItem libItem)
        {
            throw new NotImplementedException();
        }
    }
}

