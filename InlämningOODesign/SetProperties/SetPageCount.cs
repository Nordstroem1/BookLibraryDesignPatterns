using InlämningOODesign.Classes;
using InlämningOODesign.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningOODesign.SetProperties
{
    public class SetPageCount : IPropertyEditor
    {
        public void EditProperty(Book book)
        {
            Console.WriteLine("Enter new the page count.");
            int newPageCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Old amount of Pages: {book.PageCount}");
            book.PageCount = newPageCount;
            Console.WriteLine($"New Amount:{book.PageCount}");
        }
    }
}
