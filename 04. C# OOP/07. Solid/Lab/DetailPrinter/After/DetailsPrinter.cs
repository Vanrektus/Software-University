using System;
using System.Collections.Generic;

namespace DetailPrinter
{
    public class DetailsPrinter
    {
        //---------------------------Fields---------------------------
        private readonly IList<IEmployee> employees;

        //---------------------------Methods---------------------------
        public DetailsPrinter(IList<IEmployee> employees)
        {
            this.employees = employees;
        }

        //---------------------------Methods---------------------------
        public void PrintDetails()
        {
            foreach (IEmployee currentEmployee in this.employees)
            {
                Console.WriteLine(currentEmployee.ToString());
            }
        }
    }
}
