using CommandPattern.Core.Contracts;
using CommandPattern.IO;

namespace CommandPattern.Core.Models
{
    public class Engine : IEngine
    {
        //---------------------------Fields---------------------------
        private readonly ICommandInterpreter commandInterpreter;
        private readonly IReader reader;
        private readonly IWriter writer;

        //---------------------------Constructors---------------------------
        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public Engine(ICommandInterpreter commandInterpreter,IReader reader, IWriter writer)
            : this(commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
        }

        //---------------------------Methods---------------------------
        public void Run()
        {
            while (true)
            {
                string input = this.reader.ReadLine();

                string result = this.commandInterpreter.Read(input);

                this.writer.WriteLine(result);
            }
        }
    }
}
