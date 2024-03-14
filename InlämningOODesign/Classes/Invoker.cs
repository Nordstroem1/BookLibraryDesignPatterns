using InlämningOODesign.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlämningOODesign.Classes
{
    public class Invoker : IExecuter
    {
        private ICommand commander;
        public void SetCommand(ICommand commander)
        {
            this.commander = commander;
        }

        public void ExecuteCommand()
        {
            commander.Command();
        }
    }
}
