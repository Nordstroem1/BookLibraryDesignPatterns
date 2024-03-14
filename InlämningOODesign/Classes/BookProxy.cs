using InlämningOODesign.DatabaseWannabe;
using InlämningOODesign.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningOODesign.Classes
{
    public class BookProxy : IBook
    {
        WannabeDatabse db = WannabeDatabse.Instance;
        Book book = null;
        public string Title { get; set; }
        public Author Author {  get; set; }
        public int Id {  get; set; }
        public string Description
        {
            get
            {
                Load();
                return book.Description;
            }
            set
            {
                Load();
                book.Description = value;
            }
        }
        public int PageCount 
        {
            get
            {
                Load();
                return book.PageCount;
            }
            set
            {
                Load();
                book.PageCount = value;
            }
        }
        public int Chapters 
        {
            get
            {
                Load();
                return book.Chapters;
            }
            set
            {
                Load();
                book.Chapters= value;
            }
        
        }
        public bool Published 
        {
            get
            {
                Load();
                return book.Published;
            }
            set
            {
                Load();
                book.Published = value;
            }
        }
        public BookProxy(int id, string title, Author author)
        {
            Id = id;
            Title = title;
            Author = author;
        }

        public Book Load()
        {
            if(book == null)
            {
                book = db.GetBook(Id);
                return book;
            }
            return null;
        }
    }
}
