using System.Collections.ObjectModel;
using System.ComponentModel;
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
                if (this.addCommand != null)
                {
                    return this.addCommand;
                }
                this.addCommand = this.AddNewItemToCollection();
                return this.addCommand;
            }
        }

        /// <summary>
        /// Command adds new item to Observable Collection of phones and cleans phone's view model state.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>Instance of RelayCommand class.</returns>
        private RelayCommand AddNewItemToCollection ()
        {
            return new RelayCommand(obj =>
            {
                this.ListOfItems.Add(new Phone { Manufacture = this.Manufacture, Model = this.Model });
                this.ClearField();
                this.UpdateTextBoxes();
            });
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
                return this.deleteCommand ??
                    (this.deleteCommand = new RelayCommand(obj =>
                    {
                        this.ListOfItems.Remove(this.selectedItem);
                    }));
            }
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
                if (this.selectedItem!=value)
                this.selectedItem = value;
                this.OnPropertyChanged("SelectedItem");
            }
        }

        /// <summary>
        /// Notifies about changing the Model and the Manufacture.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private void UpdateTextBoxes()
        {
            this.OnPropertyChanged("Manufacture");
            this.OnPropertyChanged("Model");
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