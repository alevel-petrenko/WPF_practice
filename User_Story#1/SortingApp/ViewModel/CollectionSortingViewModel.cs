using BusinessLayer;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ViewModel
{
    /// <summary>
    /// Represents a ViewModel layer with all fields from View and logic how to handle requests from UI.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public class CollectionSortingViewModel<T> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the collection of numbers.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>The collection of numbers.</returns>
        public ObservableCollection<T> CollectionOfNumbers { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionSortingViewModel{T}"/> class.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public CollectionSortingViewModel(CollectionSortHandler<T> handler)
        {
            this.CollectionOfNumbers = new ObservableCollection<T>();
            this.handler = handler;
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
        /// <owner>Anton Petrenko</owner>
        /// <returns>The read command.</returns>
        public RelayCommand Read
        {
            get;
        }

        /// <summary>
        /// Gets the sort command.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>The sort command.</returns>
        public RelayCommand Sort
        {
            get;
        }

        /// <summary>
        /// Gets the save command.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>The save command.</returns>
        public RelayCommand Save
        {
            get;
        }
    }

    /// <summary>
    /// Stores types of sort.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    public enum SortType
    {
        InsertionSorter,
        SelectionSorter,
        QuickSorter
    }
}
