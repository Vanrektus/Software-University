namespace StreamProgress
{
    public class StreamProgressInfo
    {
        //---------------------------Fields---------------------------
        private readonly IStreamable streamable;

        //---------------------------Constructors---------------------------
        public StreamProgressInfo(IStreamable streamable)
        {
            this.streamable = streamable;
        }

        //---------------------------Methods---------------------------
        public int CalculateCurrentPercent()
        {
            return (this.streamable.BytesSent * 100) / this.streamable.Length;
        }
    }
}
