using LoggerLibrary.Enumerations;
using LoggerLibrary.Interfaces;

namespace LoggerLibrary.Appenders
{
    public abstract class Appender : IAppender
    {
        //---------------------------Properties---------------------------
        public ILayout Layout { get; }
        public ReportLevelEnum ReportLevel { get; set; }
        public int MessagesCount { get; protected set; }

        //---------------------------Constructors---------------------------
        protected Appender(ILayout layout)
        {
            this.Layout = layout;
        }

        //---------------------------Methods---------------------------
        public abstract void Append(string date, ReportLevelEnum reportLevel, string message);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}," +
                $" Layout type: {this.Layout.GetType().Name}," +
                $" Report level: {this.ReportLevel}," +
                $" Messages appended: {this.MessagesCount}";
        }
    }
}
