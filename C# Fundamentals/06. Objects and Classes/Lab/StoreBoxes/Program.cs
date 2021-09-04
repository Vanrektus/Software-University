using System;
using System.Collections.Generic;

namespace StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> box = new List<Box>();

            List<double> sortedPrices = new List<double>();

            while (true)
            {
                string[] currentItem = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (currentItem[0] == "end")
                {
                    break;
                }

                Box newBox = new Box();

                newBox.SerialNumber = int.Parse(currentItem[0]);
                newBox.ItemName = currentItem[1];
                newBox.ItemQuantity = int.Parse(currentItem[2]);
                newBox.ItemPrice = double.Parse(currentItem[3]);

                box.Add(newBox);

                sortedPrices.Add(newBox.ItemQuantity * newBox.ItemPrice);
            }

            sortedPrices.Sort();
            sortedPrices.Reverse();

            PrintBoxes(box, sortedPrices);
        }

        static void PrintBoxes(List<Box> box, List<double> sortedPrices)
        {
            for (int i = 0; i < sortedPrices.Count; i++)
            {
                foreach (Box currentItem in box)
                {
                    if (sortedPrices[i] == (currentItem.ItemPrice * currentItem.ItemQuantity))
                    {
                        Console.WriteLine(currentItem.SerialNumber);
                        Console.WriteLine($"-- {currentItem.ItemName} - ${currentItem.ItemPrice:f2}: {currentItem.ItemQuantity}");
                        Console.WriteLine($"-- ${sortedPrices[i]:f2}");
                    }
                }
            }
        }
    }

    class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    class Box
    {
        public int SerialNumber { get; set; }
        public string ItemName { get; set; }
        public int ItemQuantity { get; set; }
        public double ItemPrice { get; set; }
    }
}
