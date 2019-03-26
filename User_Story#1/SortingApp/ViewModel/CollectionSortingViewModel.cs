using BusinessLayer;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ViewModel
{
    /// <summary>
    /// Represents a ViewModel layer with all fields from View and logic how to handle requests from UI.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <owner>Anton Petrenko</owner>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public class CollectionSortingViewModel<T> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the collection of numbers.
        /// </summary>
        /// <returns>
        /// The collection of numbers.
        /// </returns>
        /// <owner>Anton Petrenko</owner>
        public ObservableCollection<T> CollectionOfNumbers { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionSortingViewModel{T}"/> class.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public CollectionSortingViewModel()
        {
            this.CollectionOfNumbers = new ObservableCollection<T>();
        }

        /// <summary>
        /// The type of sort
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private SortType type;

        private CollectionSortHandler<T> handler;

        /// <summary>
        /// Gets the read command.
        /// </summary>
        /// <returns>
        /// The read command.
        /// </returns>
        /// <owner>Anton Petrenko</owner>
        public RelayCommand Read
        {
            get;
        }

        public RelayCommand Sort
        {
            get;
        }

        public RelayCommand Save
        {
            get;
        }
    }

    public enum SortType
    {
        InsertionSorter,
        SelectionSorter,
        QuickSorter
    }
}
