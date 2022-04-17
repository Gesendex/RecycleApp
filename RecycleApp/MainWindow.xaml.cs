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
using System.Net;
using System.IO;
using System.Text.Json;
using RecycleApp.Models;
using RecycleApp.Pages;

namespace RecycleApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly ClientDtoIn _currentUser;

		public MainWindow()
		{
			InitializeComponent();
			_currentUser = App.CurrentUser;
			rbEmpty.IsChecked = true;
			SetVisibilityForRole();
		}

		private void SetVisibilityForRole()
		{
			if (
				_currentUser != null
				&& _currentUser.IdRole == 1
			)
			{
				rbOwnPoints.Visibility = Visibility.Collapsed;
			}
		}

		private void rbEmpty_Checked(object sender, RoutedEventArgs e)
		{
			FrameMain.Navigate(new EmptyPage());
		}

		private void rbGCPoints_Checked(object sender, RoutedEventArgs e)
		{
			FrameMain.Navigate(new GarbageCollectionPointsPage());
		}

		private void rbTypeOfGarbage_Checked(object sender, RoutedEventArgs e)
		{
			FrameMain.Navigate(new GarbageTypeInfoPage());
		}

		private void rbOwnPoints_Checked(object sender, RoutedEventArgs e)
		{
			FrameMain.Navigate(new OwnPointsPage(App.CurrentUser));
		}

		private void BtnExit_Click(object sender, RoutedEventArgs e)
		{
			App.CurrentUser = null;
			this.Close();
		}
	}
}