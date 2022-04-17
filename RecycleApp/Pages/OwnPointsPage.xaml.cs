using RecycleApp.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace RecycleApp.Pages
{
	/// <summary>
	/// Логика взаимодействия для OwnPointsPage.xaml
	/// </summary>
	public partial class OwnPointsPage : Page
	{
		private ClientDtoIn _currentClient;

		public OwnPointsPage(ClientDtoIn ClientDtoIn)
		{
			InitializeComponent();
			_currentClient = ClientDtoIn;
		}

		private async void Page_Loaded(object sender, RoutedEventArgs e)
		{
			string parametrs = "/" + _currentClient.Id.ToString();
			LWGarbagePoints.ItemsSource =
				await RequestHandler.GetObjectFromRequestAsync<IEnumerable<GarbageCollectionPointDtoIn>>("GET",
					"/api/GarbageCollectionPointDtoIn/GetByClientId", parametrs);
		}

		private void LWGarbagePoints_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var selectedItem = ((sender as ListView).SelectedItem as GarbageCollectionPointDtoIn);
			TXBDescription.Text = selectedItem?.Description;
			if (selectedItem?.Image != null)
				SelectedImage.Source = new ImageSourceConverter().ConvertFrom(selectedItem.Image) as ImageSource;
		}

		private void BtnEdit_Click(object sender, RoutedEventArgs e)
		{
			var button = sender as Button;
			var currentGCP = button.DataContext as GarbageCollectionPointDtoIn;
			NavigationService.Navigate(new GarbageCollectionPointEditPage(currentGCP));
		}

		private void BtnComment_Click(object sender, RoutedEventArgs e)
		{
			var button = sender as Button;
			var currentGCP = button.DataContext as GarbageCollectionPointDtoIn;
			NavigationService.Navigate(new CommentsPage(currentGCP));
		}

		private async void BtnDelete_Click(object sender, RoutedEventArgs e)
		{
			this.IsEnabled = false;
			var button = sender as Button;
			var currentGCP = button.DataContext as GarbageCollectionPointDtoIn;
			await RequestHandler.DeleteRequestAsync("/api/GarbageCollectionPointDtoIn/DeleteGCP", "/" + currentGCP.Id);
			string parametrs = "/" + _currentClient.Id.ToString();
			LWGarbagePoints.ItemsSource =
				await RequestHandler.GetObjectFromRequestAsync<IEnumerable<GarbageCollectionPointDtoIn>>("GET",
					"/api/GarbageCollectionPointDtoIn/GetByClientId", parametrs);
			this.IsEnabled = true;
		}

		private void btnCreateNew_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new GarbageCollectionPointEditPage());
		}
	}
}