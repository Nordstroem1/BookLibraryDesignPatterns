using InlämningOODesign.Classes;
using InlämningOODesign.DatabaseWannabe;
using InlämningOODesign.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace InlämningOODesign.Commands.SortingAlgorithms
{
    public class QuickSort : ICommand
    {
        WannabeDatabse db = WannabeDatabse.Instance;
        List<Book> list = new List<Book>();
        public void Command()
        {
            Logic();
        }
        public void Logic()
        {
            FillArrayFromDatabase();
            Sort(list,0,list.Count -1);
            Console.Clear();
            Console.WriteLine($"The books amount of pages in acending order:");
            foreach (Book book in list)
            {
                Console.WriteLine($"{book.PageCount}\t{book.Title}");
            }
        }

        private void Sort(List<Book> list, int start, int end)
        {
            if(start < end)
            {
                int pivot = Partition(list, start, end);
                Sort(list, start, pivot -1);
                Sort(list,pivot +1, end);
            }
        }

        private int Partition(List<Book> list, int start, int end)
        {
            int pivot = list[end].PageCount;
            int i = start;

            for(int j = start; j < end; j++)
            {
                if (list[j].PageCount < pivot) 
                {
                    swap(list,i,j);
                    i++;
                }
            }
            swap(list,i,end);
            return i;
        }

        private void swap(List<Book> list, int i, int j)
        {
            Book temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        private List<Book> FillArrayFromDatabase()
        {
            foreach (Book book in db.books.Values)
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
