using System;
using System.Collections.Generic;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Engine> engines = new Dictionary<string, Engine>();

            Func<string[], bool> isDigit = d => d.Length == 3 && char.IsDigit(d[2][0]);
            Func<string[], bool> isLetter = l => l.Length == 3 && char.IsLetter(l[2][0]);
            Func<string[], bool> isBoth = b => b.Length == 4;

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                int power = int.Parse(input[1]);
                string displacement = "n/a";
                string efficiency = "n/a";


                if (isDigit(input))
                {
                    displacement = input[2];
                }
                else if (isLetter(input))
                {
                    efficiency = input[2];
                }
                else if (isBoth(input))
                {
                    displacement = input[2];
                    efficiency = input[3];
                }

                Engine engine = new Engine(model, power, displacement, efficiency);
                engines[model] = engine;
            }

            int m = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < m; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                Engine engine = engines[input[1]];
                string weight = "n/a";
                string color = "n/a";

                if (isDigit(input))
                {
                    weight = input[2];
                }
                else if (isLetter(input))
                {
                    color = input[2];
                }
                else if (isBoth(input))
                {
                    weight = input[2];
                    color = input[3];
                }

                Car car = new Car(model, engine, weight, color);
                cars.Add(car);
            }

            Console.WriteLine(string.Join("", cars));
        }
    }
}
