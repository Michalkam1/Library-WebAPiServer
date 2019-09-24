using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientWebApp.Client;
using ClientWebApp.Models;
using System.Net.Http;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ClientWebApp.Services
{
    public class LibraryItemService : ILibraryItemService
    {
        string url = "https://localhost:44399";
        HttpClient httpClient = new HttpClient();

        private readonly IMapper _mapper;

        public LibraryItemService(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<LibraryItemViewModel[]> GetAll()
        {
            LibraryItemsClient libraryServiceClient = new LibraryItemsClient(httpClient);

            ICollection<LibraryItemDTO> libraryItems = await libraryServiceClient.GetAllAsync();

            ICollection<LibraryItemViewModel> returnLibItems = _mapper.Map<ICollection<LibraryItemDTO>, ICollection<LibraryItemViewModel>>(libraryItems);

            return returnLibItems.ToArray();
        }

        [HttpGet]
        public async Task<LibraryItemViewModel> GetOne(int id)
        {
            LibraryItemsClient libraryServiceClient = new LibraryItemsClient(httpClient);

            LibraryItemDTO libraryItem = await libraryServiceClient.GetOneAsync(id);

            LibraryItemViewModel returnLibItem = _mapper.Map<LibraryItemDTO, LibraryItemViewModel>(libraryItem);

            return returnLibItem;//.ToArray()
        }

        [HttpPost]
        public async Task<FileResponse> AddLibraryItem(LibraryItemViewModel newItem)
        {
            LibraryItemsClient libraryServiceClient = new LibraryItemsClient(httpClient);
            var returnValue = await libraryServiceClient.PostItemsAsync(_mapper.Map<LibraryItemDTO>(newItem));

            return returnValue;
        }
    }
}

