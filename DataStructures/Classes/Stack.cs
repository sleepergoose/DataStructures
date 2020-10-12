using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Classes
{
    /// <summary>
    /// LIFO stack class
    /// </summary>
    /// <typeparam name="T">Data type</typeparam>
    class Stack<T> : IEnumerable<T>
    {
        // Node counter
        private int count = 0;
        // Internal reference to the head node
        private Node<T> head;

        /// <summary>
        /// Returns count of stack elements 
        /// </summary>
        public int Count { get { return count; } }

        /// <summary>
        /// Returns True if stack is empty, otherwise, false
        /// </summary>
        public bool IsEmpty { get { return count == 0; } }

        /// <summary>
        /// Pushes an item onto the stack
        /// </summary>
        /// <param name="data">An item for inserting on the stack as a Node</param>
        public void Push(T data)
        {
            if (data == null)
                throw new Exception();

            Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;
            count++;
        }

        /// <summary>
        /// Returns the last-inserted item from the stack and removes it
        /// </summary>
        public T Pop()
        {
            if (IsEmpty)
                throw new Exception();

            Node<T> node = head;
            head = head.Next;
            count--;
            return node.Data;
        }

        /// <summary>
        /// Returns the last-inserted item from the stack
        /// </summary>
        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пуст");
            return head.Data;
        }
        /// <summary>
        /// Removes all data in the stack
        /// </summary>
        public void Clear()
        {
            head = null;
            count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
