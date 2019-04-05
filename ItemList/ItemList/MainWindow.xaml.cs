using System.Windows;

namespace ItemList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    /// <owner>Anton Petrenko</owner>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        /// <owner>Anton Petrenko</owner>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }
    }
}
