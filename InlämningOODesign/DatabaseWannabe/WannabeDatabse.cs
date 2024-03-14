using InlämningOODesign.BookManager;
using InlämningOODesign.Classes;
using InlämningOODesign.Classes.Builders;
using InlämningOODesign.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningOODesign.DatabaseWannabe
{
    public class WannabeDatabse
    {
        public Dictionary<int, Book> books = new Dictionary<int, Book>();
        public List<BookProxy>Proxies = new List<BookProxy>();
        public AuthorFactory authorFactory = new AuthorFactory();

        //singelton, tar bort risken att "databasen" blir duplicerad dvs. ger fel data.
        public static WannabeDatabse Instance = new WannabeDatabse();

        private WannabeDatabse()
        {

            BookBuilder builtBook1 =  new BookBuilder();
            BookBuilder builtBook2 =  new BookBuilder();
            BookBuilder builtBook3 =  new BookBuilder();

            //Här, när boken skapas så används authorFactory för att se om den skapade författaren redan existerar.
            //existerar den? Då retuneras just den författaren
            Book book1 = builtBook1.SetTitle("Lord of the rings")
                                 .SetDescription("Hobbits destroying the ring")
                                 .SetAuthor(authorFactory.GetAuthor("John Jones"))
                                 .SetPageCount(2493)
                                 .SetChapters(4)
                                 .SetPublished(true)
                                 .Build();

            Book book2 = builtBook2.SetTitle("Harry Potter")
                                .SetDescription("Wizzards")
                                .SetPageCount(234)
                                .SetAuthor(authorFactory.GetAuthor("Seth Rogan"))
                                .SetChapters(2)
                                .SetPublished(false)
                                .Build();

            Book book3 = builtBook3.SetTitle("The good habbits")
                                .SetDescription("Book about life")
                                .SetChapters(7)
                                .SetPublished(true)
                                .SetPageCount(500)
                                .Build();

            books.Add(book1.Id, book1);
            books.Add(book2.Id, book2);
            books.Add(book3.Id, book3);
            
        }
        public Book GetBook(int id)
        {
            if (books.ContainsKey(id))
            {
                return books[id];
            }
            return null;
        }
        //här skapas det proxies som är till för att visa en liten del av objekten
        //dvs detta undviker att belasta programmet om man har väldigt många objekt med massa properties. 
        public void BookProxy()
        {
            //rensar listan för att undvika dubbletter
            Proxies.Clear();
            foreach (Book book in books.Values)
            {
                Proxies.Add(new BookProxy(book.Id, book.Title, book.Author));
            }
        }
    }
}
