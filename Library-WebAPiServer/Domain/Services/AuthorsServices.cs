using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_WebAPiServer.Domain.Persistance;
using Library_WebAPiServer.Models;
using Database.Entities;
using Library_WebAPiServer.Domain.Repositories;

namespace Library_WebAPiServer.Domain.Services
{
    public class AuthorsServices : IAuthorsServices //BaseRepository,
    {
        private readonly IAuthorsRepository _authorsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AuthorsServices(IAuthorsRepository authorsRepository, IUnitOfWork unitOfWork)
        {
            _authorsRepository = authorsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Author>> ListAsync()
        {
            return await _authorsRepository.ListAsync();
        }

        public async Task<Author> SaveAsync(Author author)
        {
            try
            {
                await _authorsRepository.AddAsync(author);
                await _unitOfWork.CompleteAsync();

                return author;
            }
            catch(Exception ex)
            {
                throw new NotImplementedException();
            }
            
        }
    }
}
