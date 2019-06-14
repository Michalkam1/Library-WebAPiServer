using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Database;
using Database.Entities;
using Library_WebAPiServer.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using AutoMapper.Configuration;
using Library_WebAPiServer.Domain.Services;


namespace Library_WebAPiServer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryItemsController : Controller //Base
    {
        private DatabaseContext _dbContext;
        private readonly ILibraryItemService _libItemService;
        private readonly IMapper _mapper;

        public LibraryItemsController(DatabaseContext dbContext, IMapper mapper, ILibraryItemService libItem)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _libItemService = libItem;
        }

        //GET all
        [HttpGet]
        public async Task<IEnumerable<LibraryItemDTO>> GetAllAsync()
        {
            var items = await _libItemService.ListAsync();
            var resources = _mapper.Map<IEnumerable<LibraryItem>, IEnumerable<LibraryItemDTO>>(items);
            return resources;
        }




        //public ActionResult<IEnumerable<LibraryItemDTO>> GetAll()
        //{
        //    var libraryItems = _dbContext.LibraryItem
        //        .Select(li => li.Title)
        //        //.Include(li => li.)
        //        .ProjectTo<LibraryItemDTO>()
        //        .ToList();
        //    return libraryItems;
        //}
        //IQueryable<LibraryItemDTO> libItems = _dbContext.LibraryItem
        //    .Select(item => new LibraryItemDTO()
        //    {

        //        Id = item.Id,
        //        //Author = Mapper.Map(LibraryItemDTO, LibraryItem), //item.Author. , //item.Author.LastName + " " + item.Author.FirstName
        //        Cover = item.Cover,
        //        //ItemType = item.ItemType, //LibraryItemType
        //        IssueYear = item.IssueYear,
        //        Title = item.Title
        //    });
        //return libItems.ToList();



        //GET
        [HttpGet("{Id}")]
        public ActionResult<IEnumerable<LibraryItemDTO>> Get(int ItemId)
        {
            IQueryable<LibraryItemDTO> libItems = _dbContext.LibraryItem.Where(item => item.Id == ItemId).Select(item => new LibraryItemDTO()
            {
                Id = item.Id,
                Title = item.Title,
                Author = Mapper.Map<AuthorDTO>(item),
                Cover = item.Cover
            });
            return libItems.ToList();

        }

    }
}