using InlämningOODesign.Classes;
using InlämningOODesign.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningOODesign.SetProperties
{
    public class SetDescription : IPropertyEditor
    {
        public void EditProperty(Book book)
        {
            Console.WriteLine("Enter new description");

            string newDescription = Console.ReadLine();
            Console.WriteLine($"Old desctiption: {book.Description}");
            book.Description = newDescription;
            Console.WriteLine($"New desctiption:{book.Description}");
        }
    }
}
