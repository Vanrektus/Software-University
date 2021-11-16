namespace CommandPattern.Core.Contracts
{
    public interface ICommandInterpreter
    {
        //---------------------------Methods---------------------------
        string Read(string args);
    }
}
