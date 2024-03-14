using InlämningOODesign.Classes;
using InlämningOODesign.Commands;
using InlämningOODesign.Commands.AddBook;
using InlämningOODesign.Commands.EditBook;
using InlämningOODesign.Commands.RemoveBook;
using InlämningOODesign.Commands.SortingAlgorithms;
using InlämningOODesign.DatabaseWannabe;
using InlämningOODesign.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningOODesign.BookManager
{
    public class Bookmanager : IManager
    {
        bool quitLoop = false;
        Invoker invoker = new Invoker();
        Dictionary<string,ICommand> commands = new Dictionary<string,ICommand>();

        //här skapas alla commands som hanterar vad som ska ske i programmet.
        public void AddCommands()
        {
            AddBook addBook = new AddBook();
            RemoveBook removeBook = new RemoveBook();   
            EditBook editBook = new EditBook();
            QuitLoop quitLoop = new QuitLoop(this);
            ViewBooks viewBooks = new ViewBooks();
            QuickSort quickSort = new QuickSort();
            InsertionSort insertionSort = new InsertionSort();

            commands.Add("Add book",addBook);
            commands.Add("Remove book",removeBook);
            commands.Add("Edit book",editBook);
            commands.Add("View books", viewBooks);
            commands.Add("Sort by pages",quickSort);
            commands.Add("Sort by chapters", insertionSort);
            commands.Add("Stop",quitLoop);
        }
        public void CommandExecuter()
        {
            CommandMenu();
        }

        //användaren skriver in nyckeln till commandet sedan körs det.
        public void CommandMenu()
        {
            AddCommands();
            while (!quitLoop)
            {
                Console.WriteLine("\nWhat do you want to do ?");
                foreach (var command in commands)
                {
                    Console.WriteLine(command.Key);
                }
                Console.WriteLine();
                string userInput = Console.ReadLine().ToLower();
                string capitalized = char.ToUpper(userInput[0]) + userInput.Substring(1);
                if (commands.ContainsKey(capitalized))
                {
                    ICommand selectedCommand = commands[capitalized];
                    invoker.SetCommand(selectedCommand);
                    invoker.ExecuteCommand();
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
        }
        //Stoppar while-loopen
        public void StopLoop()
        {
            quitLoop = true;
        }
    }
}
