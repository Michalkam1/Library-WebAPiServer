using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthDatabase.Entities;
using ClientWebApp.Models;
using ClientWebApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClientWebApp.Controllers
{
    public class AuthorItemController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly UserManager<AppUser> _userManager;

        public AuthorItemController(IAuthorService authorService, UserManager<AppUser> userManager)
        {
            _authorService = authorService;
            _userManager = userManager;
        }

        public IActionResult EnterAuthor()
        {
            var model = new Author();
            return View(model);
        }

        public async Task<IActionResult> SaveAuthor(Author newAuthor)
        {

            //int successfullTran = await _libraryItemService.AddLibraryItem(newItem);
            var successfullTran = await _authorService.AddAuthor(newAuthor);
            //if (successfullTran > 0)
            //{
            //    return BadRequest("Could not add item.");
            //}

            return RedirectToAction("EnterData", "LibraryItem");
        }
    }
}