using Business.Interfaces;
using System;

namespace Business.Helper
{
    /// <summary>
    /// Represents the factory for getting queue collection.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <typeparam name="T"></typeparam>
    public sealed class QueueCollectionFactory<T>
    {
        /// <summary>
        /// Gets the queue collection.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="type">The collection type.</param>
        /// <returns>The queue collection.</returns>
        public IQueueCollection<T> GetCollection(CollectionType type)
        {
            switch (type)
            {
                case CollectionType.Array:
                    return new ArrayQueue<T>();

                case CollectionType.LinkedList:
                    return new LinkedListQueue<T>();

                default:
                    throw new InvalidOperationException("There is an invalid operation type");
            }
        }
    }
}