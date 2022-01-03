using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList randomList = new RandomList() { "Ivan", "Ani", "Pesho", "Gosho", "Aleks", "Mariika" };

            Console.WriteLine(randomList.RandomString());
            Console.WriteLine(randomList.RemoveRandomElement());
        }
    }
}
