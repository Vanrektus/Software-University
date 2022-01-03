using CustomDI.Attributes;
using DIWorkshop.Contracts;

namespace DIWorkshop.Core
{
    public class Engine : IEngine
    {
        //---------------------------Fields---------------------------
        //[Inject]
        //[Named("ConsoleWriter")]
        private readonly IWriter consoleWriter;

        //[Inject]
        //[Named("FileWriter")]
        private readonly IWriter fileWriter;

        //[Inject]
        private readonly IReader reader;

        //---------------------------Constructors---------------------------
        [Inject]
        public Engine(
            [Named("ConsoleWriter")]
            IWriter consoleWriter, 
            [Named("FileWriter")] 
            IWriter fileWriter, 
            IReader reader)
        {
            this.consoleWriter = consoleWriter;
            this.fileWriter = fileWriter;
            this.reader = reader;
        }

        //---------------------------Methods---------------------------
        public void Run()
        {
            string text = reader.Read();
            fileWriter.Write(text);
            consoleWriter.Write(text);
        }
    }
}
