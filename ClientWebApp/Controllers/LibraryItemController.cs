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
using AuthDatabase.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ClientWebApp.Controllers
{
    public class LibraryItemController : Controller
    {
        private readonly ILibraryItemService _libraryItemService;
        //private readonly UserManager<AppUser> _userManager;


        public LibraryItemController(ILibraryItemService libraryItemService
            //, UserManager<AppUser> userManager
            )
        {
            _libraryItemService = libraryItemService;
            //_userManager = userManager;

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

        public async Task<IActionResult> AddLibraryItem(LibraryItemViewModel newItem)
        {
            int successfullTran = await _libraryItemService.AddLibraryItem(newItem);
            if (successfullTran > 0)
            {
                return BadRequest("Could not add item.");
            }

            return RedirectToAction("LibraryItemsList");

        }
    }
}