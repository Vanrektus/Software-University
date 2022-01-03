using LoggerLibrary.Enumerations;
using LoggerLibrary.Interfaces;

namespace LoggerLibrary.Appenders
{
    public class FileAppender : Appender
    {
        //---------------------------Fields---------------------------
        private readonly ILogFile logFile;

        //---------------------------Constructors---------------------------
        public FileAppender(ILayout layout, ILogFile logFile)
            : base(layout)
        {
            this.logFile = logFile;
        }

        //---------------------------Methods---------------------------
        public override void Append(string date, ReportLevelEnum reportLevel, string message)
        {
            if (reportLevel < this.ReportLevel)
            {
                return;
            }

            string content = string.Format(this.Layout.Template, date, reportLevel, message);

            this.MessagesCount++;

            this.logFile.Write(content);
        }

        public override string ToString()
        {
            return $"{base.ToString()}, File size: {this.logFile.Size}";
        }
    }
}
