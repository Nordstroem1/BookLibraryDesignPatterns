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
        public void Command()
        {
            Logic();
        }
        public void Logic()
        {
            int[] sortedArray = FillArrayFromDatabase();
            Sort(sortedArray,0,sortedArray.Length -1);

            Console.WriteLine($"The books amount of pages in acending order:");
            foreach (int num in sortedArray)
            {
                Console.WriteLine(num);
            }
        }

        private void Sort(int[] pages, int start, int end)
        {
            if(start < end)
            {
                int pivot = Partition(pages, start, end);
                Sort(pages, start, pivot -1);
                Sort(pages,pivot +1, end);
            }
        }

        private int Partition(int[] array, int start, int end)
        {
            int pivot = array[end];
            int i = start;

            for(int j = start; j < end; j++)
            {
                if (array[j] < pivot) 
                {
                    swap(array,i,j);
                    i++;
                }
            }
            swap(array,i,end);
            return i;
        }

        private void swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private int[] FillArrayFromDatabase()
        {
            int[] pagesFromBooks = new int[db.books.Count];
            int index = 0;
            foreach (Book book in db.books.Values)
            {
                pagesFromBooks[index] = book.PageCount;
                index++;
            }
            return pagesFromBooks;
        }
    }
}
