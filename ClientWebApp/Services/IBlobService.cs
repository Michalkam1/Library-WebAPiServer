using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientWebApp.Models;
using AuthDatabase.Entities;

namespace ClientWebApp.Services
{
    public interface IBlobService
    {
        Task<Guid> AddItemsAsync(LibraryItem newItem, AppUser user);
        Task<bool> MarkIsDoneAsync(LibraryItemViewModel item, AppUser user);
    }
}
