using System;

namespace AluminumJoinery
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfJoinery = int.Parse(Console.ReadLine());
            string sizeOfJoinery = Console.ReadLine();
            string typeOfDelivery = Console.ReadLine();

            double totalPrice = 0;

            if (numberOfJoinery < 10)
            {
                Console.WriteLine("Invalid order");
                return;
            }

            switch (sizeOfJoinery)
            {
                case "90X130":
                    totalPrice = numberOfJoinery * 110;
                    if (numberOfJoinery > 30 && numberOfJoinery <= 60)
                    {
                        totalPrice -= totalPrice * 0.05;
                    }
                    else if (numberOfJoinery > 60)
                    {
                        totalPrice -= totalPrice * 0.08;
                    }
                    break;
                case "100X150":
                    totalPrice = numberOfJoinery * 140;
                    if (numberOfJoinery > 4 && numberOfJoinery <= 80)
                    {
                        totalPrice -= totalPrice * 0.06;
                    }
                    else if (numberOfJoinery > 80)
                    {
                        totalPrice -= totalPrice * 0.1;
                    }
                    break;
                case "130X180":
                    totalPrice = numberOfJoinery * 190;
                    if (numberOfJoinery > 20 && numberOfJoinery <= 50)
                    {
                        totalPrice -= totalPrice * 0.07;
                    }
                    else if (numberOfJoinery > 50)
                    {
                        totalPrice -= totalPrice * 0.12;
                    }
                    break;
                case "200X300":
                    totalPrice = numberOfJoinery * 250;
                    if (numberOfJoinery > 25 && numberOfJoinery <= 50)
                    {
                        totalPrice -= totalPrice * 0.09;
                    }
                    else if (numberOfJoinery > 50)
                    {
                        totalPrice -= totalPrice * 0.14;
                    }
                    break;
            }

            if (typeOfDelivery == "With delivery")
            {
                totalPrice += 60;
            }

            if (numberOfJoinery > 99)
            {
                totalPrice -= totalPrice * 0.04;
            }
            Console.WriteLine($"{totalPrice:f2} BGN");
        }
    }
}
