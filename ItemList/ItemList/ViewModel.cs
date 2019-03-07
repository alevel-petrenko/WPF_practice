using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ItemList
{
    /// <summary>
    /// This is a class, that represents a ViewModel layer with all fields from View and logic how to handle requests from UI
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    internal sealed class ViewModel : INotifyPropertyChanged
    {
        private RelayCommand addCommand;
        private RelayCommand deleteCommand;
        public Phone selectedItem;
        //
        // Command adds items to collection of phones.
        //
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        ListOfItems.Add(new Phone { Manufacture = this.Manufacture, Model = this.Model });
                        OnPropertyChanged("Manufacture");
                        OnPropertyChanged("Model");
                    }));
            }
        }
        //
        // Method is used for clearing text boxes after adding values to the list.
        //
        private void ClearField(object sender, PropertyChangedEventArgs e)
        {
            Manufacture = string.Empty;
            Model = string.Empty;
        }
        //
        // Command deletes items to collection of phones.
        //
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                    (deleteCommand = new RelayCommand(obj =>
                    {
                        ListOfItems.Remove(selectedItem);
                    }));
            }
        }

        public ObservableCollection<Phone> ListOfItems { get; set; }

        public string Manufacture { get; set; }

        public string Model { get; set; }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        public Phone SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public ViewModel()
        {
            ListOfItems = new ObservableCollection<Phone>
            {
                new Phone { Manufacture ="Samsung", Model = "S10"}
            };
            PropertyChanged += ClearField;
        }
    }
}
