using System;

namespace FruitShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double amount = double.Parse(Console.ReadLine());

            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    switch (fruit)
                    {
                        case "banana":
                            Console.WriteLine($"{amount * 2.50:f2}");
                            break;
                        case "apple":
                            Console.WriteLine($"{amount * 1.20:f2}");
                            break;
                        case "orange":
                            Console.WriteLine($"{amount * 0.85:f2}");
                            break;
                        case "grapefruit":
                            Console.WriteLine($"{amount * 1.45:f2}");
                            break;
                        case "kiwi":
                            Console.WriteLine($"{amount * 2.70:f2}");
                            break;
                        case "pineapple":
                            Console.WriteLine($"{amount * 5.50:f2}");
                            break;
                        case "grapes":
                            Console.WriteLine($"{amount * 3.85:f2}");
                            break;
                        default:
                            Console.WriteLine("error");
                            break;
                    }
                    break;
                case "Saturday":
                case "Sunday":
                    switch (fruit)
                    {
                        case "banana":
                            Console.WriteLine($"{amount * 2.70:f2}");
                            break;
                        case "apple":
                            Console.WriteLine($"{amount * 1.25:f2}");
                            break;
                        case "orange":
                            Console.WriteLine($"{amount * 0.90:f2}");
                            break;
                        case "grapefruit":
                            Console.WriteLine($"{amount * 1.60:f2}");
                            break;
                        case "kiwi":
                            Console.WriteLine($"{amount * 3.00:f2}");
                            break;
                        case "pineapple":
                            Console.WriteLine($"{amount * 5.60:f2}");
                            break;
                        case "grapes":
                            Console.WriteLine($"{amount * 4.20:f2}");
                            break;
                        default:
                            Console.WriteLine("error");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("error");
                    break;


            }
        }
    }
}
