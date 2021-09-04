using System;

namespace CourierExpress
{
    class Program
    {
        static void Main(string[] args)
        {
            double weightOfPackage = double.Parse(Console.ReadLine());
            string typeOfDelivery = Console.ReadLine();
            double distance = double.Parse(Console.ReadLine());

            double totalPrice = 0.0;

            if (weightOfPackage < 1)
            {
                totalPrice = distance * 0.03;
            }
            else if (weightOfPackage >= 1 && weightOfPackage < 10)
            {
                totalPrice = distance * 0.05;
            }
            else if (weightOfPackage >= 10 && weightOfPackage < 40)
            {
                totalPrice = distance * 0.10;
            }
            else if (weightOfPackage >= 40 && weightOfPackage < 90)
            {
                totalPrice = distance * 0.15;
            }
            else if (weightOfPackage >= 90 && weightOfPackage <= 150)
            {
                totalPrice = distance * 0.20;
            }

            if (typeOfDelivery == "express")
            {
                if (weightOfPackage < 1)
                {
                    totalPrice += 0.03 * 0.80 * weightOfPackage * distance;
                }
                else if (weightOfPackage >= 1 && weightOfPackage < 10)
                {
                    totalPrice += 0.05 * 0.40 * weightOfPackage * distance;
                }
                else if (weightOfPackage >= 10 && weightOfPackage < 40)
                {
                    totalPrice += 0.10 * 0.05 * weightOfPackage * distance;
                }
                else if (weightOfPackage >= 40 && weightOfPackage < 90)
                {
                    totalPrice += 0.15 * 0.02 * weightOfPackage * distance;
                }
                else if (weightOfPackage >= 90 && weightOfPackage <= 150)
                {
                    totalPrice += 0.20 * 0.01 * weightOfPackage * distance;
                }
            }

            Console.WriteLine($"The delivery of your shipment with weight of {weightOfPackage:f3} kg. would cost {totalPrice:f2} lv.");
        }
    }
}
