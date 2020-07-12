using Business;
using Business.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ViewModel.Helper;

namespace ViewModel
{
    public sealed class QueueViewModel<T> : INotifyPropertyChanged
    {
        private int currentNumber;

        public int CurrentNumber 
        {
            get => this.currentNumber;
            set
            {
                if (this.currentNumber == value)
                    return;

                this.currentNumber = value;
                this.OnPropertyChanged(nameof(this.CurrentNumber));
            }
        }

        /// <summary>
        /// Stores the read command.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        private RelayCommand add;

        /// <summary>
        /// Gets the read command.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <returns>The read command.</returns>
        public RelayCommand Add
        {
            get
            {
                if (this.add is null)
                    this.add = new RelayCommand(this.ReadArray);

                return this.add;
            }
        }

        /// <summary>
        /// Reads the array.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="obj">The object.</param>
        private void ReadArray(object obj)
        {
            this.AddNumber(RandomNumber.GetValue());
        }

        public QueueViewModel()
        {
            this.queue.Enqueue(1);
            this.queue.Enqueue(2);
            this.queue.Enqueue(3);
            this.queue.Enqueue(4);
            this.queue.Enqueue(5);
        }

        private ObservableCollection<int> numbers;
        private IQueueCollection<int> queue = new ArrayQueue<int>();
        private int queueType;

        private void AddNumber(int number)
        {
            this.CurrentNumber = number;
            this.queue.Enqueue(number);

            this.OnPropertyChanged(nameof(this.AllNumbers));
        }

        public int GetNumber
        {
            get
            {
                return this.queue.Peek();
            }
        }

        public int GetNumberAndDelete
        {
            get
            {
                return this.queue.Dequeue();
            }
        }

        public IQueueCollection<int> AllNumbers => this.queue;

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Calls PropertyChanged event.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="prop">Value, which need to be updated.</param>
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}