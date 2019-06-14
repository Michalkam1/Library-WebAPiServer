using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library_WebAPiServer.Models;
using Database.Entities;
using Library_WebAPiServer.Models.Extensions;

namespace AutoMapper.Mappings
{
    public class AutoMapperModelToResource : Profile
    {
        public AutoMapperModelToResource()
        {
            CreateMap<Author, AuthorDTO>();
            CreateMap<LibraryItem, LibraryItemDTO>()
                .ForMember(src => src.ItemType,
                            opt => opt.MapFrom(src => src.ItemType.ToDescriptionString()));
            CreateMap<ItemStatus, ItemStatusDTO>();
            CreateMap<Status, StatusDTO>();
        }
    }
}
