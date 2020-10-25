using Autofac;
using Business.Interfaces;

namespace Business
{
	/// <summary>
	/// Represents the functionality to configure the queue collections.
	/// </summary>
	/// <owner>Anton Petrenko</owner>
	/// <typeparam name="T"></typeparam>
	public static class QueueCollectionConfig<T>
	{
		/// <summary>
		/// Configures the instances.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <returns>The instances.</returns>
		public static IContainer Configure()
		{
			var container = new ContainerBuilder();

			container.RegisterType<ArrayQueue<T>>().As<IQueueCollection<T>>();
			container.RegisterType<LinkedListQueue<T>>().As<IQueueCollection<T>>();

			return container.Build();
		}
	}
}