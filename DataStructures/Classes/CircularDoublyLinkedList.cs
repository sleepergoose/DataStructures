using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Classes
{
    /// <summary>
    /// Circular Doulby Linked List class
    /// </summary>
    /// <typeparam name="T">Data type</typeparam>
    class CircularDoublyLinkedList<T> : IEnumerable<T>
    {
        // Private fields
        // Node counter
        private int count = 0;
        // Internal reference to the head node
        private BiNode<T> head;
        // Internal reference to the tail node
        private BiNode<T> tail;

        // Properties
        // Properties
        /// <summary>
        /// Returns count of stack elements 
        /// </summary>
        public int Count { get { return count; } }

        /// <summary>
        /// Returnes the first item of the Queue
        /// </summary>
        public BiNode<T> First { get { return head; } }

        /// <summary>
        /// Returnes the first item of the Queue
        /// </summary>
        public BiNode<T> Last { get { return tail; } }

        /// <summary>
        /// Returns True if stack is empty, otherwise, false
        /// </summary>
        public bool IsEmpty { get { return count == 0; } }

        // Methods
        // Methods
        /// <summary>
        /// Adds item onto the Linked List
        /// </summary>
        /// <param name="data">Data for inserting</param>
        public void Add(T data)
        {
            if (data == null)
                throw new Exception();

            BiNode<T> node = new BiNode<T>(data);
            if (count == 0)
            {
                head = node;
                tail = head;
                tail.Next = head;
                head.Previous = tail;
            }
            else
            {
                tail.Next = node;
                node.Previous = tail;
                node.Next = head;
                tail = node;
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

            BiNode<T> current = head;

            do
            {
                if (current.Data.Equals(data))
                {
                    if (count == 1)
                    {
                        Clear();
                        return true;
                    }

                    BiNode<T> deleted = current;
                    deleted.Previous.Next = deleted.Next;
                    deleted.Next.Previous = deleted.Previous;

                    if (deleted == head)
                    {
                        head = deleted.Next;
                        tail.Next = head;
                    }

                    if (deleted == tail)
                        tail = deleted.Previous;
                    count--;
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

        /// <summary>
        /// Returns True if the Linke List contains data, otherwise, False
        /// </summary>
        /// <param name="data">Data for searching</para
        public bool Contains(T data)
        {
            if (data == null)
                throw new Exception();

            BiNode<T> forward = head;
            BiNode<T> backward = tail;

            do
            {
                if (forward.Data.Equals(data))
                {
                    return true;
                }
                if (backward.Data.Equals(data))
                {
                    return true;
                }
                forward = forward.Next;
                backward = backward.Previous;

            } while (forward != backward);

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            BiNode<T> current = head;

            do
            {
                if (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            } while (current != head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
