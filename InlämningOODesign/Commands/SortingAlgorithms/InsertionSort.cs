using InlämningOODesign.Classes;
using InlämningOODesign.DatabaseWannabe;
using InlämningOODesign.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InlämningOODesign.Commands.SortingAlgorithms
{
    public class InsertionSort : ICommand
    {
        WannabeDatabse db = WannabeDatabse.Instance;
        List<Book> list = new List<Book>();

        public void Command()
        {
            Logic();
        }

        public void Logic()
        {
            Sort(ConvertDicToLíst());
            Console.WriteLine("Books sorted after chapters");
            foreach(Book book in list)
            {
                Console.WriteLine($"{book.Chapters}\t{book.Title}");
            }
        }
        //sorterar listan med insertionsort algoristmen
        private void Sort(List<Book>books)
        {
            for (int i = 1; i < books.Count; i++)
            {
                int valueToSort = books[i].Chapters;
                int j = i;

                while (j > 0 && valueToSort < books[j - 1].Chapters)
                {
                    books[j].Chapters = books[j - 1].Chapters;
                    j--;
                }
                books[j].Chapters = valueToSort;
            }
        }

        //konverterar dictionaryn till en lista för att kunna sortera och skriva ut vad som är sorterat
        public List<Book> ConvertDicToLíst()
        {
            foreach(Book book in db.books.Values)
            {
                if (!list.Contains(book))
                {
                    list.Add(book);
                }
            }
            return list;
        }
    }
}
