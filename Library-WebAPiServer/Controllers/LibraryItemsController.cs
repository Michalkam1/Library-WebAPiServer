﻿using System;
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
using AutoMapper.Mappings;



namespace Library_WebAPiServer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryItemsController : Controller
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

        [HttpGet(Name = "GetAllAsync")]
        public async Task<IEnumerable<LibraryItemDTO>> GetAllAsync()
        {           
            var items = await _libItemService.ListAsync();
            var resources = _mapper.Map<IEnumerable<LibraryItem>, IEnumerable<LibraryItemDTO>>(items);
            return resources;            
        }

        [HttpGet("{id}", Name = "GetOneAsync")]
        public async Task<LibraryItemDTO> GetOneAsync(int id)
        {
            var item = await _libItemService.ListOneAsync(id);
            var resource = _mapper.Map<LibraryItem, LibraryItemDTO>(item);
            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostItems([FromBody]LibraryItemDTO libItem)
        {
            var itemIncomming = _mapper.Map<LibraryItemDTO, LibraryItem>(libItem);
            var resource = await _libItemService.SaveAsync(itemIncomming);

            var itemsReusorces = _mapper.Map<LibraryItem, LibraryItemDTO>(resource);

            return Ok(itemsReusorces);
        }
    }
}