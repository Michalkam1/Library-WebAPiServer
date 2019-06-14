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

        public async Task AddAsync(LibraryItem libItem)
        {
            await _context.AddAsync(libItem);
        }

        public async Task<IEnumerable<LibraryItem>> ListAsync()
        {
            return await _context.LibraryItem.Include(a => a.Author)
                                             .ToListAsync();
        }
    }
}

