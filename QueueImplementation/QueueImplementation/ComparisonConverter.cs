using System;
using System.Globalization;
using System.Windows.Data;

namespace Presentation
{
	/// <summary>
	/// Represents the converter logic.
	/// </summary>
	/// <owner>Anton Petrenko</owner>
	public class ComparisonConverter : IValueConverter
    {
		/// <summary>
		/// Converts a value.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <param name="value">The value produced by the binding source.</param>
		/// <param name="targetType">The type of the binding target property.</param>
		/// <param name="parameter">The converter parameter to use.</param>
		/// <param name="culture">The culture to use in the converter.</param>
		/// <returns>A converted value. If the method returns <see langword="null" />, the valid null value is used.</returns>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value?.Equals(parameter);

		/// <summary>
		/// Converts a value.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <param name="value">The value that is produced by the binding target.</param>
		/// <param name="targetType">The type to convert to.</param>
		/// <param name="parameter">The converter parameter to use.</param>
		/// <param name="culture">The culture to use in the converter.</param>
		/// <returns>A converted value. If the method returns <see langword="null" />, the valid null value is used.</returns>
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
			if (value is null)
				return Binding.DoNothing;

            return value.Equals(true) ? parameter : Binding.DoNothing;
        }
    }
}