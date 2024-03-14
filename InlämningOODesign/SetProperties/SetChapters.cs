using InlämningOODesign.Classes;
using InlämningOODesign.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningOODesign.SetProperties
{
    public class SetChapters : IPropertyEditor
    {
        public void EditProperty(Book book)
        {
            Console.WriteLine("Enter new chapter amount.");
            int newChapters = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Old amount of chapters: {book.Chapters}");
            book.Chapters = newChapters;
            Console.WriteLine($"New Amount:{book.Chapters}");
        }
    }
}
