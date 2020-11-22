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
	/// Represents the view model used for managing the collection.
	/// </summary>
	/// <owner>Anton Petrenko</owner>
	public sealed class CustomCollectionViewModel<T> : MvxViewModel
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
		/// Holds the collection.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		private ICustomCollection<int> collection;

		/// <summary>
		/// Holds the configuration creator.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		private readonly CollectionConfigCreator<int> configCreator = new CollectionConfigCreator<int>();

		/// <summary>
		/// Holds the current element that will be processed.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		private int? elementToProcess;

		/// <summary>
		/// Holds the is choise possible.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		private bool isChoisePossible = true;

		/// <summary>
		/// Holds the message to display.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		private string message;

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
		/// Adds the number to the collection.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <param name="obj">The object.</param>
		private void AddNumber(object obj)
		{
			if (this.Collection is null)
				return;

			int previousCount = this.Collection.Count();
			this.RestoreCurrentElement();
			int newValue = RandomNumberGenerator.GetValue();
			this.Collection.Add(newValue);
			this.Message = $"The item {newValue} was added.";

			this.RaisePropertyChanged(() => this.AllNumbers);

			if (previousCount == 0)
				this.RestoreRemoveAndShowCommands();
		}

		/// <summary>
		/// Gets the collection of all numbers.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <value>The collection of all numbers.</value>
		public IEnumerable<int> AllNumbers
		{
			get
			{
				if (this.allNumbers != null && this.Collection != null && this.allNumbers.SequenceEqual(this.Collection))
					return this.allNumbers;

				if (this.Collection != null)
				this.allNumbers = new ObservableCollection<int>(this.Collection);
				else
					this.allNumbers = new ObservableCollection<int>();

				return this.allNumbers;
			}
		}

		/// <summary>
		/// Gets the possibility of adding new number.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <param name="obj">The object.</param>
		/// <returns><c>true</c> if adding new number is possible; otherwise, <c>false</c></returns>
		private bool CanAddNumber(object obj) => this.AllNumbers != null;

		/// <summary>
		/// Gets the possibility of getting the number.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <param name="obj">The object.</param>
		/// <returns><c>true</c> if getting number is possible; otherwise, <c>false</c></returns>
		private bool CanGetNumber(object obj) => this.AllNumbers.Count() > 0;

		/// <summary>
		/// Gets the collection.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <value>The collection.</value>
		public ICustomCollection<int> Collection
		{
			get
			{
				try
				{
					if (this.collection is null)
					{
						this.collection = this.configCreator.InitializeCollection(this.SelectedQueueStackType, this.SelectedArrayLinkedListType);
						this.IsChoiseAvailable = false;
					}
				}
				catch (ArgumentException error)
				{
					this.Message = error.Message;
				}

				return this.collection;
			}
		}

		/// <summary>
		/// Gets the collection types.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <value>The collection types.</value>
		public string[] CollectionTypes => new string[] { "stack", "queue" };

		/// <summary>
		/// Gets or sets the current element.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <value>The current number.</value>
		public int? CurrentElement
		{
			get => this.elementToProcess;
			set
			{
				if (this.elementToProcess == value)
					return;

				this.elementToProcess = value;
				this.RaisePropertyChanged(() => this.CurrentElement);
			}
		}

		/// <summary>
		/// Gets or sets the value indicating whether choise is still available.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <value><c>true</c> if the choise is still available; otherwise, <c>false</c>.</value>
		public bool IsChoiseAvailable 
		{
			get
			{
				return this.isChoisePossible;
			}
			set
			{
				if (this.isChoisePossible == value)
					return;

				this.isChoisePossible = value;
				this.RaisePropertyChanged(() => this.IsChoiseAvailable);
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
		/// Removes the number from the collection.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <param name="obj">The object.</param>
		private void RemoveNumber(object obj)
		{
			try
			{
				this.RestoreCurrentElement();
				var removedItem = this.Collection.Remove();
				this.Message = $"The item {removedItem} was removed.";
			}
			catch (InvalidOperationException ex)
			{
				this.Message = ex.Message;
			}

			if (this.Collection.Count() == 0)
			{
				this.Message += " The collection is empty.";
				this.RestoreRemoveAndShowCommands();
			}

			this.RaisePropertyChanged(() => this.AllNumbers);
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
		/// Gets or sets the selected type of the collection (array/linked list).
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <value>The type of the selected array linked list.</value>
		public string SelectedArrayLinkedListType { get; set; }

		/// <summary>
		/// Gets or sets the selected type of the collection (queue/stack).
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <value>The type of the selected queue stack.</value>
		public string SelectedQueueStackType { get; set; }

		/// <summary>
		/// Gets and sets the show command.
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
				this.CurrentElement = this.Collection.ShowCurrent();
				this.Message = $"The item {this.CurrentElement} is first to be removed.";
			}
			catch (InvalidOperationException ex)
			{
				this.Message = ex.Message;
			}
		}
	}
}