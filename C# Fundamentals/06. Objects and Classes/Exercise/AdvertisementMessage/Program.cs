using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            Advertisement advertisement = new Advertisement();

            int n = int.Parse(Console.ReadLine());

            for (int firstIndex = 0; firstIndex < n; firstIndex++)
            {
                Console.WriteLine(advertisement.Message());
            }
        }
    }

    class Advertisement
    {
        public string[] Phrases = new string[] {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product." };
        public string[] Events =  new string[] { "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!" };
    public string[] Authors = new string[] { "Diana",
                "Petya",
                "Stella",
                "Elena",
                "Katya",
                "Iva",
                "Annie",
                "Eva" };
        public string[] Cities = new string[] { "Burgas",
                "Sofia",
                "Plovdiv",
                "Varna",
                "Ruse" };

        public string Message()
        {
            Random random = new Random();

            string randomPhrase = Phrases[random.Next(0, Phrases.Length)];
            string randomEvent = Events[random.Next(0, Events.Length)];
            string randomAuthor = Authors[random.Next(0, Authors.Length)];
            string randomCity = Cities[random.Next(0, Cities.Length)];

            return $"{randomPhrase} {randomEvent} {randomAuthor} - {randomCity}";
        }
    }
}
