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
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;



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

        ////GET
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

        [HttpPost]
        public async Task<IActionResult> PostItems([FromBody]LibraryItemDTO libItem)
        //public async Task<IActionResult> PostItems(Json libItem)
        //public async Task<IActionResult> PostItems([FromBody] string JSONlibItem)
        {
            //LibraryItemDTO libItem = JsonConvert.DeserializeObject<string>(JSONlibItem);

            //LibraryItemDTO libItem = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<LibraryItemDTO>(JSONlibItem);

            var itemIncomming = _mapper.Map<LibraryItemDTO, LibraryItem>(libItem);
            var resource = await _libItemService.SaveAsync(itemIncomming);

            var itemsReusorces = _mapper.Map<LibraryItem, LibraryItemDTO>(resource);

            return Ok(itemsReusorces);

        }

    }
}