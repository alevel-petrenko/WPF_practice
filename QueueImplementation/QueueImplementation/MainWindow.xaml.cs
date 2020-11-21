using System.Windows;
using System.Windows.Controls;
using ViewModel;

namespace QueueStack
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
            this.DataContext = new CustomCollectionViewModel<int>();
        }

		/// <summary>
		/// Handles the checking of the radio button.
		/// </summary>
		/// <owner>Anton Petrenko</owner>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
		private void RadioButtonIsChecked(object sender, RoutedEventArgs e)
		{
			var button = sender as RadioButton;

			if (this.DataContext is CustomCollectionViewModel<int> viewModel)
				viewModel.SelectedArrayLinkedListType = button.Content.ToString();
		}
	}
}