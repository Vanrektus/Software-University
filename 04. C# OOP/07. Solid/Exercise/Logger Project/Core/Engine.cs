using LoggerLibrary.Appenders;
using LoggerLibrary.Enumerations;
using LoggerLibrary.Interfaces;
using LoggerLibrary.IO;
using LoggerLibrary.Layouts;
using LoggerLibrary.Loggers;

namespace LoggerLibrary.Core
{
    public class Engine : IEngine
    {
        //---------------------------Fields---------------------------
        private readonly IReader reader;
        private readonly IWriter writer;

        //---------------------------Constructors---------------------------
        public Engine()
        {

        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        //---------------------------Methods---------------------------
        public void Run()
        {
            // === 1 ===

            ILayout simpleLayout1 = new SimpleLayout();
            IAppender consoleAppender1 = new ConsoleAppender(simpleLayout1);
            ILogger logger1 = new Logger(consoleAppender1);

            logger1.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            logger1.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");

            // === 2 ===

            ILayout simpleLayout2 = new SimpleLayout();
            IAppender consoleAppender2 = new ConsoleAppender(simpleLayout2);

            ILogFile file = new LogFile();
            IAppender fileAppender = new FileAppender(simpleLayout2, file);

            ILogger logger2 = new Logger(consoleAppender2, fileAppender);

            logger2.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            logger2.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");

            // === 3 ===

            ILayout xmlLayout = new XmlLayout();
            IAppender consoleAppender3 = new ConsoleAppender(xmlLayout);
            ILogger logger3 = new Logger(consoleAppender3);

            logger3.Fatal("3/31/2015 5:23:54 PM", "mscorlib.dll does not respond");
            logger3.Critical("3/31/2015 5:23:54 PM", "No connection string found in App.config");

            // === 4 ===

            ILayout simpleLayout4 = new SimpleLayout();
            IAppender consoleAppender4 = new ConsoleAppender(simpleLayout4);
            consoleAppender4.ReportLevel = ReportLevelEnum.Error;

            ILogger logger4 = new Logger(consoleAppender4);

            logger4.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
            logger4.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
            logger4.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            logger4.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
            logger4.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");

            this.writer.WriteLine(logger1.ToString());
            this.writer.WriteLine(logger2.ToString());
            this.writer.WriteLine(logger3.ToString());
            this.writer.WriteLine(logger4.ToString());
        }
    }
}
