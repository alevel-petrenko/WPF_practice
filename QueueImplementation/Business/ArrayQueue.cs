using Business.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Business
{
    public sealed class ArrayQueue<T> : IQueueCollection<T>
    {
        /// <summary>
        /// Holds the head pointer.
        /// </summary>
        private int head = 0;

        /// <summary>
        /// Holds the queue collection to work with.
        /// </summary>
        private T[] queue = new T[4];

        /// <summary>
        /// Holds the tail pointer.
        /// </summary>
        private int tail = -1;

        /// <summary>
        /// Holds the size of the array.
        /// </summary>
        private int size = 0;

        /// <summary>
        /// Clears this collection instance.
        /// </summary>
        public void Clear()
        {
            this.head = 0;
            this.tail = -1;
            this.size = 0;
            this.queue = new T[4];
        }

        /// <summary>
        /// Removes the oldest element from the start of the collection.
        /// </summary>
        /// <returns>The oldest element from the start of the collection.</returns>
        public T Dequeue()
        {
            if (this.size == 0)
                throw new InvalidOperationException("There is no items in collection.");

            T itemToDelete = this.queue[this.head];

            if (this.head == this.queue.Length - 1)
                head = 0;
            else
                this.head++;

            this.size--;

            return itemToDelete;
        }

        /// <summary>
        /// Adds an element to the end of the collection.
        /// </summary>
        /// <param name="element">The element to add.</param>
        public void Enqueue(T element)
        {
            // Array is full
            if (this.queue.Length == size)
            {
                T[] newQueue = new T[size * 2];
                int indexInNewArray = 0;

                if (this.tail < this.head)
                {
                    for (int indexInOldArray = this.head; indexInOldArray < this.queue.Length; indexInOldArray++)
                        newQueue[indexInNewArray++] = queue[indexInOldArray];

                    for (int indexInOldArray = 0; indexInOldArray <= this.tail; indexInOldArray++)
                        newQueue[indexInNewArray++] = queue[indexInOldArray];
                }
                else
                    for (int indexInOldArray = this.head; indexInOldArray <= this.tail; indexInOldArray++)
                        newQueue[indexInNewArray++] = queue[indexInOldArray];

                this.head = 0;
                this.tail = indexInNewArray - 1;
                this.queue = newQueue;
            }
            // Wrapping tail pointer
            if (this.tail == this.queue.Length - 1)
                this.tail = 0;
            else
                this.tail++;

            this.queue[this.tail] = element;
            this.size++;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            if (this.size > 0)
            {
                if (this.tail < this.head)
                {
                    for (int index = this.head; index < this.queue.Length; index++)
                        yield return this.queue[index];

                    for (int index = 0; index <= this.tail; index++)
                        yield return this.queue[index];
                }
                for (int index = this.head; index <= this.tail; index++)
                    yield return this.queue[index];
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Returns the oldest element that is at the start of the collection, but does not remove it.
        /// </summary>
        /// <returns>The oldest element that is at the start of the collection</returns>
        public T Peek()
        {
            if (this.size == 0)
                throw new InvalidOperationException("There is no items in collection.");

            return this.queue[this.head];
        }
    }
}