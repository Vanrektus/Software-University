using System;
using System.Collections.Generic;

namespace WordSynonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> elements = new Dictionary<string, List<string>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (elements.ContainsKey(word))
                {
                    elements[word].Add(synonym);
                }
                else
                {
                    elements.Add(word, new List<string> { synonym });
                }

            }

            foreach (var item in elements)
            {
                Console.WriteLine($"{item.Key} - {string.Join(", ", item.Value)}");
            }
            
        }
    }
}
