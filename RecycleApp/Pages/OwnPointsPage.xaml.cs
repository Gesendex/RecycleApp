using RecycleApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using RecycleApp.Converters;
using RecycleApp.Helpers;
using RecycleApp.Services;

namespace RecycleApp.Pages
{
	/// <summary>
	/// Логика взаимодействия для OwnPointsPage.xaml
	/// </summary>
	public partial class OwnPointsPage : Page
	{
		private readonly IRecycleService _recycleService;

		private ClientDtoIn _currentClient;
		private IList<GarbageCollectionPointDtoIn> _garbageCollectionPoints;

		public OwnPointsPage(IRecycleService recycleService)
		{
			_recycleService = recycleService;
			InitializeComponent();
		}

		private async Task InitGarbageCollectionPointAsync()
		{
			await UpdateGarbageCollectionPoints();
		}

		private async Task UpdateGarbageCollectionPoints()
		{
			_garbageCollectionPoints =
				await _recycleService.GetGarbageCollectionPointsByClientIdAsync(_currentClient.Id);
			LWGarbagePoints.ItemsSource = _garbageCollectionPoints.ToList();
		}

		private async void Page_Loaded(object sender, RoutedEventArgs e)
		{
			_currentClient = App.CurrentUser;
			await InitGarbageCollectionPointAsync();
		}

		private void LWGarbagePoints_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var selectedItem = ContextHelper.GetListViewItem<GarbageCollectionPointDtoIn>(sender);

			TXBDescription.Text = selectedItem?.Description ?? "";

			SelectedImage.Source = ByteArrayConverter.ToImageSource(selectedItem?.Image);
		}

		private void BtnEdit_Click(object sender, RoutedEventArgs e)
		{
			var currentGCP = ContextHelper.GetButtonContext<GarbageCollectionPointDtoIn>(sender);

			NavigationService?.Navigate(new GarbageCollectionPointEditPage(currentGCP, _recycleService));
		}

		private void BtnComment_Click(object sender, RoutedEventArgs e)
		{
			var currentGCP = ContextHelper.GetButtonContext<GarbageCollectionPointDtoIn>(sender);

			NavigationService?.Navigate(new CommentsPage(currentGCP, _recycleService));
		}

		private async void BtnDelete_Click(object sender, RoutedEventArgs e)
		{
			this.IsEnabled = false;

			var currentGCP = ContextHelper.GetButtonContext<GarbageCollectionPointDtoIn>(sender);

			await _recycleService.DeleteGarbageCollectionPoint(currentGCP.Id);

			await UpdateGarbageCollectionPoints();

			this.IsEnabled = true;
		}

		private void btnCreateNew_Click(object sender, RoutedEventArgs e)
		{
			NavigationService?.Navigate(new GarbageCollectionPointEditPage(_recycleService));
		}
	}
}