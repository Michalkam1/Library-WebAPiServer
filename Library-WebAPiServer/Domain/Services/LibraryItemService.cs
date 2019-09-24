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
    public class LibraryItemService : ILibraryItemService
    {
        private readonly ILibraryItemRepository _libItemsRepository;
        private readonly IAuthorsRepository _authorsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public LibraryItemService(ILibraryItemRepository libItemsRepository, IAuthorsRepository authorsRepository, IUnitOfWork unitOfWork)
        {
            _libItemsRepository = libItemsRepository;
            _authorsRepository = authorsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<LibraryItem>> ListAsync()
        {
            return await _libItemsRepository.ListAsync();
        }

        public async Task<LibraryItem> ListOneAsync(int id)
        {
            return await _libItemsRepository.FindByIdAsync(id);
        }

        public async Task<LibraryItem> SaveAsync(LibraryItem libItem)
        {
                var existingAuthor = await _authorsRepository.FindByIdAsync(libItem.Author.Id);

                await _libItemsRepository.AddAsync(libItem);
                await _unitOfWork.CompleteAsync();

                return libItem;            
        }
    }
}
