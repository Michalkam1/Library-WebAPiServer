using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientWebApp.Client;
using ClientWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClientWebApp.Services
{
    public interface ILibraryItemService
    {
        Task<LibraryItemViewModel[]> GetAll();
        Task<FileResponse> AddLibraryItem(LibraryItemViewModel newItem);
    }
}
