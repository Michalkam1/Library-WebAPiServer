using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_WebAPiServer.Models;

namespace Library_WebAPiServer.Domain.Services
{
    public class AuthorsServices : BaseRepository,  IAuthorsServices
    {
        private readonly IAuthorsRepository _authorsRepository;

        public AuthorsServices(IAuthorsRepository authorsRepository)
        {
            this._authorsRepository = authorsRepository;
        }

        public async Task<IEnumerable<AuthorDTO>> ListAsync()
        {
            return await _authorsRepository.ListAsync();
        }
    }
}
