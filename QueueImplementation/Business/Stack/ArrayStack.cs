using Business.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Business.Stack
{
	/// <summary>
	/// Represents the stack collection based on the array.
	/// </summary>
	/// <owner>Anton Petrenko</owner>
	public sealed class ArrayStack<T> : IStackCollection<T>
	{
		/// <summary>
		/// Holds the stack collection to work with.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		private T[] stack = new T[4];

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
			this.size = 0;
			this.stack = new T[4];
		}

		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <returns>An enumerator that can be used to iterate through the collection.</returns>
		public IEnumerator<T> GetEnumerator()
		{
			for (int index = this.size - 1; index >= 0; index--)
				yield return this.stack[index];
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
		/// Returns the last element that is at the end of the collection, but does not remove it.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <returns>The last element that is at the end of the collection.</returns>
		public T Peek()
		{
			if (this.size == 0)
				throw new InvalidOperationException("There is no items in collection.");

			return this.stack[this.size - 1];
		}

		/// <summary>
		/// Removes the last element from the collection.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <returns>The last element from the end of the collection.</returns>
		public T Pop()
		{
			if (this.size == 0)
				throw new InvalidOperationException("There is no items in collection.");

			this.size--;
			return this.stack[this.size];
		}

		/// <summary>
		/// Adds an element to the end of the collection.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <param name="element">The element to add.</param>
		public void Push(T element)
		{
			//
			// Array is full.
			//
			if (this.stack.Length == this.size)
			{
				T[] newStack = new T[this.size * 2];

				this.stack.CopyTo(newStack, 0);
				this.stack = newStack;
			}

			this.stack[this.size] = element;
			this.size++;
		}
	}
}