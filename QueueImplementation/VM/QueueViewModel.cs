using Autofac;
using Business;
using Business.Helper;
using Business.Interfaces;
using MvvmCross.ViewModels;
using System.Collections.ObjectModel;
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
		/// Holds the add value command.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		private RelayCommand add;

		/// <summary>
		/// Holds the all numbers.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		private ObservableCollection<int> allNumbers;

		/// <summary>
		/// Holds the current number that was processed.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		private int? currentNumber;

		/// <summary>
		/// Holds the queue collection.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		private readonly IQueueCollection<int> queue;

		/// <summary>
		/// Holds the remove value command.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		private RelayCommand remove;

		/// <summary>
		/// Holds the show value command.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		private RelayCommand show;

		/// <summary>
		/// Gets the add command.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <value>The add command.</value>
		public RelayCommand Add
		{
			get
			{
				if (this.add is null)
					this.add = new RelayCommand(this.AddNumber, this.CanAddNumber);

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
			this.queue.Enqueue(RandomNumber.GetValue());

			this.RaisePropertyChanged(() => this.AllNumbers);
		}

		/// <summary>
		/// Gets the collection of all numbers in the queue.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <value>The collection of all numbers in queue.</value>
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
		/// Gets the possibility of adding new number.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <param name="obj">The object.</param>
		/// <returns>True if adding new number is possible; otherwise, false</returns>
		private bool CanAddNumber(object obj) => this.AllNumbers != null;

		/// <summary>
		/// Gets the possibility of getting the number.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <param name="obj">The object.</param>
		/// <returns>True if getting number is possible; otherwise, false</returns>
		private bool CanGetNumber(object obj) => false;

		/// <summary>
		/// Initializes a new instance of the <see cref="QueueViewModel{T}"/> class.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		public QueueViewModel()
		{
			//
			// TODO: addhandling of choise array/linked list
			//
			var container = QueueCollectionConfig<int>.Configure();
			this.queue = container.Resolve<IQueueCollection<int>>();

			this.allNumbers = new ObservableCollection<int>();
		}

		/// <summary>
		/// Gets the remove command.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <value>The remove command.</value>
		public RelayCommand Remove
		{
			get
			{
				if (this.remove is null)
					this.remove = new RelayCommand(this.RemoveNumber, this.CanGetNumber);

				return this.remove;
			}
		}

		/// <summary>
		/// Removes the number from the queue collection.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <param name="obj">The object.</param>
		private void RemoveNumber(object obj)
		{
			this.CurrentNumber = this.queue.Dequeue();

			this.RaisePropertyChanged(() => this.AllNumbers);
			this.RaisePropertyChanged(() => this.CurrentNumber);
		}

		/// <summary>
		/// Gets the show command.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <value>The get command.</value>
		public RelayCommand Show
		{
			get
			{
				if (this.show is null)
					this.show = new RelayCommand(this.ShowNumber, this.CanGetNumber);

				return this.show;
			}
		}

		/// <summary>
		/// Shows the number.
		/// </summary>
		/// <ower>Anton Petrenko</owner>
		/// <param name="obj">The object.</param>
		private void ShowNumber(object obj)
		{
			this.CurrentNumber = this.queue.Peek();

			this.RaisePropertyChanged(() => this.CurrentNumber);
		}
	}
}