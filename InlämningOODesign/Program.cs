using InlämningOODesign.BookManager;
using InlämningOODesign.DatabaseWannabe;

namespace InlämningOODesign
{
    public class Program
    {
        static void Main(string[] args)
        {
            Bookmanager bookmanager = new Bookmanager();
            bookmanager.CommandMenu();
        }
    }
}
