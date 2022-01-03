using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] webSites = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Smartphone smartphone = new Smartphone();
            //StationaryPhone stationaryPhone = new StationaryPhone();

            foreach (string currentNumber in phoneNumbers)
            {
                Console.WriteLine(smartphone.Call(currentNumber));
                //Console.WriteLine(stationaryPhone.Call(currentNumber));
            }

            foreach (string currentURL in webSites)
            {
                Console.WriteLine(smartphone.Browse(currentURL));
            }
        }
    }
}
