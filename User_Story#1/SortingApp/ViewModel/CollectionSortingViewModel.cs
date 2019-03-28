using BusinessLayer;
using BusinessLayer.DataParser;
using BusinessLayer.Reader;
using BusinessLayer.SortingAlgorithms;
using BusinessLayer.Utilities.Parser.Interfaces;
using BusinessLayer.Utilities.Validator.Interfaces;
using BusinessLayer.Validator;
using BusinessLayer.Writer;
using System.Collections.Generic;
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
        /// <summary>
        /// The handler.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private readonly CollectionSortHandler<T> handler;

        /// <summary>
        /// Stores the read.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private RelayCommand read;

        /// <summary>
        /// Gets the read command.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>The read command.</returns>
        public RelayCommand Read
        {
            get
            {
                if (this.read is null)
                    this.read = new RelayCommand(this.ReadArray);
                return this.read;
            }
        }

        /// <summary>
        /// Stores the save.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private RelayCommand save;

        /// <summary>
        /// Gets the save command.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>The save command.</returns>
        public RelayCommand Save
        {
            get
            {
                if (this.save is null)
                    this.save = new RelayCommand(this.SaveArray, this.GetCanSaveArray);
                return this.save;
            }
        }

        /// <summary>
        /// Stores the sort.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private RelayCommand sort;

        /// <summary>
        /// Gets the sort command.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>The sort command.</returns>
        public RelayCommand Sort
        {
            get
            {
                if (this.sort is null)
                    this.sort = new RelayCommand(this.SortArray, this.GetCanSortArray); 
                return this.sort;
            }
        }

        /// <summary>
        /// Gets or sets the sorted collection of numbers.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>The collection of numbers.</returns>
        public List<T> SortedCollectionOfNumbers { get; set; }

        /// <summary>
        /// The sorter.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private readonly CollectionSorter<T>sorter;

        /// <summary>
        /// The type of sort from enum.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public SortType Type
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the unsorted collection of numbers.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>The collection of numbers.</returns>
        public ObservableCollection<T> UnSortedCollectionOfNumbers { get; set; }

        /// <summary>
        /// Gets the can sort array.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        /// <owner>Anton Petrenko</owner>
        private bool GetCanSortArray(object obj)
        {
            return !(this.UnSortedCollectionOfNumbers == null);
        }

        /// <summary>
        /// Gets the can save array.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        /// <owner>Anton Petrenko</owner>
        private bool GetCanSaveArray(object obj)
        {
            return !(this.SortedCollectionOfNumbers == null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionSortingViewModel{T}"/> class.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public CollectionSortingViewModel()
        {
            this.handler = new CollectionSortHandler<T>(new DataReader(new LocalFileValidator()), new DataWriter<T>(), sorter, new ArrayParser<T>());
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Reads the array.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <owner>Anton Petrenko</owner>
        private void ReadArray(object obj)
        {
            handler.Read();
        }

        /// <summary>
        /// Sorts the array.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <owner>Anton Petrenko</owner>
        private void SortArray(object obj)
        {
            this.handler.Execute();
        }

        /// <summary>
        /// Saves the array.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <owner>Anton Petrenko</owner>
        private void SaveArray(object obj)
        {
            this.handler.Write();
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
