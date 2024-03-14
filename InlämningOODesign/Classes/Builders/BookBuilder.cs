using InlämningOODesign.DatabaseWannabe;
using InlämningOODesign.Factories;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningOODesign.Classes.Builders
{
    //Builder skapar funktioner man kan använda beroende på vilka vörden man vill ge objektet
    public class BookBuilder
    {
        AuthorFactory authorFactory = new AuthorFactory();
        //har samma variabler som book klassen men här får varje variabal ett standardvärde.
        public int BookID { get; set; } = 0;
        public string Title { get; set; } = "";
        public Author Author { get; set; } = new Author(string.Empty);
        public string Description { get; set; } = "";
        public int PageCount { get; set; } = 0;
        public int Chapters { get; set; } = 0;
        public bool Published { get; set; } = false;

        public BookBuilder SetTitle(string title)
        {
            Title = title;
            return this;
        }
        public BookBuilder SetDescription(string description)
        {
            Description = description;
            return this;
        }
        public BookBuilder SetAuthor(Author author)
        {
            Author = author; 
            return this;
        }
        public BookBuilder SetPageCount(int pageCount)
        {
            PageCount = pageCount;
            return this;
        }
        public BookBuilder SetChapters(int chapters)
        {
            Chapters = chapters;
            return this;
        }
        public BookBuilder SetPublished(bool published)
        {
            Published = published;
            return this;
        }

        //bygger boken och ger tbx en Book när det väl ska användas.
        public Book Build()
        {
            return new Book(Title, Description, Author, PageCount, Chapters, Published);
        }
    }
}
