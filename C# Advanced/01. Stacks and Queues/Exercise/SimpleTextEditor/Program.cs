using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder textToEdit = new StringBuilder();
            Stack<string> editHistory = new Stack<string>();

            editHistory.Push(textToEdit.ToString());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();
                int commandName = int.Parse(command[0]);

                switch (commandName)
                {
                    case 1:
                        string textToAdd = command[1];

                        textToEdit.Append(textToAdd);
                        editHistory.Push(textToEdit.ToString());
                        break;
                    case 2:
                        int count = int.Parse(command[1]);

                        textToEdit.Remove(textToEdit.Length - count, count);
                        editHistory.Push(textToEdit.ToString());
                        break;
                    case 3:
                        int index = int.Parse(command[1]);

                        Console.WriteLine(textToEdit[index - 1]);
                        break;
                    case 4:
                        editHistory.Pop();
                        textToEdit = new StringBuilder();
                        textToEdit.Append(editHistory.Peek());
                        break;
                }
            }
        }
    }
}
