using Autofac;
using Business.Helper.Enumeration;
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
		/// <param name="selectedCustomCollection">The selected type of custom collection (queue/stack).</param>
		/// <param name="selectedBasicCollection">The selected type of basic collection (array/linked list).</param>
		/// <returns>The initialized collection.</returns>
		public ICustomCollection<T> InitializeCollection(CustomCollectionType selectedCustomCollection, BasicCollectionType? selectedBasicCollection)
		{
			if (!selectedBasicCollection.HasValue || selectedCustomCollection == CustomCollectionType.None)
				throw new ArgumentException("Select all settings for the collection.");

			var container = CustomCollectionConfig<T>.Configure(selectedCustomCollection, selectedBasicCollection.Value);

			return container.Resolve<ICustomCollection<T>>();
		}
	}
}