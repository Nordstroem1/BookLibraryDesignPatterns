using InlämningOODesign.Classes;
using InlämningOODesign.Factories;
using InlämningOODesign.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningOODesign.SetProperties
{
    public class SetAuthor : IPropertyEditor
    {
        private AuthorFactory authorFactory;

        public void setAuthor(AuthorFactory authorFactory)
        {
            this.authorFactory = authorFactory;
        }
        public void EditProperty(Book book)
        {
            Console.WriteLine("Enter new author.");
            string newAuthor = Console.ReadLine();
            Author author = authorFactory.GetAuthor(newAuthor); 

            Console.WriteLine($"Old author: {book.Author.Name}");
            book.Author.Name = newAuthor;
            Console.WriteLine($"New author:{book.Author.Name}");
        }
    }
}
