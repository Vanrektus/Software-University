using LoggerLibrary.Enumerations;
using LoggerLibrary.Interfaces;
using System.Text;

namespace LoggerLibrary.Loggers
{
    public class Logger : ILogger
    {
        //---------------------------Fields---------------------------
        private readonly IAppender[] appenders;

        //---------------------------Constructors---------------------------
        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        //---------------------------Methods---------------------------
        public void Info(string date, string message)
        {
            AppendAllMessages(date, ReportLevelEnum.Info, message);
        }

        public void Warning(string date, string message)
        {
            AppendAllMessages(date, ReportLevelEnum.Warning, message);
        }

        public void Error(string date, string message)
        {
            AppendAllMessages(date, ReportLevelEnum.Error, message);
        }

        public void Critical(string date, string message)
        {
            AppendAllMessages(date, ReportLevelEnum.Critical, message);
        }

        public void Fatal(string date, string message)
        {
            AppendAllMessages(date, ReportLevelEnum.Fatal, message);
        }

        private void AppendAllMessages(string date, ReportLevelEnum reportLevel, string message)
        {
            foreach (IAppender currentAppender in appenders)
            {
                currentAppender.Append(date, reportLevel, message);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Logger info");

            foreach (IAppender currentAppender in this.appenders)
            {
                sb.AppendLine(currentAppender.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
