namespace Business.Helper
{
	/// <summary>
	/// Represents functionality for getting caption for the collection type.
	/// </summary>
	/// <owner>Anton Petrenko</owner>
	public static class CollectionTypeExtension
	{
		/// <summary>
		/// Represents the collection type as string.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <param name="type">The collection type.</param>
		/// <returns>The collection type as string.</returns>
		public static string AsString(this CollectionType type) => type.ToString().ToLower();
	}
}