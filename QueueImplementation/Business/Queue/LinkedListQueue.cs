using Business.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Business.Queue
{
	/// <summary>
	/// Represents the queue collection based on the linked list.
	/// </summary>
	/// <owner>Anton Petrenko</owner>
	public sealed class LinkedListQueue<T> : ICustomCollection<T>
	{
		/// <summary>
		/// Holds the queue collection to work with.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		private LinkedList<T> queue = new LinkedList<T>();

		/// <summary>
		/// Clears this collection instance.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		public void Clear()
		{
			this.queue.Clear();
		}

		/// <summary>
		/// Removes the oldest element from the start of the collection.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <returns>The oldest element from the start of the collection.</returns>
		public T Remove()
		{
			if (this.queue.Count == 0)
				throw new InvalidOperationException("There is no items in collection.");

			T itemToReturn = this.queue.First.Value;
			this.queue.RemoveFirst();

			return itemToReturn;
		}

		/// <summary>
		/// Adds an element to the end of the collection.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <param name="element">The element to add.</param>
		public void Add(T element)
		{
			this.queue.AddLast(element);
		}

		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <returns>An enumerator that can be used to iterate through the collection.</returns>
		public IEnumerator<T> GetEnumerator()
		{
			return queue.GetEnumerator();
		}

		/// <summary>
		/// Returns the oldest element that is at the start of the collection, but does not remove it.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <returns>The oldest element that is at the start of the collection.</returns>
		public T ShowCurrent()
		{
			if (this.queue.Count == 0)
				throw new InvalidOperationException("There is no items in collection.");

			return this.queue.First.Value;
		}

		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <returns>An <see cref="IEnumerator" /> object that can be used to iterate through the collection.</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return queue.GetEnumerator();
		}
	}
}