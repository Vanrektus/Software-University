using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args) 
        {
            DoublyLinkedList myList = new DoublyLinkedList(new int[] { 27, 21, 69 });

            myList.ForEach(Console.WriteLine);

            myList.AddFirst(5);

            Console.WriteLine($"Removed item: {myList.RemoveLast()}");

            myList.AddLast(9);

            Console.WriteLine($"Removed item: {myList.RemoveFirst()}");

            int[] arr = myList.ToArray();

            myList.ForEach(Console.WriteLine);
        }
    }
}
