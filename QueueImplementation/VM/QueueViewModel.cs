using Business;
using Business.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ViewModel.Helper;

namespace ViewModel
{
    public sealed class QueueViewModel<T> : INotifyPropertyChanged
    {
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
            this.queue.Enqueue(number);
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

        public ObservableCollection<int> AllNumbers
        {
            set
            {
                this.numbers = value;
            }
            get
            {
                foreach (int number in queue)
                    this.numbers.Add(number);

                return this.numbers;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}