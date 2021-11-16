using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern.Core.Models.Commands
{
    public class ExitCommand : ICommand
    {
        //---------------------------Methods---------------------------
        public string Execute(string[] args)
        {
            Environment.Exit(0);
            return null;
        }
    }
}
