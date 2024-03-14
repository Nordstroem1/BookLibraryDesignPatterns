using InlämningOODesign.Classes;
using InlämningOODesign.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningOODesign.SetProperties
{
    public class SetTitle : IPropertyEditor
    {
        public void EditProperty(Book book)
        {
            Console.WriteLine("Enter new Title");

            string newTitle = Console.ReadLine();
            Console.WriteLine($"Old title: {book.Title}");
            book.Title = newTitle;
            Console.WriteLine($"New title:{book.Title}");
        }
    }   
}
