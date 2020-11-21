using Autofac;
using Business.Interfaces;
using System;

namespace Business.Helper
{
	/// <summary>
	/// Represents functionality for creating the collection type.
	/// </summary>
	/// <owner>Anton Petrenko</owner>
	public sealed class CollectionConfigCreator<T>
	{
		/// <summary>
		/// Initializes the collection.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <param name="selectedQueueStackType">The selected type of collection (queue/stack).</param>
		/// <param name="selectedArrayLinkedListType">The selected type of collection (array/linked list).</param>
		/// <returns>The initialized collection.</returns>
		public ICustomCollection<T> InitializeCollection(string selectedQueueStackType, string selectedArrayLinkedListType)
		{
			if (string.IsNullOrEmpty(selectedArrayLinkedListType))
				throw new ArgumentException("Please select array or linked list setting!");
			if (string.IsNullOrEmpty(selectedQueueStackType))
				throw new ArgumentException("Please select queue or stack setting!");

			var container = CustomCollectionConfig<T>.Configure(selectedQueueStackType, selectedArrayLinkedListType);
			return container.Resolve<ICustomCollection<T>>();
		}
	}
}