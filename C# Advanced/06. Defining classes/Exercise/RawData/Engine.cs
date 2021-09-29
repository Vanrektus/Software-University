namespace RawData
{
    class Engine
    {
        //---------------------------Properties---------------------------
        public int EngineSpeed { get; private set; }
        public int EnginePower { get; private set; }

        //---------------------------Constructors---------------------------
        public Engine(int engineSpeed, int enginePower)
        {
            this.EngineSpeed = engineSpeed;
            this.EnginePower = enginePower;
        }
    }
}
