using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library_WebAPiServer.Models;
using Database;
using Database.Entities;
using Library_WebAPiServer.Domain.Services;
using AutoMapper;

namespace Library_WebAPiServer.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AuthorController : Controller //Base
    {
        DatabaseContext _dbContext;
        private readonly IAuthorsServices _authorsService;
        private readonly IMapper _mapper;


        public AuthorController(DatabaseContext dbContext, IAuthorsServices authorsServicecs, IMapper mapper)
        {
            _dbContext = dbContext;
            _authorsService = authorsServicecs;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<AuthorDTO>> GetAllAsync()
        {
            var author = await _authorsService.ListAsync();
            var authorsReusorces = _mapper.Map<IEnumerable<Author>, IEnumerable<AuthorDTO>>(author);
            //var auth = authorsReusorces.Select(a => a.Id).Distinct();
            return authorsReusorces;
            
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(AuthorDTO authorDTO)
        {
            var authorIncomming = _mapper.Map<AuthorDTO, Author>(authorDTO);
            var result = await _authorsService.SaveAsync(authorIncomming);

            var authorsReusorces = _mapper.Map<Author, AuthorDTO>(result);

            return Ok(authorsReusorces);
        }

    }
}