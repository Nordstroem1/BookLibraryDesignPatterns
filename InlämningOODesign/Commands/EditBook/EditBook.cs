using InlämningOODesign.Classes;
using InlämningOODesign.DatabaseWannabe;
using InlämningOODesign.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace InlämningOODesign.Commands.EditBook
{
    public class EditBook : ICommand
    {
        private Book book;
        int propertyIndex = -1;
        WannabeDatabse db = WannabeDatabse.Instance;

        public void Command()
        {
           Logic();
        }
        public void EditBookCommand(Book chosenBook)
        {
            this.book = chosenBook;
        }

        //logic för att en användare ska kunna välja bok!
        public void Logic()
        {
            book = ChooseBook();
            propertyIndex = ChoseProperty();

            if(propertyIndex > -1)
            {
                PropertyEditorFactory propertyEditorFactory = new PropertyEditorFactory();
                propertyEditorFactory.CreatePropertyEditor(propertyIndex,book);
            }
        }
        //hämtar properties av boken så att användaren kan välja vad man vill uppdatera.
        private int ChoseProperty()
        {
            Type bookType = book.GetType();
            PropertyInfo[] properties = bookType.GetProperties();

            Console.WriteLine("Witch property do you want to edit? type -1 to exit");
            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i].Name.Equals("Id", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                if (properties[i].Name.Equals("nextID", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                Console.WriteLine($"{i + 1} Property Name: {properties[i].Name}");
            }

            Console.WriteLine("Enter the number of the property you want to edit: ");
            int propertyInput = Convert.ToInt32(Console.ReadLine()) - 2;

            if (propertyInput > 0 && propertyInput <= properties.Length)
            {
                return propertyInput;
            }
            else
            {
                Console.WriteLine("Invalid property number.");
            }
            return -2;
        }
        private Book ChooseBook()
        {
            Console.WriteLine("Choose your book by Id.");
            for (int i = 0; i < db.books.Count; i++)
            {
                Console.WriteLine($"Id:{i +1} {db.books[i].Title}");
            }
            int ChosenBookIndex = Convert.ToInt32(Console.ReadLine()) -1;

            if(ChosenBookIndex >= 0 && ChosenBookIndex < db.books.Count)
            {
                return db.books[ChosenBookIndex];
            }
            else
            {
                return null;
            }
        }
    }
    
}
