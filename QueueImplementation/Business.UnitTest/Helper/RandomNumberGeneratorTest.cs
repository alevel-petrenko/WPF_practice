using Business.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Business.UnitTest.Helper
{
	/// <summary>
	/// Represents tests for <see cref="RandomNumberGenerator"/>.
	/// </summary>
	/// <owner>Anton Petrenko</owner>
	[TestClass]
	public class RandomNumberGeneratorTest
	{
		/// <summary>
		/// Tests getting new value, these values are not the same.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		[TestMethod]
		public void RandomNumberGenerator_GetValue_GetSeveralValues_ValuesAreDifferent()
		{
			//
			// Act.
			//
			int firstValue = RandomNumberGenerator.GetValue();
			int secondValue = RandomNumberGenerator.GetValue();

			//
			// Assert.
			//
			Assert.AreNotEqual(firstValue, secondValue);
		}
	}
}