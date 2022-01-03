namespace LoggerLibrary.Interfaces
{
    public interface ILogFile
    {
        //---------------------------Properties---------------------------
        int Size { get; }

        //---------------------------Methods---------------------------
        void Write(string message);
    }
}
