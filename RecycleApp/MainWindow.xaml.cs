using System.Windows;
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
		private readonly GarbageCollectionPointsPage _garbageCollectionPointsPage;
		private readonly GarbageTypeInfoPage _garbageTypeInfoPage;
		private readonly OwnPointsPage _ownPointsPage;
		private AuthorizationWindow _authorizationWindow;

		public MainWindow(
			GarbageCollectionPointsPage garbageCollectionPointsPage,
			GarbageTypeInfoPage garbageTypeInfoPage,
			OwnPointsPage ownPointsPage
		)
		{
			_currentUser = App.CurrentUser;
			_garbageCollectionPointsPage = garbageCollectionPointsPage;
			_garbageTypeInfoPage = garbageTypeInfoPage;
			_ownPointsPage = ownPointsPage;
			InitializeComponent();
		}

		private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
		{
			_authorizationWindow = App.AppAuthorizationWindow;

			rbEmpty.IsChecked = true;
			SetVisibilityForRole();
		}

		private void BtnExit_Click(object sender, RoutedEventArgs e)
		{
			App.CurrentUser = null;

			_authorizationWindow.SetEmailOnPage(_currentUser.Username);
			_authorizationWindow.Visibility = Visibility.Visible;

			Close();
		}

		private void SetVisibilityForRole()
		{
			if (_currentUser is {IdRole: 1})
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
			FrameMain.Navigate(_garbageCollectionPointsPage);
		}

		private void rbTypeOfGarbage_Checked(object sender, RoutedEventArgs e)
		{
			FrameMain.Navigate(_garbageTypeInfoPage);
		}

		private void rbOwnPoints_Checked(object sender, RoutedEventArgs e)
		{
			FrameMain.Navigate(_ownPointsPage);
		}
	}
}