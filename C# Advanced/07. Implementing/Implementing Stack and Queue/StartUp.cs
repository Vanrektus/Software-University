using System;

namespace CustomDataStructures
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //List test
            CustomList myCustomList = new CustomList();

            for (int i = 0; i < 6; i++)
            {
                myCustomList.Add(i);
            }

            myCustomList.Insert(1, 6);
            myCustomList.RemoveAt(1);

            Console.WriteLine(myCustomList.Contains(3));
            Console.WriteLine(myCustomList.Contains(69));

            myCustomList.Swap(0, 2);

            Console.WriteLine(myCustomList);

            //Stack test
            CustomStack<int> myCustomStack = new CustomStack<int>();

            for (int i = 0; i < 6; i++)
            {
                myCustomStack.Push(i);
            }

            Console.WriteLine(myCustomStack.Peek());

            myCustomStack.ForEach(Console.WriteLine);

            myCustomStack.Pop();
        }
    }
}
