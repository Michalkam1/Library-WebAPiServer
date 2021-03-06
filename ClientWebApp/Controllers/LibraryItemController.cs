﻿using System;
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
        private readonly IAuthorService _authorService;
        private readonly UserManager<AppUser> _userManager;


        public LibraryItemController(ILibraryItemService libraryItemService, IAuthorService authorService, UserManager<AppUser> userManager)
        {
            _libraryItemService = libraryItemService;
            _authorService = authorService;
            _userManager = userManager;
        }


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
            };

            return View(model);
        }

        public async Task<IActionResult> EnterData()
        {
            LibraryItemViewModel[] libraryItemsList = await _libraryItemService.GetAll();
            var model = new LibraryItemViewModel();
            Author[] listaAutorow = await _authorService.GetAuthors(); 

            var authors = listaAutorow.Select(a => new SelectListItem
            {
                Text = a.LastName.ToString() + ' ' + a.FirstName.ToString(),
                Value = a.Id.ToString()
            });

            ViewBag.AuthorsViewBag = new SelectList(authors, "Value", "Text");
            return View(model);
        }
        private int _Id;
        public async Task<IActionResult> GetOneItem(int id)
        {
            _Id = id;
            LibraryItemViewModel libraryItemsList = await _libraryItemService.GetOne(_Id);

            return View(libraryItemsList);
        }



        [HttpPost]
        public async Task<IActionResult> SaveLibraryItem(LibraryItemViewModel newItem)
        {
            ClientWebApp.Client.FileResponse successfullTran;
            if (ModelState.IsValid)
            {
                successfullTran = await _libraryItemService.AddLibraryItem(newItem);
                return RedirectToAction("LibraryItemsList");
            }
            else
            {
                return BadRequest("Nie można dodać elementu, wszystkie pola muszą być uzupełnione.");
            }
        }
    }
}