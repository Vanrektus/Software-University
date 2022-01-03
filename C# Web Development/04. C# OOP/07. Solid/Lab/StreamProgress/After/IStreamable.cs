namespace StreamProgress
{
    public interface IStreamable
    {
        //---------------------------Properties---------------------------
        int Length { get; }
        int BytesSent { get; }
    }
}
