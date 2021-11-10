namespace Recharge
{
    public abstract class Worker : IWorker
    {
        //---------------------------Fields---------------------------
        private readonly string id;
        private int workingHours;

        //---------------------------Properties---------------------------
        public int WorkingHours
        {
            get => this.workingHours;
            protected set => this.workingHours = value;
        }

        public string Id => this.id;

        //---------------------------Constructors---------------------------
        public Worker(string id)
        {
            this.id = id;
        }

        //---------------------------Methods---------------------------
        public virtual void Work(int hours)
        {
            this.WorkingHours += hours;
        }
    }
}
