namespace RawData
{
    class Cargo
    {
        //---------------------------Properties---------------------------
        public int Weight { get; private set; }
        public string Type { get; private set; }

        //---------------------------Constructors---------------------------
        public Cargo(int weight, string type)
        {
            this.Weight = weight;
            this.Type = type;
        }
    }
}
