﻿namespace CustomDoublyLinkedList
{
    /// <summary>
    /// Елемент от двойно свързан списък
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Стойност на елемента
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Следващ елемент
        /// </summary>
        public Node Next { get; set; }

        /// <summary>
        /// Предишен елемент
        /// </summary>
        public Node Previous { get; set; }
    }
}
