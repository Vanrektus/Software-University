using System;

namespace CustomException
{
    public class LectionOvertimeException : ApplicationException
    {
        //---------------------------Properties---------------------------
        public int Overtime { get; private set; }

        //---------------------------Constructors---------------------------
        public LectionOvertimeException(string message)
            : base(message)
        {

        }

        public LectionOvertimeException(string message, int overtime)
            : base(message)
        {
            this.Overtime = overtime;
        }
    }
}
