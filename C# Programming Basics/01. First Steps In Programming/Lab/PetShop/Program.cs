using System;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int kucheta = int.Parse(Console.ReadLine());
            int drugi = int.Parse(Console.ReadLine());
            double cena1 = kucheta * 2.5;
            double cena2 = drugi * 4.0;
            double obshto = cena1 + cena2;
            Console.WriteLine($"{obshto} lv.");
        }
    }
}
