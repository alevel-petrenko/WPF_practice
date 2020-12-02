using Autofac;
using Business.Helper.Enumeration;
using Business.Interfaces;
using Business.Queue;
using Business.Stack;

namespace Business
{
	/// <summary>
	/// Represents the functionality to configure the custom collections.
	/// </summary>
	/// <owner>Anton Petrenko</owner>
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
		public static IContainer Configure(CustomCollectionType selectedQueueStackType, BasicCollectionType selectedArrayLinkedListType)
		{
			CustomCollectionConfig<T>.container = new ContainerBuilder();

			if (selectedQueueStackType == CustomCollectionType.Stack)
				CustomCollectionConfig<T>.ConfigureStack(selectedArrayLinkedListType);
			else if (selectedQueueStackType == CustomCollectionType.Queue)
				CustomCollectionConfig<T>.ConfigureQueue(selectedArrayLinkedListType);

			return CustomCollectionConfig<T>.container.Build();
		}

		/// <summary>
		/// Configures the queue collection.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <param name="selectedArrayLinkedListType">The selected type of collection (array/linked list).</param>
		private static void ConfigureQueue(BasicCollectionType selectedArrayLinkedListType)
		{
			if (selectedArrayLinkedListType == BasicCollectionType.Array)
				CustomCollectionConfig<T>.container.RegisterType<ArrayQueue<T>>().As<ICustomCollection<T>>();
			else if (selectedArrayLinkedListType == BasicCollectionType.LinkedList)
				CustomCollectionConfig<T>.container.RegisterType<LinkedListQueue<T>>().As<ICustomCollection<T>>();
		}

		/// <summary>
		/// Configures the stack collection.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <param name="selectedArrayLinkedListType">The selected type of collection (array/linked list).</param>
		private static void ConfigureStack(BasicCollectionType selectedArrayLinkedListType)
		{
			if (selectedArrayLinkedListType == BasicCollectionType.Array)
				CustomCollectionConfig<T>.container.RegisterType<ArrayStack<T>>().As<ICustomCollection<T>>();
			else if (selectedArrayLinkedListType == BasicCollectionType.LinkedList)
				CustomCollectionConfig<T>.container.RegisterType<LinkedListStack<T>>().As<ICustomCollection<T>>();
		}
	}
}