using InlämningOODesign.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningOODesign.Factories
{
    //denna klassen hjälper till att återanvända författare som redan finns, syftet med flyweight pattern är att 
    //minska minnes förbrukningen genom att återanvända befintliga objekt
    public class AuthorFactory
    {
        private Dictionary<string, Author> authors = new Dictionary<string, Author>();

        public Author GetAuthor(string name)
        {
            if (!authors.ContainsKey(name))
            {
                authors[name] = new Author(name);
            }
            return authors[name];
        }
    }
}
