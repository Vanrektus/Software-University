using System;

namespace ArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 3, 8, 9 };

            //int sum = 0;

            //for (int i = 0; i < array.Length; i++)
            //{
            //    sum += array[i];
            //}

            Console.WriteLine(Sum(array, 0));
        }

        static int Sum(int[] array, int index)
        {
            if (index == array.Length)
            {
                return 0;
            }

            return array[index] + Sum(array, index + 1);
        }
    }
}
