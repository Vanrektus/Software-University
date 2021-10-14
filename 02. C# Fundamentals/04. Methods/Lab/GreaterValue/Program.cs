using System;

namespace GreaterValue
{
    class Program
    {
        static void Main(string[] args)
        {
            string valueType = Console.ReadLine();
            string firstValue = Console.ReadLine();
            string secondValue = Console.ReadLine();

            string result = GetMax(valueType, firstValue, secondValue);

            Console.WriteLine(result);
        }

        static string GetMax(string valueType, string firstValue, string secondValue)
        {
            string result = "";


            switch (valueType)
            {
                case "int":
                    if (int.Parse(firstValue) > int.Parse(secondValue))
                    {
                        result = firstValue;
                    }
                    else if (int.Parse(firstValue) < int.Parse(secondValue))
                    {
                        result = secondValue;
                    }
                    break;
                case "char":
                    if (char.Parse(firstValue) > char.Parse(secondValue))
                    {
                        result = firstValue;
                    }
                    else if (char.Parse(firstValue) < char.Parse(secondValue))
                    {
                        result = secondValue;
                    }
                    break;
                case "string":
                    if (firstValue.CompareTo(secondValue) >= 0) // comparing aaa to bbb
                    {
                        result = firstValue;
                    }
                    else
                    {
                        result = secondValue;
                    }
                    break;
            }

            return result;
        }
    }
}
