using System.Collections.Generic;

namespace Business.Interfaces
{
    /// <summary>
    /// Represents the general commands for the stack collection.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    public interface IStackCollection<T> : IEnumerable<T>
    {
        /// <summary>
        /// Clears this collection instance.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        void Clear();

        /// <summary>
        /// Returns the last element that is at the end of the collection, but does not remove it.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>The last element that is at the end of the collection.</returns>
        T Peek();

        /// <summary>
        /// Removes the last element from the collection.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>The last element from the end of the collection.</returns>
        T Pop();

        /// <summary>
        /// Adds an element to the end of the collection.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="element">The element to add.</param>
        void Push(T element);
    }
}