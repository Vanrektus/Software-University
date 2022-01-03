namespace StreamProgress
{
    public class Music : IStreamable
    {
        //---------------------------Fields---------------------------
        private readonly string artist;
        private readonly string album;

        //---------------------------Properties---------------------------
        public int Length { get; set; }
        public int BytesSent { get; set; }

        //---------------------------Constructors---------------------------
        public Music(string artist, string album, int length, int bytesSent)
        {
            this.artist = artist;
            this.album = album;
            this.Length = length;
            this.BytesSent = bytesSent;
        }
    }
}
