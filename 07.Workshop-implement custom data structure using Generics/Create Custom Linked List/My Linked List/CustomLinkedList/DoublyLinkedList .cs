namespace CustomLinkedList
{
    using System;

    public class DoublyLinkedList<T> 
    {
        public class Node<U>
        {

            public Node(T value)
            {
                Vallue = value;
           
            }

            public T Vallue { get; set; }
            public Node<U> Previous { get; set; }
            public Node<U> Next { get; set; }
        }

        public Node<T> Head { get; set; }

        public Node<T> Tail { get; set; }

        public int Count { get; set; }

        public void AddFirst(T value)
        {
            var newHead = new Node<T>(value);

            if (Count == 0)
            {
                this.Head = this.Tail = newHead ;
            }
            else
            {
                var oldHead = this.Head;
                oldHead.Previous = newHead;
                newHead.Next = oldHead;
                this.Head = newHead;
            }

            Count++;
        }

        public void AddLast(T value)
        {
            var newTail = new Node<T>(value);

            if (Count == 0)
            {
                this.Head = this.Tail = newTail;
            }
            else
            {
                var oldTail = this.Tail;
                oldTail.Next = newTail;
                newTail.Previous = oldTail;
                this.Tail = newTail;
            }

            Count++;
        }

        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("List is empty");
            }

            var firstElement = this.Head.Vallue;

            this.Head = this.Head.Next;

            if (this.Head == null)
            {
                this.Tail = null;
            }
            else
            {
                this.Head.Previous = null;
            }

            Count--;
            return firstElement;
        }

        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("List is empty");
            }

            var LastElement = this.Tail.Vallue;
            this.Tail = this.Tail.Previous;

            if (this.Tail == null)
            {
                this.Head = null;
            }
            else
            {
                this.Tail.Next = null;
            }

            Count--;
            return LastElement;
        }

        public void ForEach(Action<T> action)
        {
            var currentNode = this.Head;

            while (currentNode != null)
            {
                action(currentNode.Vallue);
                currentNode = currentNode.Next;
            }
        }

        public T[] ToArray()
        {
            T[] resultArr = new T[this.Count];
            int count = 0;
            var currentNode = this.Head;

            while (currentNode != null)
            {
                resultArr[count] = currentNode.Vallue;

                count++;
                currentNode = currentNode.Next;
            }

            return resultArr;
        }

        public bool Contains(T element)
        {
            var currentNode = this.Head;

            while (currentNode != null)
            {
                if (currentNode.Vallue.Equals(element))
                {
                    return true;
                }
                currentNode = currentNode.Next;
            }

            return false;
        }
    }
}
