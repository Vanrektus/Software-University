namespace StreamProgress
{
    public class File : IStreamable
    {
        //---------------------------Fields---------------------------
        private readonly string name;

        //---------------------------Properties---------------------------
        public int Length { get; set; }
        public int BytesSent { get; set; }

        //---------------------------Constructors---------------------------
        public File(string name, int length, int bytesSent)
        {
            this.name = name;
            this.Length = length;
            this.BytesSent = bytesSent;
        }
    }
}
