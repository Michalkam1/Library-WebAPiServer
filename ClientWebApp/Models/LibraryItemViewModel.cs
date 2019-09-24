using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace ClientWebApp.Models
{
    //public class LibraryItemViewModel
    //{
        //public enum LibraryItemType { DVD, CD, Book };

        //public class LibraryItem
        //{
        //    public int Id { get; set; }

        //    public virtual Author Author { get; set; }

        //    public LibraryItemType ItemType { get; set; }

        //    public string Cover { get; set; }

        //    public DateTime IssueYear { get; set; }

        //    [Required]
        //    public string Title { get; set; }
        //}

        //public enum LibraryItemType : byte
        //{
        //    [Description("DVD")]
        //    DVD = 1,
        //    [Description("CD")]
        //    CD = 2,
        //    [Description("Book")]
        //    Book = 3
        //};

        public class LibraryItemViewModel
        {
            public int Id { get; set; }
            public Author Author { get; set; }
            //public LibraryItemType ItemType { get; set; }
            public int ItemType { get; set; }
            public string Cover { get; set; }
            public DateTimeOffset IssueYear { get; set; }
            public string Title { get; set; }
        }
    //}
}
