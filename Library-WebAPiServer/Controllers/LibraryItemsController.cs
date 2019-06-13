using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Database;
using Database.Entities;
using Library_WebAPiServer.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using AutoMapper.Configuration;


namespace Library_WebAPiServer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryItemsController : Controller //Base
    {
        private DatabaseContext _dbContext;
        private readonly IMapper _mapper;




        public LibraryItemsController(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        //GET all
        [HttpGet]
        public ActionResult<IEnumerable<LibraryItemDTO>> GetAll()
        {
            var libraryItems = _dbContext.LibraryItem
                .Select(li => li.Title )
                //.Include(li => li.)
                .ProjectTo<LibraryItemDTO>()
                .ToList();
            return libraryItems;

            //IQueryable<LibraryItemDTO> libItems = _dbContext.LibraryItem
            //    .Select(item => new LibraryItemDTO()
            //    {

            //        Id = item.Id,
            //        //Author = Mapper.Map(LibraryItemDTO, LibraryItem), //item.Author. , //item.Author.LastName + " " + item.Author.FirstName
            //        Cover = item.Cover,
            //        //ItemType = item.ItemType, //LibraryItemType
            //        IssueYear = item.IssueYear,
            //        Title = item.Title
            //    });
            //return libItems.ToList();


        }
        //GET
        [HttpGet("{Id}")]
        public ActionResult<IEnumerable<LibraryItemDTO>> Get(int ItemId)
        {
            IQueryable<LibraryItemDTO> libItems = _dbContext.LibraryItem.Where(item => item.Id == ItemId).Select(item => new LibraryItemDTO()
            {
                Id = item.Id,
                Title = item.Title,
                Author = Mapper.Map<AuthorDTO>(item),
                Cover = item.Cover
            });
            return libItems.ToList();

        }

        //[HttpPost]
        //public 

        //[HttpPost]
        //public ActionResult<LibraryItemDTO> Post(LibraryItemDTO libItemDTO)
        //{
        //    LibraryItemDTO libItem = libItemDTO;

        //    var cfg = new MapperConfigurationExpression();
        //    //cfg.CreateMap<Author, AuthorDTO>();
        //    cfg.CreateMap<LibraryItem, LibraryItemDTO>();
        //    //cfg.AddProfile<MyProfile>();
        //    //libItem.InitAutoMapper(cfg);

        //    //Mapper.Initialize(cfg);
        //    // or
        //    var mapperConfig = new MapperConfiguration(cfg);
        //    IMapper mapper = new Mapper(mapperConfig);


        //    //var dto = _dbContext.LibraryItem
        //    //            //.Where(l => l.Id == libItemDTO)
        //    //            .ProjectTo<LibraryItemDTO>(mapper)
        //    //            .Select(libItem);
        //    //            //.SingleOrDefault();


        //    _dbContext.LibraryItem.ProjectTo<LibraryItemDTO>(libItem).Add(new LibraryItem()
        //     {
        //           //Author = (Author)Mapper.Map<AuthorDTO>(libItemDTO),

        //           // Author = mapper.,
        //         Title = libItemDTO.Title,
        //         Cover = libItemDTO.Cover
        //     });

        //    _dbContext.SaveChanges();
        //    return libItem;
        //} 
    }
    /*
    public class SimpleMapper<TFrom, TTo>
    {
        

        public static TTo Map(TFrom fromModel)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<TFrom, TTo>();
                //cfg.AddProfile<fromToProf>();
                cfg.AddMaps("FromTo");
            });

            var mapper = new Mapper(config);
            Mapper.CreateMap<TFrom, TTo>();
            return Mapper.Map<TFrom, TTo>(fromModel);
        }

        public static IList<TTo> MapList(IList<TFrom> fromModel)
        {
            Mapper.CreateMap<TFrom, TTo>();
            return Mapper.Map<IList<TFrom>, IList<TTo>>(fromModel);
        }
    }

    public class RepositoryBase<TModel, TLINQModel>
    {
        public IList<TModel> Map<TCustom>(IList<TCustom> model)
        {
            return SimpleMapper<TCustom, TModel>.MapList(model);
        }

        public TModel Map(TLINQModel model)
        {
            return SimpleMapper<TLINQModel, TModel>.Map(model);
        }

        public TLINQModel Map(TModel model)
        {
            return SimpleMapper<TModel, TLINQModel>.Map(model);
        }

        public IList<TModel> Map(IList<TLINQModel> model)
        {
            return SimpleMapper<TLINQModel, TModel>.MapList(model);
        }

        public IList<TLINQModel> Map(IList<TModel> model)
        {
            return SimpleMapper<TModel, TLINQModel>.MapList(model);
        }
    }
    */
}