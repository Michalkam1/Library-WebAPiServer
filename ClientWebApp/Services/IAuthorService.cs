using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientWebApp.Client;
using ClientWebApp.Models;

namespace ClientWebApp.Services
{
    public interface IAuthorService
    {
        Task<Author[]> GetAuthors();
        Task<FileResponse> AddAuthor(Author newAuthor);
        //Task<int> AddAuthor(Author author);
    }
}
