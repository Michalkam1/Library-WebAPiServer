using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database.Entities
{
    public enum LibraryItemType { DVD, CD, Book };

    class LibraryItem
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public LibraryItemType ItemType { get; set; }

        public string Cover { get; set; }

        public DateTime IssueYear { get; set; }

        public int OwnerId { get; set; }



        public bool IsDone { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTimeOffset? DueAt { get; set; }
    }
}
