using InlämningOODesign.Classes;
using InlämningOODesign.DatabaseWannabe;
using InlämningOODesign.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningOODesign.Commands
{
    public class ViewBooks : ICommand
    {
        WannabeDatabse db = WannabeDatabse.Instance;
        public void Command()
        {
            Logic();
        }

        public void Logic()
        {
            db.BookProxy();
            foreach(BookProxy books in db.Proxies)
            {
                Console.WriteLine($"{books.Id}, {books.Title}, {books.Author.Name}\n");
            }

            Console.WriteLine("Enter the ID of the book you want to view:");
            int inputId = Convert.ToInt32(Console.ReadLine());
            foreach (BookProxy book in db.Proxies)
            {
                if (book.Id == inputId)
                {
                    if (book.Published == true || book.Published == false)
                    {
                        Console.Clear();
                        string published = book.Published ? "yes" : "no";
                        Console.WriteLine($"ID: {book.Id}\nTitle: {book.Title}\nDescription: {book.Description}\nAuthor: {book.Author.Name}\nChapters: {book.Chapters}\nPublished: {published}");
                    }
                }
            }
        }
    }
}
