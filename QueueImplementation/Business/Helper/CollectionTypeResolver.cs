using Autofac;
using Business.Interfaces;

namespace Business.Helper
{
	class CollectionTypeResolver <T>
	{
		/// <summary>
		/// Initializes this instance.
		/// </summary>
		/// <returns></returns>
		/// <owner>Anton Petrenko</owner>
		public ICustomCollection<T> Initialize()
		{
			//
			// TODO: add handling of choise array/linked list
			//
			var container = CustomCollectionConfig<T>.Configure();
			var queue = container.Resolve<ICustomCollection<T>>();
			var stack = container.Resolve<ICustomCollection<T>>();

			return queue;
		}
	}
}