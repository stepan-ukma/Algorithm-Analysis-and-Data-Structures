using System.Collections;
using System.Xml.Linq;

namespace Lab1
{
    public class MyQueue<T> : IEnumerable<T>
    {
        public QueueItem<T> head { get; set; }
        QueueItem<T> tail;
        private int counter = 0;

        public bool IsEmpty()
        {
            return head == null;
        }

        public void Enqueue(T value)
        {
            if (IsEmpty())
            {
                tail = head = new QueueItem<T> { Value = value, Next = null };
            }  
            else
            {
                var item = new QueueItem<T> { Value = value, Next = null };
                tail.Next = item;
                tail = item;
            }
            counter++;  
        }

        public T Dequeue()
        {
            if (head == null) throw new InvalidOperationException();

            var result = head.Value;
            head = head.Next;

            if (head == null)
                tail = null;

            counter--;

            return result;
        }

        public bool Contains(T value)
        {
            if (counter == 0) return false;

            var temp = head;

            while (temp.Next != null)
            {
                if (Equals(temp.Value, value)) return true;
                temp = temp.Next;
            }
            return false;
        }

        // Method that prints the [N/2] element. Time complexity: O(N).
        public void PrintMiddleElement()
        {
            if (head != null)
            {
                QueueItem<T> temp = head;

                for (int i = 1; i < counter / 2; i++)
                {
                    temp = temp.Next;
                }

                Console.Write("The [N/2] element is [" + temp.Value + "]");
                Console.WriteLine();
            }
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator<T>(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}