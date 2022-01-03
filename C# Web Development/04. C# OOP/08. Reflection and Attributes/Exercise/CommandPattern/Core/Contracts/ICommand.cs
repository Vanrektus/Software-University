namespace CommandPattern.Core.Contracts
{
    public interface ICommand
    {
        //---------------------------Methods---------------------------
        string Execute(string[] args);
    }
}
