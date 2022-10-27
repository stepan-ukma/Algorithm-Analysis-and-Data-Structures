namespace Lab1
{
    public class QueueEnumerator<T> : IEnumerator<T>
    {
        MyQueue<T> queue;
        QueueItem<T> currentItem;

        public QueueEnumerator(MyQueue<T> queue)
        {
            this.queue = queue;
            this.currentItem = null;
        }

        public T Current
        {
            get { return currentItem.Value; }
        }

        public bool MoveNext()
        {
            if (currentItem == null)
                currentItem = queue.head;
            else
                currentItem = currentItem.Next;
            return currentItem != null;
        }

        public void Dispose() { }
        object System.Collections.IEnumerator.Current
        {
            get { return Current; }
        }
        public void Reset()
        {

        }
    }
}