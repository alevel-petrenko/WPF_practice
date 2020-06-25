using System.Windows;
using ViewModel;

namespace QueueImplementation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new QueueViewModel();
        }
    }
}