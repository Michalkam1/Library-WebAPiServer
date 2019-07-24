using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ClientWebApp.Models;
using ClientWebApp.Client;
using AutoMapper;

namespace ClientWebApp.Services
{
    public class AuthorService : IAuthorService
    {
        string url = "https://localhost:44399";
        HttpClient httpClient = new HttpClient();

        private readonly IMapper _mapper;

        public AuthorService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<int> AddAuthor(Author author)
        {
            throw new NotImplementedException();
        }

        public async Task<Author[]> GetAuthors()
        {
            AuthorClient authorServiceClient = new AuthorClient(httpClient);
            ICollection<AuthorDTO> authorItems = await authorServiceClient.GetAllAsync();
            ICollection<Author> returnAuthors = _mapper.Map<ICollection<AuthorDTO>, ICollection<Author>>(authorItems);
            return returnAuthors.ToArray();
        }
    }
}
