using InlämningOODesign.Interfaces;
using InlämningOODesign.SetProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace InlämningOODesign.Classes
{
    public class PropertyEditorFactory
    {
        //detta var en factory som blev command pattern, därav namnet.
        Dictionary<int, IPropertyEditor> PropDic = new Dictionary<int, IPropertyEditor>();
        public PropertyEditorFactory() 
        {
            SetTitle setTitle = new SetTitle();
            SetAuthor setAuthor = new SetAuthor();
            SetDescription setDescription = new SetDescription();  
            SetChapters setChapters = new SetChapters();
            SetPageCount setPageCount = new SetPageCount();
            SetPublished setPublished = new SetPublished();
            PropDic.Add(1, setTitle);
            PropDic.Add(2, setDescription);
            PropDic.Add(3, setAuthor);
            PropDic.Add(4, setChapters);
            PropDic.Add(5, setPageCount);
            PropDic.Add(6, setPublished);
        }
        public void CreatePropertyEditor(int propertyIndex,Book book)
        {
            if (PropDic.ContainsKey(propertyIndex))
            {
                PropDic[propertyIndex].EditProperty(book);
            }
        }
    }
}   
