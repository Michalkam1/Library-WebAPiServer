using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClientWebApp.Client;
using ClientWebApp.Models;

namespace ClientWebApp
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<LibraryItemViewModel, LibraryItemDTO>().ReverseMap();
        }
    }
}
