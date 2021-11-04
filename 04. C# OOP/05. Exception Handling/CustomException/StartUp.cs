using System;

namespace CustomException
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                int lectionTime = int.Parse(Console.ReadLine());

                CheckTime(lectionTime);
            }
            catch (LectionOvertimeException loe)
            {
                Console.WriteLine($"{loe.Message}, {loe.Overtime} minuti poveche");
            }
        }

        private static void CheckTime(int lectionTime)
        {
            if (lectionTime > 180)
            {
                throw new LectionOvertimeException("Prestara se", lectionTime - 180);
            }
        }
    }
}
