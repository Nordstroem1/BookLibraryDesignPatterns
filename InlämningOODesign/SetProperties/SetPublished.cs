using InlämningOODesign.Classes;
using InlämningOODesign.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningOODesign.SetProperties
{
    public class SetPublished : IPropertyEditor
    {
        public void EditProperty(Book book)
        {
            Console.WriteLine("Enter 1 for published, 2 or any number For Not published");
            int userInput = Convert.ToInt32(Console.ReadLine());
            bool Newpublished = false;

            if (userInput == 1)
            {
                Newpublished = true;
            }
            else
            {
                Newpublished = false;
            }
            Console.WriteLine($"Old value: {book.Published}");
            book.Published = Newpublished;
            Console.WriteLine($"New value:{book.Published}");
        }
    }
}
