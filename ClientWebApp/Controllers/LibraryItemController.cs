using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClientWebApp.Client;
using ClientWebApp.Services;
using ClientWebApp.Models;

namespace ClientWebApp.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class LibraryItemController : Controller//Base
    {
        private readonly LibraryItemService _libraryItemService;

        public LibraryItemController(ILibraryItemService libraryItemService)
        {
            _libraryItemService = libraryItemService;
        }

        public async Task <IActionResult> Index()
        {
            LibraryItem[] libraryItemsList = await _libraryItemService.GetAll();

            var model = new LibraryItemViewModel()
            {
                Items =libraryItemsList
            };

            return View(model);
        }
    }
}