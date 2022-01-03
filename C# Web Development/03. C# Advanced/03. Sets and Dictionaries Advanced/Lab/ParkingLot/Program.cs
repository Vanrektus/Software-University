using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parkingLot = new HashSet<string>();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "END")
                {
                    break;
                }

                if (input[0] == "IN")
                {
                    parkingLot.Add(input[1]);
                }
                else if (input[0] == "OUT")
                {
                    parkingLot.Remove(input[1]);
                }
            }

            if (parkingLot.Any())
            {
                foreach (var currentNumber in parkingLot)
                {
                    Console.WriteLine(currentNumber);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
