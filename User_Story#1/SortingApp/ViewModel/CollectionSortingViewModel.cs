using BusinessLayer;
using BusinessLayer.DataParser;
using BusinessLayer.Reader;
using BusinessLayer.SortingAlgorithms;
using BusinessLayer.Utilities.Parser.Interfaces;
using BusinessLayer.Utilities.Validator.Interfaces;
using BusinessLayer.Validator;
using BusinessLayer.Writer;
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
        private bool GetCanSortArray (object obj)
        {
            return !(this.UnSortedCollectionOfNumbers == null);
        }

        /// <summary>
        /// The handler.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private readonly CollectionSortHandler<T> handler;

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public event PropertyChangedEventHandler PropertyChanged;

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
        /// Gets the save command.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>The save command.</returns>
        public RelayCommand Save
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
            get
            {
                return new RelayCommand(this.SortArray, this.GetCanSortArray); 
            }
        }

        private void SortArray(object obj)
        {
            this.handler.Execute();
        }

        /// <summary>
        /// Gets or sets the sorted collection of numbers.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>The collection of numbers.</returns>
        public ObservableCollection<T> SortedCollectionOfNumbers { get; set; }

        /// <summary>
        /// The sorter.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private readonly CollectionSorter<T> sorter;

        /// <summary>
        /// The type of sort from enum.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private SortType type;

        /// <summary>
        /// Gets or sets the unsorted collection of numbers.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>The collection of numbers.</returns>
        public ObservableCollection<T> UnSortedCollectionOfNumbers { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionSortingViewModel{T}"/> class.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public CollectionSortingViewModel()
        {
            this.handler = new CollectionSortHandler<T>(new DataReader(new LocalFileValidator()), new DataWriter<T>(), sorter, new ArrayParser<T>());
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
