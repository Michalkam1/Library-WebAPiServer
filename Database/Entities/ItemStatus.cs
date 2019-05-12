using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database.Entities
{
    public class ItemStatus
    {
        public int Id { get; set; }
        public virtual LibraryItem LibraryItems { get; set; }
        [Required]
        public virtual Status Statuses { get; set; }
        [Required]
        public DateTime DateOrder   { get; set; }
        public DateTime DateTake    { get; set; }
        [Required]
        public DateTime DateTermin  { get; set; }
        public DateTime DateReturn { get; set; }
        public int OwnerId { get; set; }

    }
}
