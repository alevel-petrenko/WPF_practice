using Autofac;
using Business;
using Business.Helper;
using Business.Interfaces;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ViewModel
{
	/// <summary>
	/// Represents the view model used for managing the queue collection.
	/// </summary>
	/// <owner>Anton Petrenko</owner>
	public sealed class CustomCollectionViewModel<T> : MvxViewModel
	{
		/// <summary>
		/// Holds the array type.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		private const string ArrayType = "Array";

		/// <summary>
		/// Holds the linked list type.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		private const string LinkedListType = "Linked list";

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
		/// Holds the current element that will be processed.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		private int? currentElement;

		/// <summary>
		/// Holds the message to display.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		private string message;

		/// <summary>
		/// Holds the queue collection.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		private readonly ICustomCollection<int> queue;

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
			set
			{
				if (this.add == value)
					return;

				this.add = value;
				this.RaisePropertyChanged(() => this.Add);
			}
		}

		/// <summary>
		/// Adds the number to the queue collection.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <param name="obj">The object.</param>
		private void AddNumber(object obj)
		{
			int previousCount = this.queue.Count();

			this.RestoreCurrentElement();
			int newValue = RandomNumberGenerator.GetValue();
			this.queue.Add(newValue);
			this.Message = $"The item {newValue} was added.";

			this.RaisePropertyChanged(() => this.AllNumbers);

			if (previousCount == 0)
				this.RestoreRemoveAndShowCommands();
		}

		/// <summary>
		/// Gets the collection of all numbers in the queue.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <value>The collection of all numbers in queue.</value>
		public IEnumerable<int> AllNumbers
		{
			get
			{
				if (this.allNumbers.SequenceEqual(this.queue))
					return this.allNumbers;

				this.allNumbers = new ObservableCollection<int>(this.queue);
				return this.allNumbers;
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
		private bool CanGetNumber(object obj) => this.AllNumbers.Count() > 0;

		/// <summary>
		/// Gets or sets the current element.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <value>The current number.</value>
		public int? CurrentElement
		{
			get => this.currentElement;
			set
			{
				if (this.currentElement == value)
					return;

				this.currentElement = value;
				this.RaisePropertyChanged(() => this.CurrentElement);
			}
		}

		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <value>The message.</value>
		public string Message
		{
			get
			{
				return this.message;
			}
			set
			{
				this.message = value;
				this.RaisePropertyChanged(() => this.Message);
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CustomCollectionViewModel{T}"/> class.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		public CustomCollectionViewModel()
		{
			var container = CustomCollectionConfig<T>.Configure();
			this.queue = container.Resolve<ICustomCollection<int>>();
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
			set
			{
				if (this.remove == value)
					return;

				this.remove = value;
				this.RaisePropertyChanged(() => this.Remove);
			}
		}

		/// <summary>
		/// Removes the number from the queue collection.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <param name="obj">The object.</param>
		private void RemoveNumber(object obj)
		{
			try
			{
				this.RestoreCurrentElement();
				var removedItem = this.queue.Remove();
				this.Message = $"The item {removedItem} was removed.";
			}
			catch (InvalidOperationException ex)
			{
				this.Message = ex.Message;
			}

			if (this.queue.Count() == 0)
			{
				this.Message += " The collection is empty.";
				this.RestoreRemoveAndShowCommands();
			}

			this.RaisePropertyChanged(() => this.AllNumbers);
		}

		/// <summary>
		/// Restores the remove and show commands.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		private void RestoreRemoveAndShowCommands()
		{
			this.Show = null;
			this.Remove = null;
		}

		/// <summary>
		/// Restores the current element.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		private void RestoreCurrentElement()
		{
			if (this.CurrentElement.HasValue)
				this.CurrentElement = null;
		}

		public ObservableCollection<string> CollectionTypes
		{ get; set; } = new ObservableCollection<string> { "stack", "queue" };

		/// <summary>
		/// Gets the show command.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <value>The show command.</value>
		public RelayCommand Show
		{
			get
			{
				if (this.show is null)
					this.show = new RelayCommand(this.ShowNumber, this.CanGetNumber);

				return this.show;
			}
			set
			{
				if (this.show == value)
					return;

				this.show = value;
				this.RaisePropertyChanged(() => this.Show);
			}
		}

		/// <summary>
		/// Shows the number.
		/// </summary>
		/// <ower>Anton Petrenko</owner>
		/// <param name="obj">The object.</param>
		private void ShowNumber(object obj)
		{
			try
			{
				this.CurrentElement = this.queue.ShowCurrent();
				this.Message = $"The item {this.CurrentElement} is first to be removed.";
			}
			catch (InvalidOperationException ex)
			{
				this.Message = ex.Message;
			}
		}

		/// <summary>
		/// Gets or sets the source collection name.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <value>The source collection name.</value>
		public string SourceCollectionName
		{
			get;
			set;
		}
	}
}