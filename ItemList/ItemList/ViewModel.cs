using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ItemList
{
    /// <summary>
    /// This is a class, that represents a ViewModel layer with all fields from View and logic how to handle requests from UI
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    public sealed class ViewModel : INotifyPropertyChanged, IDisposable
    {
        /// <summary>
        /// Stores an instance of RelayCommand to add.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private RelayCommand addCommand;
        /// <summary>
        /// Stores an instance of RelayCommand to delete.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private RelayCommand deleteCommand;
        /// <summary>
        /// Stores instance of selected Phone.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public Phone selectedItem;
        /// <summary>
        /// Initializes addCommand field.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>Instance of RelayCommand class.</returns>
        public RelayCommand AddCommand
        {
            get
            {
                if (this.addCommand != null)
                {
                    return this.addCommand;
                }
                this.addCommand = AddNewItemToCollection();
                return this.addCommand;
            }
        }
        /// <summary>
        /// Adds new item to Observable Collection of phones.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>Instance of RelayCommand class.</returns>
        private RelayCommand AddNewItemToCollection ()
        {
            return new RelayCommand(obj =>
            {
                this.ListOfItems.Add(new Phone { Manufacture = this.Manufacture, Model = this.Model });
                UpdateTextBoxes();
            });
        }
        /// <summary>
        /// Calls OnPropertyChanged event
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private void UpdateTextBoxes()
        {
            OnPropertyChanged("Manufacture");
            OnPropertyChanged("Model");
        }
        /// <summary>
        /// Method is used for clearing text boxes after adding values to the list.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Arguments</param>
        private void ClearField(object sender, PropertyChangedEventArgs e)
        {
            Manufacture = string.Empty;
            Model = string.Empty;
        }
        /// <summary>
        /// Gets delete command for collection of phones.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>Instance of RelayCommand class.</returns>
        public RelayCommand DeleteCommand
        {
            get
            {
                return this.deleteCommand ??
                    (this.deleteCommand = new RelayCommand(obj =>
                    {
                        this.ListOfItems.Remove(this.selectedItem);
                    }));
            }
        }
        /// <summary>
        /// Releases memory from event by removing subscription before closing app.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public void Dispose()
        {
            PropertyChanged -= ClearField;
        }
        /// <summary>
        /// Gets or sets collection of items.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public ObservableCollection<Phone> ListOfItems { get; set; }
        /// <summary>
        /// Gets or sets manufacture of the item.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>Manufacture name as a string.</returns>
        public string Manufacture { get; set; }
        /// <summary>
        /// Gets or sets model of the item.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>Model name as a string.</returns>
        public string Model { get; set; }
        /// <summary>
        /// Calls PropertyChanged event.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        /// <summary>
        /// Represents event type of PropertyChangedEventHandler
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Gets or sets selected item.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>Instance of the phone.</returns>
        public Phone SelectedItem
        {
            get { return selectedItem; }
            set
            {
                this.selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        /// <summary>
        /// Initializes new instance of ViewModel with ListOfItems and subscription for PropertyChanged event.
        /// </summary>
        public ViewModel()
        {
            this.ListOfItems = new ObservableCollection<Phone>();
            this.PropertyChanged += this.ClearField;
        }
    }
}