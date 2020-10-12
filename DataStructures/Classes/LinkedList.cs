using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Classes
{
    /// <summary>
    /// Linked List class
    /// </summary>
    /// <typeparam name="T">Data type</typeparam>
    class LinkedList<T> : IEnumerable<T>
    {
        // Private fields
        // Node counter
        private int count = 0;
        // Internal reference to the head node
        private Node<T> head = null;
        // Internal reference to the tail node
        private Node<T> tail = null;

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

        // Class constructor
        public LinkedList(T data)
        {
            head = new Node<T>(data);
            tail = head;
            count = 1;
        }

        // Empty class constructor
        public LinkedList() { }

        // Methods
        /// <summary>
        /// Adds item onto the Linked List
        /// </summary>
        /// <param name="data">Data for inserting</param>
        public void Add(T data)
        {
            if (data == null)
                throw new ArgumentNullException("Method 'Add', argument 'data' can't equal null");

            if (count == 0)
            {
                head = new Node<T>(data);
                tail = head;
            }
            else
            {
                Node<T> addition = new Node<T>(data);
                tail.Next = addition;
                tail = addition;
            }
            count++;
        }

        /// <summary>
        ///Removes data from the Queue
        /// </summary>
        public bool Remove(T data)
        {
            if (data == null)
                throw new ArgumentNullException("Method 'Add', argument 'data' can't equal null");

            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    // Если узел в середине или в конце списка
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        // Если current.Next равен null, значит узел последний
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        // Удаляется первый узел
                        head = current.Next;

                        // а если теперь список пуст
                        if (head == null)
                            Clear();
                    }
                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Appends item onto LinkedList after specified element
        /// </summary>
        /// <param name="insertData">Data for inserting</param>
        /// <param name="previousData">Data after which 'insertData' will be inserted</param>
        /// <returns>Returns True if inserting is successful, otherwise, False </returns>
        public bool AppendAfter(T insertData, T previousData)
        {
            if (insertData == null || previousData == null)
                throw new ArgumentNullException("Method 'AppendAfter' has someone null argument");

            Node<T> current = head;

            while (current != null)
            {
                if (current.Data.Equals(previousData))
                {
                    Node<T> node = new Node<T>(insertData);
                    node.Next = current.Next;
                    current.Next = node;
                    if (current == tail)
                        tail = current.Next;
                    count++;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Appends item onto LinkedList before first element
        /// </summary>
        /// <param name="data">Data for inserting</param>
        public void AppendFirst(T data)
        {
            if (data == null)
                throw new ArgumentNullException("Method 'AppendAfter' has someone null argument");

            Node<T> first = new Node<T>(data);
            first.Next = head;
            head = first;
            count++;
        }

        /// <summary>
        /// Returns True if the Linke List contains data, otherwise, False
        /// </summary>
        /// <param name="data">Data for searching</param>
        public bool Contains(T data)
        {
            if (data == null)
                throw new ArgumentNullException("Method 'AppendAfter' has someone null argument");

            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Gets all items from the LinkeList
        /// </summary>
        /// <returns>Return all item as List<T></returns>
        public List<T> GetAllData()
        {
            return this.ToList<T>();
        }

        /// <summary>
        /// Removes all items in a LinkedList
        /// </summary>
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.count != 0)
                {
                    this.Dispose();
                    head = null;
                    tail = null;
                    count = 0;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
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

        /// <summary>
        /// Gets Node by specified 'data'
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Returns Node<T> item with specified 'data'</returns>
        public Node<T> Get(T data)
        {
            if (data == null)
                return null;

            var current = head;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }
    }
}
