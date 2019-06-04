using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_WebAPiServer.Models
{
    public class ItemStatusDTO
    {
        public int Id { get; set; }
        public virtual LibraryItemDTO LibraryItems { get; set; }
        public virtual StatusDTO Statuses { get; set; }
        public DateTime DateOrder   { get; set; }
        public DateTime DateTake    { get; set; }
        public DateTime DateTermin  { get; set; }
        public DateTime DateReturn { get; set; }
        public int OwnerId { get; set; }

    }
}
