using System;
using System.Linq;

namespace KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int bestOnesSum = 1;
            int bestStartIndex = 0;
            int bestSubsequenceSum = 0;
            int bestSequenceIndex = 0;
            int[] bestSequenceArray = new int[length];

            int sequenceCounter = 0;

            while (input != "Clone them!")
            {
                int[] currentSequenceArray = input
                    .Split('!', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                sequenceCounter++;

                int onesSum = 1;
                int bestCurrentOnesSum = 1;
                int startIndex = 0;
                int currentSubsequenceSum = 0;

                for (int i = 0; i < currentSequenceArray.Length - 1; i++)
                {
                    if (currentSequenceArray[i] == currentSequenceArray[i + 1])
                    {
                        onesSum++;
                    }
                    else
                    {
                        onesSum = 1;
                    }

                    if (onesSum > bestCurrentOnesSum)
                    {
                        bestCurrentOnesSum = onesSum;
                        startIndex = i;
                    }
                    currentSubsequenceSum += currentSequenceArray[i];
                }

                currentSubsequenceSum += currentSequenceArray[length - 1];

                if (bestCurrentOnesSum > bestOnesSum)
                {
                    bestOnesSum = bestCurrentOnesSum;
                    bestStartIndex = startIndex;
                    bestSubsequenceSum = currentSubsequenceSum;
                    bestSequenceIndex = sequenceCounter;
                    bestSequenceArray = currentSequenceArray.ToArray();
                }
                else if (bestCurrentOnesSum == bestOnesSum)
                {
                    if (startIndex < bestStartIndex)
                    {
                        bestOnesSum = bestCurrentOnesSum;
                        bestStartIndex = startIndex;
                        bestSubsequenceSum = currentSubsequenceSum;
                        bestSequenceIndex = sequenceCounter;
                        bestSequenceArray = currentSequenceArray.ToArray();
                    }
                    else if (startIndex == bestStartIndex)
                    {
                        if (currentSubsequenceSum > bestSubsequenceSum)
                        {
                            bestOnesSum = bestCurrentOnesSum;
                            bestStartIndex = startIndex;
                            bestSubsequenceSum = currentSubsequenceSum;
                            bestSequenceIndex = sequenceCounter;
                            bestSequenceArray = currentSequenceArray.ToArray();
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestSequenceIndex} with sum: {bestSubsequenceSum}.");
            Console.WriteLine(string.Join(' ', bestSequenceArray));
        }
    }
}