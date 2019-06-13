using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library_WebAPiServer.Models;
using Database.Entities;

namespace AutoMapper.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Author, AuthorDTO>();
            CreateMap<LibraryItem, LibraryItemDTO>();
            CreateMap<ItemStatus, ItemStatusDTO>();
            CreateMap<Status, StatusDTO>();
        }
    }
}
