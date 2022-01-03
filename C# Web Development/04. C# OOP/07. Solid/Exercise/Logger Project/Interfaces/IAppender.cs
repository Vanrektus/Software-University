using LoggerLibrary.Enumerations;

namespace LoggerLibrary.Interfaces
{
    public interface IAppender
    {
        //---------------------------Properties---------------------------
        ReportLevelEnum ReportLevel { get; set; }

        //---------------------------Methods---------------------------
        void Append(string date, ReportLevelEnum reportLevel, string message);
    }
}
