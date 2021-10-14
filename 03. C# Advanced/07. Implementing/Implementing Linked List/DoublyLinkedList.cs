using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomDoublyLinkedList
{
    /// <summary>
    /// Двойно свързан списък
    /// </summary>
    public class DoublyLinkedList
    {
        /// <summary>
        /// Брой елементи в списъка
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Първи елемент
        /// </summary>
        public Node Head { get; private set; }

        /// <summary>
        /// Последен елемент
        /// </summary>
        public Node Tail { get; private set; }

        /// <summary>
        /// Създава празен списък
        /// </summary>
        public DoublyLinkedList()
        {
            Count = 0;
            Head = null;
            Tail = null;
        }

        /// <summary>
        /// Създава списък с един елемент
        /// </summary>
        /// <param name="value">Стойност на елемента</param>
        public DoublyLinkedList(int value)
            : this()
        {
            Node newNode = new Node()
            {
                Value = value,
                Next = null,
                Previous = null
            };

            Count++;
            Head = Tail = newNode;
        }

        /// <summary>
        /// Създава списък от колекция от елементи
        /// </summary>
        /// <param name="list">Елементи, които да бъдат добавени в списъка</param>
        public DoublyLinkedList(IEnumerable<int> list)
            : this(list.First())
        {
            bool istFirst = true;

            foreach (var item in list)
            {
                if (istFirst)
                {
                    istFirst = false;
                }
                else
                {
                    Node newNode = new Node()
                    {
                        Value = item,
                        Previous = Tail,
                        Next = null
                    };

                    Tail.Next = newNode;
                    Tail = newNode;
                    Count++;
                }
            }
        }

        /// <summary>
        /// Добавя елемент в началото
        /// </summary>
        /// <param name="element">Елемент за добавяне</param>
        public void AddFirst(int element)
        {
            Node newNode = new Node() { Value = element };

            if (Count == 0)
            {
                Head = Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head.Previous = newNode;
                Head = newNode;
            }

            Count++;
        }

        /// <summary>
        /// Добавя елемент в края
        /// </summary>
        /// <param name="element">Елемент за добавяне</param>
        public void AddLast(int element)
        {
            Node newNode = new Node() { Value = element };

            if (Count == 0)
            {
                Head = Tail = newNode;
            }
            else
            {
                newNode.Previous = Tail;
                Tail.Next = newNode;
                Tail = newNode;
            }

            Count++;
        }

        /// <summary>
        /// Премахва елемент в началото
        /// </summary>
        /// <param name="element">Елемент за премахване</param>
        public int RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty!");
            }

            int result = Head.Value;
            Head = Head.Next;

            if (Head == null)
            {
                Tail = null;
            }
            else
            {
                Head.Previous = null;
            }

            Count--;

            return result;
        }

        /// <summary>
        /// Премахва елемент в края
        /// </summary>
        /// <param name="element">Елемент за премахване</param>
        public int RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty!");
            }

            int result = Tail.Value;
            Tail = Tail.Previous;

            if (Tail == null)
            {
                Head = null;
            }
            else
            {
                Tail.Next = null;
            }

            Count--;

            return result;
        }

        /// <summary>
        /// Извършва действие върху всеки елемент на колекцията
        /// </summary>
        /// <param name="action">Действие, което да се изпълни</param>
        public void ForEach(Action<int> action)
        {
            Node currentNode = Head;

            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }

        /// <summary>
        /// Превръща списъка в масив
        /// </summary>
        /// <returns>Масив от елементите на списъка</returns>
        public int[] ToArray()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty!");
            }

            int[] result = new int[Count];
            Node currentNode = Head;
            int index = 0;

            while (currentNode != null)
            {
                result[index] = currentNode.Value;

                index++;
                currentNode = currentNode.Next;
            }

            return result;
        }
    }
}