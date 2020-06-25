using Business.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Business
{
    public class LinkedListQueue<T> : IQueueCollection<T>
    {
        private LinkedList<T> queue;

        public void Clear()
        {

        }

        public T Dequeue()
        {
            throw new NotImplementedException();
        }

        public void Enqueue(T element)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public T Peek()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}