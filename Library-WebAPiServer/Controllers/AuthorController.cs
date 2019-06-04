using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library_WebAPiServer.Models;
using Database;

namespace Library_WebAPiServer.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        DatabaseContext _dbContext;

        public AuthorController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public void Post( AuthorDTO author)
        {
            _dbContext.Authors.Add(new Database.Entities.Author()
            {

            });
            _dbContext.SaveChanges();
        }

    }
}