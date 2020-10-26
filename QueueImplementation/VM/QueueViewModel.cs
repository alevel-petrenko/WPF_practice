using Autofac;
using Business;
using Business.Helper;
using Business.Interfaces;
using MvvmCross.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace ViewModel
{
	/// <summary>
	/// Represents the view model used for managing the queue collection.
	/// </summary>
	/// <owner>Anton Petrenko</owner>
	public sealed class QueueViewModel<T> : MvxViewModel
    {
        /// <summary>
        /// Holds the add command.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private RelayCommand add;

        /// <summary>
        /// Holds the all numbers.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private ObservableCollection<int> allNumbers;

        /// <summary>
        /// Holds the current number to be add to the collection.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private int? currentNumber;

        /// <summary>
        /// Holds the queue collection.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private IQueueCollection<int> queue;

        /// <summary>
        /// Gets the add command.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>The add command.</returns>
        public RelayCommand Add
        {
            get
            {
                if (this.add is null)
                    this.add = new RelayCommand(this.AddNumber);

                return this.add;
            }
        }

        /// <summary>
        /// Adds the number to the queue collection.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="obj">The object.</param>
        private void AddNumber(object obj)
        {
            int number = RandomNumber.GetValue();
            this.CurrentNumber = number;
            this.queue.Enqueue(number);

            this.RaisePropertyChanged(() => this.AllNumbers);
        }

        /// <summary>
        /// Gets the collection of all numbers in queue.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>The collection of all numbers in queue.</returns>
        public ObservableCollection<int> AllNumbers
        {
            get
            {
                if (Enumerable.SequenceEqual(this.allNumbers.OrderBy(number => number), this.queue.OrderBy(num => num)))
                    return this.allNumbers;

                this.allNumbers = new ObservableCollection<int>(this.queue);
                return this.allNumbers;
            }
        }

        /// <summary>
        /// Gets or sets the current number.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <value>The current number.</value>
        public int? CurrentNumber
        {
            get => this.currentNumber;
            set
            {
                if (this.currentNumber == value)
                    return;

                this.currentNumber = value;
                this.RaisePropertyChanged(() => this.CurrentNumber);
            }
        }

        /// <summary>
        /// Gets the number.
        /// </summary>
        /// <ower>Anton Petrenko</owner>
        /// <value>The number.</value>
        public int GetNumber
        {
            get
            {
                return this.queue.Peek();
            }
        }

        /// <summary>
        /// Gets the number and delete it from the queue.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <value>The number from the queue.</value>
        public int GetNumberAndDelete
        {
            get
            {
                return this.queue.Dequeue();
            }
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="QueueViewModel{T}"/> class.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		public QueueViewModel()
        {
			var container = QueueCollectionConfig<int>.Configure();
            this.queue = container.Resolve<IQueueCollection<int>>();

            this.allNumbers = new ObservableCollection<int>();
        }
    }
}