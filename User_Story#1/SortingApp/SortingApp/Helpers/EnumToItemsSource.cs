using System;
using System.Linq;
using System.Windows.Markup;

namespace SortingApp.Helpers
{
    /// <summary>
    /// Represents enum items as source value.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <seealso cref="System.Windows.Markup.MarkupExtension" />
    public class EnumToItemsSource : MarkupExtension
    {
        /// <summary>
        /// Holds the type of enum.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private readonly Type type;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumToItemsSource" /> class.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="type">The type of enum.</param>
        public EnumToItemsSource(Type type)
        {
            this.type = type;
        }

        /// <summary>
        /// Provides the value of enum's item.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>
        /// Object with value of enum's item.
        /// </returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(this.type)
                .Cast<object>()
                .Select(e => new { Value = e, DisplayName = e.ToString() });
        }
    }
}
