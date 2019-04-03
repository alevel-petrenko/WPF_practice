using System;
using BusinessLayer;
using BusinessLayer.DataParser;
using BusinessLayer.Reader;
using BusinessLayer.Validator;
using BusinessLayer.Writer;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Helper;
using System.Linq;

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
        /// Stores the error message.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private string message;

        /// <summary>
        /// Stores the read command.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private RelayCommand read;

        /// <summary>
        /// Stores the save command.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private RelayCommand save;

        /// <summary>
        /// Stores the sort command.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private RelayCommand sort;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionSortingViewModel{T}"/> class.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public CollectionSortingViewModel()
        {
            this.handler = new CollectionSortHandler<T>
                (new DataReader(new LocalFileValidator()), new DataWriter<T>(), new ArrayParser<T>());
            this.UnSortedCollectionOfNumbers = new ObservableCollection<T>();
            this.SortedCollectionOfNumbers = new ObservableCollection<T>();
        }

        /// <summary>
        /// Gets the can save array.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        /// <owner>Anton Petrenko</owner>
        private bool GetCanSaveArray(object obj)
        {
            return this.SortedCollectionOfNumbers.Any();
        }

        /// <summary>
        /// Gets the can sort array.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        /// <owner>Anton Petrenko</owner>
        private bool GetCanSortArray(object obj)
        {
            return (this.UnSortedCollectionOfNumbers.Any() && this.SortType is SortType valueOfSortType);
        }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <value>The message received from exception.</value>
        public string Message
        {
            get { return this.message; }
            set
            {
                this.message = value;
                this.OnPropertyChanged("Message");
            }
        }

        /// <summary>
        /// Calls PropertyChanged event.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="prop">Value, which need to be updated.</param>
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

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
            get
            {
                if (this.read is null)
                    this.read = new RelayCommand(ReadArray);

                return this.read;
            }
        }

        /// <summary>
        /// Reads the array.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="obj">The object.</param>
        private void ReadArray(object obj)
        {
            try
            {
                this.handler.Read();
                this.UnSortedCollectionOfNumbers.Clear();
                foreach (var number in this.handler.UnSortedCollection)
                    this.UnSortedCollectionOfNumbers.Add(number);

                this.Message = "Array successfully read.";
            }
            catch (Exception e)
            {
                this.Message = e.Message;
            }
        }

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
        /// Saves the array.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <owner>Anton Petrenko</owner>
        private void SaveArray(object obj)
        {
            try
            {
                this.handler.Write();
                this.Message = "Successfully saved to file.";
            }
            catch (Exception e)
            {
                this.Message = e.Message;
            }
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
                if (this.sort is null)
                    this.sort = new RelayCommand(this.SortArray, this.GetCanSortArray);

                return this.sort;
            }
        }

        /// <summary>
        /// Sorts the array.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <owner>Anton Petrenko</owner>
        private void SortArray(object obj)
        {
            try
            {
                this.handler.GenerateSorter(SortType);
                this.handler.Execute();
                this.SortedCollectionOfNumbers.Clear();
                foreach (var number in this.handler.SortedCollection)
                    this.SortedCollectionOfNumbers.Add(number);

                this.Message = "Array successfully sorted.";
            }
            catch (Exception e)
            {
                this.Message = e.Message;
            }
        }

        /// <summary>
        /// Gets or sets the sorted collection of numbers.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>The collection of numbers.</returns>
        public ObservableCollection<T> SortedCollectionOfNumbers { get; set; }

        /// <summary>
        /// Gets or sets the type of a sort algorithm.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public SortType SortType { get; set; }

        /// <summary>
        /// Gets or sets the unsorted collection of numbers.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>The collection of numbers.</returns>
        public ObservableCollection<T> UnSortedCollectionOfNumbers { get; set; }
    }
}
