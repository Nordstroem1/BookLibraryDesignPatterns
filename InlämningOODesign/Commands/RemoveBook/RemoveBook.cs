using InlämningOODesign.Classes;
using InlämningOODesign.DatabaseWannabe;
using InlämningOODesign.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningOODesign.Commands.RemoveBook
{
    public class RemoveBook : ICommand
    {
        WannabeDatabse Db = WannabeDatabse.Instance;
        public Book BookToRemove;

        public void Command()
        {
            Logic();
        }
        //användaren får fråga vilken bok som ska tas bort från databasen.
        //Användaren anger ett nummer som matchar index av böckerna
        public void Logic()
        {
            Console.WriteLine("Select the number of the book you want to remove:");
            for (int i = 0; i < Db.books.Count; i++)
            {
                Console.WriteLine($"{i +1}:{Db.books[i].Title}");
            }
            int input;
            try
            {
                input = Convert.ToInt32(Console.ReadLine()) -1;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }
            if (input < 0 || input > Db.books.Count)
            {
                Console.WriteLine("Invalid number. Please select a valid number");
            }

            //ta bort booken om det är ID:t som input angav
            for (int i = 0; i < Db.books.Count; i++)
            {
                if (Db.books.ContainsKey(input))
                {
                    Console.WriteLine($"{Db.books[input].Title} has been removed");
                    Db.books.Remove(input);
                    return;
                }
            }
        }
    }
}
