using InlämningOODesign.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningOODesign.Classes
{
    public class Book : IBook
    {
        public Book(
                    string title, 
                    string description, 
                    Author author, 
                    int pageCount, 
                    int chapters, 
                    bool published)
        {
            Id = nextID++;
            Title = title;
            Description = description;
            Author = author;
            PageCount = pageCount;
            Chapters = chapters;
            Published = published;
        }
        public int Id { get; set; }
        public static int nextID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
        public Author Author { get; set; }
        public int PageCount { get; set; } 
        public int Chapters { get; set; } 
        public bool Published { get; set; } 
    }
}
