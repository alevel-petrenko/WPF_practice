using Business.Helper;
using Business.Helper.Enumeration;
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
	public sealed class CustomCollectionViewModel : MvxViewModel
	{
		/// <summary>
		/// Holds the collection.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		private ICustomCollection<int> collection;

		/// <summary>
		/// Holds the configuration creator.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		private readonly CollectionConfigCreator<int> configCreator;

		/// <summary>
		/// Holds the current element that will be processed.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		private int? elementToProcess;

		/// <summary>
		/// Holds the is choice possible.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		private bool isChoisePossible;

		/// <summary>
		/// Holds the message to display.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		private string message;

		/// <summary>
		/// Gets the add command.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <value>The add command.</value>
		public RelayCommand Add => new RelayCommand(this.AddNumber, this.CanAddNumber);

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

			this.RaisePropertyChanged(() => this.Collection);

			if (previousCount == 0)
				this.RestoreRemoveAndShowCommands();
		}

		/// <summary>
		/// Gets the possibility of adding new number.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <param name="obj">The object.</param>
		/// <returns><c>true</c> if adding new number is possible; otherwise, <c>false</c></returns>
		private bool CanAddNumber(object obj) => true;

		/// <summary>
		/// Gets the possibility of getting the number.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <param name="obj">The object.</param>
		/// <returns><c>true</c> if getting number is possible; otherwise, <c>false</c></returns>
		private bool CanGetNumber(object obj) => this.Collection != null && this.Collection.Count() > 0;

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
						this.collection = this.configCreator.InitializeCollection(this.SelectedCustomCollectionType, this.SelectedBasicCollectionType);
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
		/// Initializes a new instance of the <see cref="CustomCollectionViewModel"/> class.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		public CustomCollectionViewModel()
		{
			this.configCreator = new CollectionConfigCreator<int>();
			this.isChoisePossible = true;
		}

		/// <summary>
		/// Gets or sets the value indicating whether choice is still available.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <value><c>true</c> if the choice is still available; otherwise, <c>false</c>.</value>
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
		public RelayCommand Remove => new RelayCommand(this.RemoveNumber, this.CanGetNumber);

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

			this.RaisePropertyChanged(() => this.Collection);
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
			this.RaisePropertyChanged(() => this.Show);
			this.RaisePropertyChanged(() => this.Remove);
		}

		/// <summary>
		/// Gets or sets the selected type of the basic collection.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <value>The type of the basic collection.</value>
		public BasicCollectionType? SelectedBasicCollectionType { get; set; }

		/// <summary>
		/// Gets or sets the selected type of the custom collection.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <value>The type of the custom collection.</value>
		public CustomCollectionType? SelectedCustomCollectionType { get; set; }

		/// <summary>
		/// Gets the show command.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <value>The show command.</value>
		public RelayCommand Show => new RelayCommand(this.ShowNumber, this.CanGetNumber);

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