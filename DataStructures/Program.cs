using DataStructures.Classes;
using System;
using System.Linq;

namespace DataStructures
{
    class Program
    {
        static Action<object> Write = (content) => Console.WriteLine(content);

        static FixedStack<int> fstack = new FixedStack<int>();
        static Stack<int> stack = new Stack<int>();
        static Queue<int> queue = new Queue<int>();
        static LinkedList<int> llist = new LinkedList<int>();
        static DoublyLinkedList<int> dllist = new DoublyLinkedList<int>();
        static CircularLinkedList<int> cllist = new CircularLinkedList<int>();
        static CircularDoublyLinkedList<int> cdllist = new CircularDoublyLinkedList<int>();

        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                fstack.Push(i);
                stack.Push(i);
                queue.Enqueue(i);
                llist.Add(i);
                dllist.Add(i);
                cllist.Add(i);
                cdllist.Add(i);
            }
            for (int i = 0; i < 5; i++)
            {
                Write($"Fixed Stack: {fstack.Pop()}");
                Write($"Stack: {stack.Pop()}");
                Write($"Queue: {queue.Dequeue()}");
                Write($"Linked List: {llist.Get(i).Data}");
                Write($"Doubly Linked List: {dllist.Get(i).Data}");
                Write($"Circular Linked List: {cllist.ToArray()[i]}");
                Write($"Fixed Stack: {cdllist.ToArray()[i]}");
                Write(null);
            }
        }
    }
}
