namespace Recharge
{
    public class Robot : Worker, IRechargeable
    {
        //---------------------------Fields---------------------------
        private int capacity;

        //---------------------------Properties---------------------------
        public int Capacity
        {
            get => this.capacity;
            private set => this.capacity = value;
        }

        public int CurrentPower { get; private set; }

        //---------------------------Constructors---------------------------
        public Robot(string id, int capacity)
            : base(id)
        {
            this.capacity = capacity;
        }

        //---------------------------Methods---------------------------
        public override void Work(int hours)
        {
            if (hours > this.CurrentPower)
            {
                hours = this.CurrentPower;
            }

            base.Work(hours);
            this.CurrentPower -= hours;
        }

        public void Recharge()
        {
            this.CurrentPower = this.capacity;
        }
    }
}
