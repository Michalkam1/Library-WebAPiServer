using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;

namespace Library_WebAPiServer.Domain.Persistance
{
    public abstract class BaseRepository
    {
        protected readonly DatabaseContext _context;

        public BaseRepository(DatabaseContext context)
        {
            _context = context;
        }
    }
}
