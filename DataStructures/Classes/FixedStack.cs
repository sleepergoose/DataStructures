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
    class FixedStack<T> : IEnumerable<T>
    {
        // Private counter
        private int count = 0;
        // Internal stack storage
        private T[] storage;

        /// <summary>
        /// Returns count of stack elements
        /// </summary>
        public int Count { get { return count; } }

        /// <summary>
        /// Returns True if stack is empty, otherwise, false
        /// </summary>
        public bool IsEmpty { get { return count == 0; } }

        // Class constructor
        public FixedStack()
        {
            storage = new T[10];
        }
        // Class constructor
        public FixedStack(int size)
        {
            storage = new T[size];
        }

        /// <summary>
        /// Pushes an item onto the stack
        /// </summary>
        /// <param name="item">An item for inserting on the stack</param>
        public void Push(T item)
        {
            if (count >= storage.Length)
                Resize(storage.Length + 10);

            storage[count++] = item;
        }

        /// <summary>
        /// Returns the last-inserted item from the stack and removes it
        /// </summary>
        public T Pop()
        {
            if (IsEmpty)
                throw new Exception();
            T item = storage[--count];
            if (count > 0 && count == storage.Length - 10)
                Resize(storage.Length - 10);

            return item;
        }

        /// <summary>
        /// Returns the last-inserted item from the stack
        /// </summary>
        public T Peek()
        {
            if (IsEmpty)
                throw new Exception();
            else
                return storage[count];
        }

        // Resizes internal storage
        private void Resize(int max)
        {
            T[] temp = new T[max];
            Array.Copy(storage, temp, ((storage.Length > max) ? max : storage.Length));
            storage = temp;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in storage)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
