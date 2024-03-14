using InlämningOODesign.Classes;
using InlämningOODesign.Classes.Builders;
using InlämningOODesign.DatabaseWannabe;
using InlämningOODesign.Factories;
using InlämningOODesign.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningOODesign.Commands.AddBook
{
    public class AddBook : ICommand
    {
        WannabeDatabse Db = WannabeDatabse.Instance;
        
        Book Book;

        //måste på någotsätt använda builderpattern här,
        public void Command()
        {
            Logic();
            Console.WriteLine($"\n{Book.Title} have been added.");
        }

        //Lägger till en bok i listan och skapar boken med builder pattern.
        public void Logic()
        {
            string title = string.Empty;
            string authorName = string.Empty;
            string description = string.Empty;
            int chapters = 0;
            int pageCount = 0;
            bool published = false;

            Console.WriteLine($"Create your book:");
            Console.WriteLine("Enter the title of your book:");
            title = Console.ReadLine();

            Console.WriteLine("Enter the author of your book:");
            authorName = Console.ReadLine();
            Author author = Db.authorFactory.GetAuthor(authorName);

            Console.WriteLine("Enter the description of your book:");
            description = Console.ReadLine();

            Console.WriteLine("Enter the number of chapters in your book:");
            int.TryParse(Console.ReadLine(), out chapters);

            Console.WriteLine("Enter the page count of your book:");
            int.TryParse(Console.ReadLine(), out pageCount);

            Console.WriteLine("Is your book published? (yes/no):");
            string isPublishedInput = Console.ReadLine().ToLower();

            if (isPublishedInput == "yes")
            {
                published = false;
            }
            published = isPublishedInput == "yes";

            BookBuilder builder = new BookBuilder();

            Book = builder.SetTitle(title)
                               .SetAuthor(author)
                               .SetDescription(description)
                               .SetChapters(chapters)
                               .SetPageCount(pageCount)
                               .SetPublished(published)
                               .Build();


            Db.books.Add(Book.Id, Book);
        }
    }
}
