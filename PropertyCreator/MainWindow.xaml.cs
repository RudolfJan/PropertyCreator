using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PropertyCreator
	{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
		{
		public PropertyData Property { get; set; }
		public MainWindow()
			{
			InitializeComponent();
			Property = new PropertyData();
			DataContext = Property;
			}

		private void OnCreatePropertyButtonClick(object sender, RoutedEventArgs e)
			{
			if (Property.IsDependencyProperty)
				{
				Property.CreateDependencyProperty();
				}
			else
				{
				Property.CreateProperty();
				}
			ResultTextBox.ScrollToEnd();
			}

		private void OnAddPropertyButtonClick(object sender, RoutedEventArgs e)
			{
			Property.AddProperty();
			}

		private void OnClearButtonClick(object sender, RoutedEventArgs e)
			{
			Property.Clear();
			}

		private void OnClearAndAddPropertyButtonClicked(object sender, RoutedEventArgs e)
			{
			Property.ClearAndAddProperty();
		}
	}
	}
