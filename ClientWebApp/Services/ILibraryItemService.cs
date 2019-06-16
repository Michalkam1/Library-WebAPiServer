using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientWebApp.Models;

namespace ClientWebApp.Services
{
    public interface ILibraryItemService
    {
        Task<LibraryItemViewModel[]> GetAll();
    }
}
