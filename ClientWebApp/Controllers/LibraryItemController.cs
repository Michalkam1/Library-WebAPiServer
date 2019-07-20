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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClientWebApp.Controllers
{
    public class LibraryItemController : Controller
    {
        private readonly ILibraryItemService _libraryItemService;
        private readonly UserManager<AppUser> _userManager;


        public LibraryItemController(ILibraryItemService libraryItemService, UserManager<AppUser> userManager)
        {
            _libraryItemService = libraryItemService;
            _userManager = userManager;

        }


        //[HttpPost]
        //public string LibraryItemsList(string searchString, bool notUsed)
        //{
        //    return "From [HttpPost]Index: filter on " + searchString;
        //}

        public async Task<IActionResult> LibraryItemsList(string searchTitle, string searchAuthorFirstName, string searchAuthorLastName, string searchItemType)
        {
            LibraryItemViewModel[] libraryItemsList = await _libraryItemService.GetAll();

            var items = from m in libraryItemsList
                        select m;

            if (!String.IsNullOrEmpty(searchTitle))
            {
                items = items.Where(s => s.Title.ToLower().Contains(searchTitle.ToLower()));
            }

            if (!String.IsNullOrEmpty(searchAuthorFirstName))
            {
                items = items.Where(s => s.Author.FirstName.ToLower().Contains(searchAuthorFirstName.ToLower()));
            }

            if (!String.IsNullOrEmpty(searchAuthorLastName))
            {
                items = items.Where(s => s.Author.LastName.ToLower().Contains(searchAuthorLastName.ToLower()));
            }

           

            var model = new LibraryViewModel()
            {
                Items = items.ToArray()
                //Items = libraryItemsList
            };

            return View(model);
        }

        

        //public ViewResult EnterData()//(UserManager<AppUser> userManager)
        public async Task<IActionResult> EnterData()
        {
            LibraryItemViewModel[] libraryItemsList = await _libraryItemService.GetAll();
            var model = new LibraryItemViewModel();
            List<Author> list = new List<Author>();
            //IEnumerable<SelectListItem>;
            foreach (var a in libraryItemsList) 
            {
                if (!list.Contains(a.Author))
                {
                    list.Add(a.Author);
                }
            }
            // = libraryItemsList
            ViewBag.AuthorsViewBag = list;
            return View(model);
        }



        //public async Task<IActionResult> SaveLibraryItem(LibraryItemViewModel newItem)
        //{
        //    int successfullTran = await _libraryItemService.AddLibraryItem(newItem);
        //    if (successfullTran > 0)
        //    {
        //        return BadRequest("Could not add item.");
        //    }

        //    return RedirectToAction("LibraryItemsList");

        //}

        public async Task<IActionResult> SaveLibraryItem(LibraryItemViewModel newItem)
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