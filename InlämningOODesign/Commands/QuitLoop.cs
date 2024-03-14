using InlämningOODesign.BookManager;
using InlämningOODesign.Classes;
using InlämningOODesign.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningOODesign.Commands
{
    public class QuitLoop : ICommand
    {
        Bookmanager Manager { get; set; }

        public void Command()
        {
            Logic();
        }

        public QuitLoop(Bookmanager manager) 
        {
            this.Manager = manager;
        }

        public void Logic()
        {
            Manager.StopLoop();
        }
    }
}
