using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_WebAPiServer.Models;
using Database.Entities;

namespace Library_WebAPiServer.Domain.Services
{
    public interface ILibraryItemRepository
    {
        Task<IEnumerable<LibraryItem>> ListAsync();
        Task AddAsync(LibraryItem libItem);
        Task<LibraryItem> FindByIdAsync(int id);
        void Update(LibraryItem libItem);
        void Remove(LibraryItem libItem);
    }
}
