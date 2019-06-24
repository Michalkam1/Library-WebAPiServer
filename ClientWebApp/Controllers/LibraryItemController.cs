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
    //[Route("api/[controller]")]
    //[ApiController]
    public class LibraryItemController : Controller//Base
    {
        private readonly ILibraryItemService _libraryItemService;

        //private readonly IMapper _mapper;


        public LibraryItemController(ILibraryItemService libraryItemService//, IMapper mapper
            )
        {
            _libraryItemService = libraryItemService;
            //_mapper = mapper;
        }

        public async Task <IActionResult> Index()
        {
            //LibraryItemViewModel libraryItemsList = await _libraryItemService.GetAll();

            //ICollection<LibraryItem> returnLibItems
            //    = _mapper.Map<ICollection<LibraryItem>>(libraryItems);
            //LibraryItem libraryItemsList = await _libraryItemService.GetAll();

            //LibraryItemViewModel[] libraryItemsList = _mapper.Map<LibraryItem>(await _libraryItemService.GetAll()).;

            LibraryItemViewModel[] libraryItemsList = await _libraryItemService.GetAll();

            var model = new LibraryViewModel()
            {
                Items = libraryItemsList
                //Id = libraryItemsList.Id,
                //Author = libraryItemsList.Author,
                //Cover = libraryItemsList.Cover,
                //IssueYear = libraryItemsList.IssueYear,
                //ItemType = libraryItemsList.ItemType,
                //Title = libraryItemsList.Title
            };
            
            return View(model);
        }
    }
}