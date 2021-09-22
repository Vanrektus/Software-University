﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WordCount
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Dictionary<string, int> foundWords = new Dictionary<string, int>();

            using (StreamReader textReader = new StreamReader("TextFiles/text.txt"))
            using (StreamReader wordsReader = new StreamReader("TextFiles/words.txt"))
            {
                string inputText = await textReader.ReadToEndAsync();
                string[] inputTextArray = inputText
                    .Split(new string[] { " ", "-", ".", ",", "?", "!", ":", ";" }, StringSplitOptions.RemoveEmptyEntries);

                string wordsToFind = await wordsReader.ReadToEndAsync();
                string[] wordsToFindArray = wordsToFind
                    .Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

                foreach (var currentWordToCount in wordsToFindArray)
                {
                    foreach (var currentWord in inputTextArray)
                    {
                        if (currentWordToCount.ToUpper() == currentWord.ToUpper())
                        {
                            if (foundWords.ContainsKey(currentWordToCount) == false)
                            {
                                foundWords.Add(currentWordToCount, 1);
                            }
                            else
                            {
                                foundWords[currentWordToCount]++;
                            }
                        }
                    }
                }

                using (StreamWriter writer = new StreamWriter("actualResult.txt"))
                {
                    foreach (var currentWord in foundWords)
                    {
                        writer.WriteLine($"{currentWord.Key} - {currentWord.Value}");
                    }
                }

                using (StreamWriter writer = new StreamWriter("expectedResult.txt"))
                {
                    foreach (var currentWord in foundWords.OrderByDescending(x => x.Value))
                    {
                        writer.WriteLine($"{currentWord.Key} - {currentWord.Value}");
                    }
                }
            }
        }
    }
}
