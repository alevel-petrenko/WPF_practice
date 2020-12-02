using System;
using System.Windows.Markup;

namespace Presentation
{
	/// <summary>
	/// Represents the enum binding extension.
	/// </summary>
	/// <owner>Anton Petrenko</owner>
	public sealed class EnumBindingSourceExtension : MarkupExtension
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="EnumBindingSourceExtension"/> class.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <param name="enumType">Type of the enum.</param>
		public EnumBindingSourceExtension(Type enumType)
		{
			if (enumType is null || !enumType.IsEnum)
				throw new ArgumentException("Enumaration type is incorrect.");

			this.EnumType = enumType;
		}

		/// <summary>
		/// Gets and sets the type of the enum.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <value>The type of the enum.</value>
		public Type EnumType { get; private set; }

		/// <summary>
		/// When implemented in a derived class, returns an object that is provided as the value of the target property for this markup extension.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <param name="serviceProvider">A service provider helper that can provide services for the markup extension.</param>
		/// <returns>The object value to set on the property where the extension is applied.</returns>
		public override object ProvideValue(IServiceProvider serviceProvider) => Enum.GetValues(this.EnumType);
	}
}