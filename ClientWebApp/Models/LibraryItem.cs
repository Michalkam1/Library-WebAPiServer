using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.ComponentModel;

namespace ClientWebApp.Models
{
    //public enum LibraryItemType : byte
    //{
    //    [Description("DVD")]
    //    DVD = 1,
    //    [Description("CD")]
    //    CD = 2,
    //    [Description("Book")]
    //    Book = 3
    //};

    public class LibraryItem
    {
        public int Id { get; set; }
        public Author Author { get; set; }
        //public int Author { get; set; }
        public LibraryItemType ItemType { get; set; }
        public string Cover { get; set; }
        public DateTime IssueYear { get; set; }
        public string Title { get; set; }


    }

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
}
