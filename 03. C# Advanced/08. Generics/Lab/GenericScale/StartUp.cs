using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> intScale = new EqualityScale<int>(3, 3);
            EqualityScale<string> stringScale = new EqualityScale<string>("Pesho", "Pesho");
            EqualityScale<string> falseStringScale = new EqualityScale<string>("Pesho", "Gosho");

            Console.WriteLine(intScale.AreEqual());
            Console.WriteLine(stringScale.AreEqual());
            Console.WriteLine(falseStringScale.AreEqual());
        }
    }
}
