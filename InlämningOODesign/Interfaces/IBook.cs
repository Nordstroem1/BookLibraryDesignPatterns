using InlämningOODesign.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningOODesign.Interfaces
{
    public interface IBook
    {
        public int Id { get; set; }
        public static int nextID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Author Author { get; set; }
        public int PageCount { get; set; }
        public int Chapters { get; set; }
        public bool Published { get; set; }
    }
}
