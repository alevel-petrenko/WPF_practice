using Business.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Business.Queue
{
    /// <summary>
    /// Represents the queue collection based on the array.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    public sealed class ArrayQueue<T> : ICustomCollection<T>
    {
        /// <summary>
        /// Holds the head pointer.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private int head = 0;

        /// <summary>
        /// Holds the queue collection to work with.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private T[] queue = new T[4];

        /// <summary>
        /// Holds the tail pointer.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private int tail = -1;

        /// <summary>
        /// Holds the size of the array.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private int size = 0;

        /// <summary>
        /// Clears this collection instance.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
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
        /// <owner>Anton Petrenko</owner>
        /// <returns>The oldest element from the start of the collection.</returns>
        public T Remove()
        {
            if (this.size == 0)
                throw new InvalidOperationException("There is no items in collection.");

            T itemToReturn = this.queue[this.head];

            if (this.head == this.queue.Length - 1)
                head = 0;
            else
                this.head++;

            this.size--;

            return itemToReturn;
        }

        /// <summary>
        /// Adds an element to the end of the collection.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="element">The element to add.</param>
        public void Add(T element)
        {
            //
			// Array is full.
			//
            if (this.queue.Length == this.size)
			{
				T[] newQueue = new T[this.size * 2];
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

            //
            // Wrapping tail pointer.
            //
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
        /// <owner>Anton Petrenko</owner>
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
        /// <owner>Anton Petrenko</owner>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Returns the oldest element that is at the start of the collection, but does not remove it.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>The oldest element that is at the start of the collection.</returns>
        public T ShowCurrent()
        {
            if (this.size == 0)
                throw new InvalidOperationException("There is no items in collection.");

            return this.queue[this.head];
        }
    }
}