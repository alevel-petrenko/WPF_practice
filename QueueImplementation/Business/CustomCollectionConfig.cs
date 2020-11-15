using Autofac;
using Business.Interfaces;
using Business.Queue;

namespace Business
{
	/// <summary>
	/// Represents the functionality to configure the queue collections.
	/// </summary>
	/// <owner>Anton Petrenko</owner>
	/// <typeparam name="T"></typeparam>
	public static class CustomCollectionConfig<T>
	{
		/// <summary>
		/// Configures the instances.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <returns>The instances.</returns>
		public static IContainer Configure()
		{
			var container = new ContainerBuilder();

			container.RegisterType<ArrayQueue<T>>().As<ICustomCollection<T>>();
			container.RegisterType<LinkedListQueue<T>>().As<ICustomCollection<T>>();

			return container.Build();
		}
	}
}