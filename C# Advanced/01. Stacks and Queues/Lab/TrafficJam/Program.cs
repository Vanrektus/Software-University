using System;
using System.Collections.Generic;

namespace TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> traffic = new Queue<string>();
            int count = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                if (input == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (traffic.Count > 0)
                        {
                            Console.WriteLine($"{traffic.Dequeue()} passed!");
                            count++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    traffic.Enqueue(input);
                }
            }

            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
