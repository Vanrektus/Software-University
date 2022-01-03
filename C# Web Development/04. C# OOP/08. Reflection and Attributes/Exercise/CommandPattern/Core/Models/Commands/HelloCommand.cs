using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Models.Commands
{
    public class HelloCommand : ICommand
    {
        //---------------------------Methods---------------------------
        public string Execute(string[] args)
        {
            return $"Hello, {args[0]}";
        }
    }
}
