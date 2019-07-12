using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientWebApp.Client;
using ClientWebApp.Models;
using System.Net.Http;
using AutoMapper;

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

        public async Task<LibraryItemViewModel[]> GetAll()
        {
            LibraryItemsClient libraryServiceClient = new LibraryItemsClient(httpClient);

            ICollection<LibraryItemDTO> libraryItems = await libraryServiceClient.GetAllAsync();

            ICollection<LibraryItemViewModel> returnLibItems = _mapper.Map<ICollection<LibraryItemDTO>, ICollection<LibraryItemViewModel>>(libraryItems);

            return returnLibItems.ToArray();
        }

        public Task<int> AddLibraryItem(LibraryItemViewModel newItem)
        {
            throw new NotImplementedException();
        }

        //    public async Task<int> AddLibraryItem(LibraryItemViewModel newItem)
        //    {
        //        LibraryItemsClient libraryServiceClient = new LibraryItemsClient(httpClient);

        //        LibraryItemDTO returnValue = await libraryServiceClient.PostItemsAsync(_mapper.Map<LibraryItemDTO>(newItem));



        //        //ICollection<LibraryItemDTO> libraryItems = await libraryServiceClient.GetAllAsync();

        //        //ICollection<LibraryItemViewModel> returnLibItems = _mapper.Map<ICollection<LibraryItemDTO>, ICollection<LibraryItemViewModel>>(libraryItems);

        //        return returnValue;
        //    }
        //}
    }
}
