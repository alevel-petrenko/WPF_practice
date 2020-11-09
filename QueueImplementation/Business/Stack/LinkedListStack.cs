using Business.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Business.Stack
{
	/// <summary>
	/// Represents the stack collection based on the linked list.
	/// </summary>
	/// <owner>Anton Petrenko</owner>
	public sealed class LinkedListStack<T> : IStackCollection<T>
	{
		/// <summary>
		/// Holds the stack collection to work with.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		private LinkedList<T> stack = new LinkedList<T>();

		/// <summary>
		/// Clears this collection instance.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		public void Clear()
		{
			this.stack.Clear();
		}

		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <returns>An enumerator that can be used to iterate through the collection.</returns>
		public IEnumerator<T> GetEnumerator()
		{
			return stack.GetEnumerator();
		}

		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <returns>An <see cref="IEnumerator" /> object that can be used to iterate through the collection.</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return stack.GetEnumerator();
		}

		/// <summary>
		/// Returns the last element that is at the end of the collection, but does not remove it.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <returns>The last element that is at the end of the collection.</returns>
		public T Peek()
		{
			if (this.stack.Count == 0)
				throw new InvalidOperationException("There is no items in collection.");

			return this.stack.Last.Value;
		}

		/// <summary>
		/// Removes the last element from the collection.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <returns>The last element from the end of the collection.</returns>
		public T Pop()
		{
			if (this.stack.Count == 0)
				throw new InvalidOperationException("There is no items in collection.");

			T itemToReturn = this.stack.Last.Value;
			this.stack.RemoveLast();

			return itemToReturn;
		}

		/// <summary>
		/// Adds an element to the end of the collection.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <param name="element">The element to add.</param>
		public void Push(T element)
		{
			this.stack.AddLast(element);
		}
	}
}