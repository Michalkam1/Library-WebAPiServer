using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library_WebAPiServer.Models;
using Database;
using Library_WebAPiServer.Domain.Services;

namespace Library_WebAPiServer.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        DatabaseContext _dbContext;
        private readonly IAuthorsServices _authorsService;

        public AuthorController(DatabaseContext dbContext, IAuthorsServices authorsServicecs)
        {
            _dbContext = dbContext;
            _authorsService = authorsServicecs;
        }


        [HttpGet]
        public ActionResult<IEnumerable<AuthorDTO>> GetAll()
        {
            IQueryable<AuthorDTO> authorDTO = _dbContext.Author.Select(item => new AuthorDTO()//.Include(item => item.Author)
            {
                FirstName = item.FirstName,
                LastName = item.LastName
            });
            return authorDTO.ToList();
        }

        [HttpPost]

        public void Post(AuthorDTO authorDTO)
        {
            AuthorDTO auth = authorDTO;
            _dbContext.Author.Add(new Database.Entities.Author()
            {
                Id = authorDTO.Id,
                FirstName = authorDTO.FirstName,
                LastName = authorDTO.LastName
            });

            _dbContext.SaveChanges();

        }

    }
}