using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningOODesign.Classes.Builders
{
    public class AuthorBuilder
    {
        public string Name { get; set; } = string.Empty;

        public AuthorBuilder SetName(string name)
        {
            Name = name;
            return this;
        }
        public Author Build()
        {
            return new Author(Name);
        }
    }
}
