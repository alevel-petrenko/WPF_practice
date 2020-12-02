using System.Windows;
using ViewModel;

namespace Presentation
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
            this.DataContext = new CustomCollectionViewModel();
        }
	}
}