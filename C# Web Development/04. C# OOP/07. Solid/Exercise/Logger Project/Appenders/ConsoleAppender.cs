using LoggerLibrary.Enumerations;
using LoggerLibrary.Interfaces;
using System;

namespace LoggerLibrary.Appenders
{
    public class ConsoleAppender : Appender
    {
        //---------------------------Constructors---------------------------
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
            
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

            Console.WriteLine(content);
        }
    }
}
