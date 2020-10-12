using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Classes
{
    /// <summary>
    /// FIFO stack class
    /// </summary>
    /// <typeparam name="T">Data type</typeparam>
    class Queue<T> : IEnumerable<T>
    {
        // Node counter
        private int count = 0;
        // Internal reference to the first node
        private Node<T> head = null;
        // Internal reference to the last node
        private Node<T> tail = null;

        /// <summary>
        /// Returns count of stack elements 
        /// </summary>
        public int Count { get { return count; } }

        /// <summary>
        /// Returns True if stack is empty, otherwise, false
        /// </summary>
        public bool IsEmpty { get { return count == 0; } }

        /// <summary>
        /// Returnes the first item of the Queue
        /// </summary>
        public Node<T> First { get { return head; } }

        /// <summary>
        /// Returnes the first item of the Queue
        /// </summary>
        public Node<T> Last { get { return tail; } }

        /// <summary>
        /// Adds item onto the Queue
        /// </summary>
        /// <param name="data">Data for inserting</param>
        public void Enqueue(T data)
        {
            if (data == null)
                throw new Exception();
            Node<T> node = new Node<T>(data);
            Node<T> temp_node = tail;
            tail = node;

            if (IsEmpty)
                head = tail;
            else
                temp_node.Next = tail;
            count++;
        }

        /// <summary>
        /// Returns item onto the Queue
        /// </summary>
        public T Dequeue()
        {
            if (IsEmpty)
                throw new Exception();
            Node<T> result = head;
            head = head.Next;
            count--;
            return result.Data;
        }

        /// <summary>
        /// Removes all data from the Queue
        /// </summary>
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        /// <summary>
        /// Returns True if the Queue contains data, otherwise, False
        /// </summary>
        /// <param name="data">Data for searching</para
        public bool Contains(T data)
        {
            if (data == null || IsEmpty)
                return false;

            var current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
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
