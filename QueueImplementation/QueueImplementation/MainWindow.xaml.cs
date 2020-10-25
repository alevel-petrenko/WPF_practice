using System.Windows;
using ViewModel;

namespace QueueImplementation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    public partial class MainWindow : Window
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="MainWindow"/> class.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		public MainWindow()
        {
            InitializeComponent();
            DataContext = new QueueViewModel<int>();
        }

        /// <summary>
        /// Handles the IsEnabledChanged event of the CollectionType control.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private void CollectionType_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {


            //if (this.ArrayType.IsChecked.Value)

        }
    }
}