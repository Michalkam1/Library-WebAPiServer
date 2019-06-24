using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClientWebApp.Client;
using ClientWebApp.Services;
using ClientWebApp.Models;
using AutoMapper;

namespace ClientWebApp.Controllers
{
    public class LibraryItemController : Controller
    {
        private readonly ILibraryItemService _libraryItemService;

        public LibraryItemController(ILibraryItemService libraryItemService)
        {
            _libraryItemService = libraryItemService;
        }

        public async Task <IActionResult> LibraryItemsList()
        {
            LibraryItemViewModel[] libraryItemsList = await _libraryItemService.GetAll();

            var model = new LibraryViewModel()
            {
                Items = libraryItemsList
            };
            
            return View(model);
        }
    }
}