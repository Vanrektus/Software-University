using System;

namespace Recharge
{
    public class Employee : Worker, ISleeper
    {
        //---------------------------Constructors---------------------------
        public Employee(string id)
            : base(id)
        {

        }

        //---------------------------Methods---------------------------
        public void Sleep()
        {
            Console.WriteLine("Sleeping...");
        }
    }
}
