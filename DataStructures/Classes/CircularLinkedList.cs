using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Classes
{
    /// <summary>
    /// Circular Linked List class
    /// </summary>
    /// <typeparam name="T">Data type</typeparam>
    class CircularLinkedList<T> : IEnumerable<T>
    {
        // Private fields
        // Node counter
        private int count = 0;
        // Internal reference to the head node
        private Node<T> head;
        // Internal reference to the tail node
        private Node<T> tail;

        // Properties
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

        // Methods
        /// <summary>
        /// Adds item onto the Linked List
        /// </summary>
        /// <param name="data">Data for inserting</param>
        public void Add(T data)
        {
            if (data == null)
                throw new Exception();

            Node<T> node = new Node<T>(data);
            if (count != 0)
            {
                tail.Next = node;
                tail = node;
                node.Next = head;
            }
            else
            {
                head = node;
                tail = head;
                head.Next = tail;
                tail.Next = head;
            }
            count++;
        }

        /// <summary>
        ///Removes data from the Queue
        /// </summary>
        public bool Remove(T data)
        {
            if (data == null)
                throw new Exception();

            Node<T> current = head;
            Node<T> previous = null;

            do
            {
                if (current.Data.Equals(data))
                {
                    if (current == head)
                    {
                        tail.Next = head.Next;
                        head = tail.Next;
                    }
                    else if (current == tail)
                    {
                        previous.Next = head;
                    }
                    else
                    {
                        previous.Next = current.Next;
                    }
                    count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            } while (current != head);
            return false;
        }

        /// <summary>
        /// Returns True if the Linke List contains data, otherwise, False
        /// </summary>
        /// <param name="data">Data for searching</param>
        public bool Contains(T data)
        {
            if (data == null)
                throw new Exception();

            Node<T> current = head;
            do
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }
                current = current.Next;
            } while (current != head);

            return false;
        }

        /// <summary>
        /// Removes all data from the Linked List
        /// </summary>
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> crowler = head;

            do
            {
                if (crowler != null)
                {
                    yield return crowler.Data;
                    crowler = crowler.Next;
                }
            } while (crowler != head);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
