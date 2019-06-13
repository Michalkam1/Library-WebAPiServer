using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_WebAPiServer.Domain.Persistance;
using Library_WebAPiServer.Models;
using Database.Entities;

namespace Library_WebAPiServer.Domain.Services
{
    public class AuthorsServices : IAuthorsServices //BaseRepository,
    {
        private readonly IAuthorsRepository _authorsRepository;

        public AuthorsServices(IAuthorsRepository authorsRepository)
        {
            this._authorsRepository = authorsRepository;
        }

        public async Task<IEnumerable<Author>> ListAsync()
        {
            return await _authorsRepository.ListAsync();
        }
    }
}
