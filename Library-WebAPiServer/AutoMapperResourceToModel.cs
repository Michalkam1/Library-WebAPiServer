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
    public class AutoMapperResourceToModel : Profile
    {
        public AutoMapperResourceToModel()
        {
            CreateMap<AuthorDTO, Author>();
            CreateMap<LibraryItemDTO, LibraryItem>()
                ;//.ForMember(src => src.ItemType,
                //            opt => opt.MapFrom(src => (Database.Entities.LibraryItemType)src.ItemType));
            CreateMap<ItemStatusDTO, ItemStatus>();
            CreateMap<StatusDTO, Status>();
        }
    }
}
