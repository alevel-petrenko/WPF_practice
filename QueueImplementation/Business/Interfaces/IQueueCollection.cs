using System.Collections.Generic;

namespace Business.Interfaces
{
    /// <summary>
    /// Represents the general commands for the queue collection.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    public interface IQueueCollection<T> : IEnumerable<T>
    {
        /// <summary>
        /// Clears this collection instance.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        void Clear();

        /// <summary>
        /// Removes the oldest element from the start of the collection.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>The oldest element from the start of the collection.</returns>
        T Dequeue();

        /// <summary>
        /// Adds an element to the end of the collection.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="element">The element to add.</param>
        void Enqueue(T element);

        /// <summary>
        /// Returns the oldest element that is at the start of the collection, but does not remove it.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>The oldest element that is at the start of the collection.</returns>
        T Peek();
    }
}