using Autofac;
using Business.Helper;
using Business.Interfaces;
using Business.Queue;
using Business.Stack;

namespace Business
{
	/// <summary>
	/// Represents the functionality to configure the custom collections.
	/// </summary>
	/// <owner>Anton Petrenko</owner>
	/// <typeparam name="T"></typeparam>
	public static class CustomCollectionConfig<T>
	{
		/// <summary>
		/// Holds the container builder.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		private static ContainerBuilder container;

		/// <summary>
		/// Configures the instances.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <param name="selectedQueueStackType">The selected type of collection (queue/stack).</param>
		/// <param name="selectedArrayLinkedListType">The selected type of collection (array/linked list).</param>
		/// <returns>The instances.</returns>
		public static IContainer Configure(string selectedQueueStackType, string selectedArrayLinkedListType)
		{
			CustomCollectionConfig<T>.container = new ContainerBuilder();
			selectedArrayLinkedListType = selectedArrayLinkedListType.ToLower().Replace(" ", string.Empty);

			if (selectedQueueStackType == CollectionType.Stack.AsString())
				CustomCollectionConfig<T>.ConfigureStack(selectedArrayLinkedListType);
			else if (selectedQueueStackType == CollectionType.Queue.AsString())
				CustomCollectionConfig<T>.ConfigureQueue(selectedArrayLinkedListType);

			return container.Build();
		}

		/// <summary>
		/// Configures the queue collection.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		private static void ConfigureQueue(string selectedArrayLinkedListType)
		{
			if (selectedArrayLinkedListType == CollectionType.Array.AsString())
				container.RegisterType<ArrayQueue<T>>().As<ICustomCollection<T>>();
			else if (selectedArrayLinkedListType == CollectionType.LinkedList.AsString())
				container.RegisterType<LinkedListQueue<T>>().As<ICustomCollection<T>>();
		}

		/// <summary>
		/// Configures the stack collection.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		private static void ConfigureStack(string selectedArrayLinkedListType)
		{
			if (selectedArrayLinkedListType == CollectionType.Array.AsString())
				container.RegisterType<ArrayStack<T>>().As<ICustomCollection<T>>();
			else if (selectedArrayLinkedListType == CollectionType.LinkedList.AsString())
				container.RegisterType<LinkedListStack<T>>().As<ICustomCollection<T>>();
		}
	}
}