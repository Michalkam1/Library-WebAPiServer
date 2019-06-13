using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using System.ComponentModel;

namespace Library_WebAPiServer.Models
{
    public enum LibraryItemType: byte
    {
        [Description("DVD")]
        DVD = 1,
        [Description("CD")]
        CD = 2,
        [Description("Book")]
        Book = 3
    };

    public class LibraryItemDTO
    {
        public int Id { get; set; }
        public virtual AuthorDTO Author { get; set; }
        public LibraryItemType ItemType { get; set; }
        public string Cover { get; set; }
        public DateTime IssueYear { get; set; }
        public string Title { get; set; }


    }
}
