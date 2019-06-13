using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library_WebAPiServer.Models;
using Database.Entities;

namespace AutoMapper.Mappings
{
    public class AutoMapperResourceToModel : Profile
    {
        public AutoMapperResourceToModel()
        {
            CreateMap<AuthorDTO, Author>();
            CreateMap<LibraryItemDTO, LibraryItem>();
            CreateMap<ItemStatusDTO, ItemStatus>();
            CreateMap<StatusDTO, Status>();
        }
    }
}
