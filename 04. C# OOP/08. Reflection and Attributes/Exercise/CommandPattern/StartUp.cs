using CommandPattern.Core.Models;
using CommandPattern.Core.Contracts;
using CommandPattern.IO;

namespace CommandPattern
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(commandInterpreter, reader, writer);

            engine.Run();
        }
    }
}
