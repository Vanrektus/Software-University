namespace LoggerLibrary.IO
{
    public interface IWriter
    {
        //---------------------------Methods---------------------------
        void Write(string input);
        void WriteLine(string input);
    }
}
