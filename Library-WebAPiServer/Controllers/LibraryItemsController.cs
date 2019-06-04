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

namespace Library_WebAPiServer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryItemsController : ControllerBase
    {
        private DatabaseContext _dbContext;

        public LibraryItemsController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        //GET all
        [HttpGet]
        public ActionResult<IEnumerable<LibraryItemDTO>> GetAll()
        {
            //Mapper.CreateMap<LibraryItemDTO libItmDTO > ();
            //var mapItemAuthor = Mapper.Map<AuthorDTO>(item);
            //var auth = Mapper.Map<Author, AuthorDTO>();

            var libraryEntities = _dbContext.LibraryItems.Select(item => item);

            //var libraryDtoEnts = 
            return libraryEntities.Select(item => new LibraryItemDTO
            {
                Id = item.Id,
                //Author = Mapper.Map(LibraryItemDTO, LibraryItem), //item.Author. , //item.Author.LastName + " " + item.Author.FirstName
                Cover = item.Cover,
                //ItemType = item.ItemType, //LibraryItemType
                IssueYear = item.IssueYear,
                Title = item.Title
            }).ToList();

            //IQueryable<LibraryItemDTO> libItems = _dbContext.LibraryItems.Select(item => new LibraryItemDTO()//.Include(item => item.Author)
            //{

            //    Id = item.Id,
            //    Author = Mapper.Map(LibraryItemDTO, LibraryItem), //item.Author. , //item.Author.LastName + " " + item.Author.FirstName
            //    Cover = item.Cover,
            //    //ItemType = item.ItemType, //LibraryItemType
            //    IssueYear = item.IssueYear,
            //    Title = item.Title
            //});



            //.SingleOrDefaultAsync(item => item.Author.Id == Id);

            //if (libItems.ToList().Count() > 0)
            //{
            //return libraryDtoEnts.ToList();
            //    }
            //    else
            //    {
            //        return null;
            //    }
            //}
        }
        //GET
        [HttpGet("{Id}")]
        public ActionResult<IEnumerable<LibraryItemDTO>> Get(int ItemId)
        {
            IQueryable<LibraryItemDTO> libItems = _dbContext.LibraryItems.Where(item => item.Id == ItemId).Select(item => new LibraryItemDTO()
            {
                Id = item.Id,
                Title = item.Title,
                Author = Mapper.Map<AuthorDTO>(item),
                Cover = item.Cover
            });
            return libItems.ToList();
        }

        [HttpPost]
        public ActionResult<LibraryItemDTO> Post([FromBody] LibraryItemDTO libItemDTO)
        {
            LibraryItemDTO libItem = libItemDTO;
                _dbContext.LibraryItems.Add(new Database.Entities.LibraryItem()
            {
                //Author = Mapper.Map<AuthorDTO>(libItemDTO),
                Title = libItemDTO.Title,
                Cover = libItemDTO.Cover,
            });

            _dbContext.SaveChanges();
            return libItem;
        }
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