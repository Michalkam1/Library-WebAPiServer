using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using ClientWebApp.Models;
using AuthDatabase.Entities;

namespace ClientWebApp.Services
{
    public class BlobService: IBlobService
    {
        HttpClient httpClient = new HttpClient();

        public Task<Guid> AddItemsAsync(LibraryItem newItem, AppUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> MarkIsDoneAsync(LibraryItemViewModel item, AppUser user)
        {
            throw new NotImplementedException();
        }
    }
}
