using System;
using BusinessLayer;
using BusinessLayer.DataParser;
using BusinessLayer.Reader;
using BusinessLayer.Validator;
using BusinessLayer.Writer;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ViewModel.Enum;

namespace ViewModel
{
    /// <summary>
    /// Represents a ViewModel layer with all fields from View and logic how to handle requests from UI.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    /// <typeparam name="T">Certain input type.</typeparam>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public class CollectionSortingViewModel<T> : INotifyPropertyChanged where T : IComparable
    {
        /// <summary>
        /// The handler.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private readonly CollectionSortHandler<T> handler;

        /// <summary>
        /// Gets or sets the message for display.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <value>The message received from exception.</value>
        public string Message { get; private set; }

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
                if (read is null)
                    read = new RelayCommand(ReadArray);
                return read;
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
                if (save is null)
                    save = new RelayCommand(SaveArray, GetCanSaveArray);
                return save;
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
                if (sort is null)
                    sort = new RelayCommand(SortArray, GetCanSortArray);
                return sort;
            }
        }

        /// <summary>
        /// Gets or sets the sorted collection of numbers.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>The collection of numbers.</returns>
        public ObservableCollection<T> SortedCollectionOfNumbers { get; set; }

        /// <summary>
        /// The type of sort from enum.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public SortType SortType { get; set; }

        /// <summary>
        /// Gets or sets the unsorted collection of numbers.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>The collection of numbers.</returns>
        public ObservableCollection<T> UnSortedCollectionOfNumbers { get; set; }

        /// <summary>
        /// Gets the can save array.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        /// <owner>Anton Petrenko</owner>
        private bool GetCanSaveArray(object obj)
        {
            return !(SortedCollectionOfNumbers.Count == 0);
        }

        /// <summary>
        /// Gets the can sort array.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        /// <owner>Anton Petrenko</owner>
        private bool GetCanSortArray(object obj)
        {
            return (this.UnSortedCollectionOfNumbers.Count != 0 && this.SortType is SortType valueOfSortType);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionSortingViewModel{T}"/> class.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public CollectionSortingViewModel()
        {
            handler = new CollectionSortHandler<T>
                (new DataReader(new LocalFileValidator()), new DataWriter<T>(), new ArrayParser<T>());
            UnSortedCollectionOfNumbers = new ObservableCollection<T>();
            SortedCollectionOfNumbers = new ObservableCollection<T>();
        }

        /// <summary>
        /// Calls PropertyChanged event.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
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
            try
            {
                handler.Read();
                UnSortedCollectionOfNumbers.Clear();
                foreach (var number in handler.UnSortedCollection)
                {
                    UnSortedCollectionOfNumbers.Add(number);
            
                }
            }
            catch (ArgumentNullException e)
            {
                Message = e.Message;
            }
        }

        /// <summary>
        /// Sorts the array.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <owner>Anton Petrenko</owner>
        private void SortArray(object obj)
        {
            handler.GenerateSorter(SortType.ToString());
            handler.Execute();
            SortedCollectionOfNumbers.Clear();
            foreach (var number in handler.SortedCollection)
            {
                SortedCollectionOfNumbers.Add(number);
            }
        }

        /// <summary>
        /// Saves the array.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <owner>Anton Petrenko</owner>
        private void SaveArray(object obj)
        {
            handler.Write();
        }
    }
}
