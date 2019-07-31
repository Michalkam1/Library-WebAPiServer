using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database.Entities
{
    //public enum LibraryItemType { 1, 2, 3 };


    //public enum LibraryItemType { DVD, CD, Book };


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

        public virtual Author Author { get; set; }

        //public LibraryItemType ItemType { get; set; }
        public int ItemType { get; set; }

        public string Cover { get; set; }

        public DateTime IssueYear { get; set; }

        [Required]
        public string Title { get; set; }

        
    }
}
