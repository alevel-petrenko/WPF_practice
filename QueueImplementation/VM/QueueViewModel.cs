using Business;
using Business.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ViewModel
{
    public sealed class QueueViewModel : INotifyPropertyChanged
    {
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

        public int AddNumber
        {
            set
            {
                this.queue.Enqueue(value);
            }
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