using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ItemList
{
    /// <summary>
    /// This is a class, that represents a ViewModel layer with all fields from View and logic how to handle requests from UI.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    public sealed class ViewModel : INotifyPropertyChanged
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
        /// <returns>The add command.</returns>
        public RelayCommand AddCommand
        {
            get
            {
                if (this.addCommand is null)
                    this.addCommand = new RelayCommand(this.AddPhone, this.GetCanExecuteAddCommand);
                
                return this.addCommand;
            }
        }

        /// <summary>
        /// Gets the can execute add command.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        private bool GetCanExecuteAddCommand(object obj)
        {
            return !(string.IsNullOrEmpty(this.Manufacture) || string.IsNullOrEmpty(this.Model));
        }

        /// <summary>
        /// Adds the phone.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        private void AddPhone(object obj)
        {
            this.ListOfItems.Add(new Phone { Manufacture = this.Manufacture, Model = this.Model });
            this.ClearField();
            this.UpdateTextBoxes();
        }

        /// <summary>
        /// Clears the phone's view model state.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private void ClearField()
        {
            this.Manufacture = string.Empty;
            this.Model = string.Empty;
        }
        
        /// <summary>
        /// Gets delete command for collection of phones.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>The delete command.</returns>
        public RelayCommand DeleteCommand
        {
            get
            {
                if (this.deleteCommand == null)
                    this.deleteCommand = new RelayCommand(this.DeletePhone, this.IsDeleteAvailable);

                return this.deleteCommand;
            }
        }

        /// <summary>
        /// Deletes the phone.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        private void DeletePhone(object obj)
        {
            this.ListOfItems.Remove(this.SelectedItem);
        }

        /// <summary>
        /// Determines whether the delete is available.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>
        ///   <c>true</c> if [is delete available] [the specified object]; otherwise, <c>false</c>.
        /// </returns>
        /// <owner>Aleksey Beletsky</owner>
        private bool IsDeleteAvailable(object obj)
        {
            return this.ListOfItems.Any() && this.SelectedItem != null;
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
        /// <returns>Manufacture name of the phone.</returns>
        public string Manufacture { get; set; }

        /// <summary>
        /// Gets or sets model of the item.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>Model name of the phone.</returns>
        public string Model { get; set; }
        
        /// <summary>
        /// Calls PropertyChanged event.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        
        /// <summary>
        /// Represents event type of PropertyChangedEventHandler.
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
            get { return this.selectedItem; }
            set
            {
                if (this.selectedItem == value)
                    return;

                this.selectedItem = value;
                this.OnPropertyChanged(nameof(this.SelectedItem));
            }
        }

        /// <summary>
        /// Notifies about changing the Model and the Manufacture.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private void UpdateTextBoxes()
        {
            this.OnPropertyChanged(nameof(this.Manufacture));
            this.OnPropertyChanged(nameof(this.Model));
        }

        /// <summary>
        /// Initializes new instance of ViewModel with ListOfItems.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public ViewModel()
        {
            this.ListOfItems = new ObservableCollection<Phone>();
        }
    }
}