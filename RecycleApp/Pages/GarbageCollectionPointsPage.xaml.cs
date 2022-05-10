using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using RecycleApp.Converters;
using RecycleApp.Helpers;
using RecycleApp.Models;
using RecycleApp.RecycleApiService;
using RecycleApp.Services;

namespace RecycleApp.Pages
{
	/// <summary>
	/// Логика взаимодействия для GarbageCollectionPointsPage.xaml
	/// </summary>
	public partial class GarbageCollectionPointsPage : Page
	{
		private readonly IRecycleService _recycleService;

		private IList<GarbageCollectionPointDtoIn> _garbageCollectionPoints;
		private IList<TypeOfGarbageDtoIn> _types;
		private IList<CompanyDtoIn> _companies;

		public GarbageCollectionPointsPage(IRecycleService recycleService)
		{
			_recycleService = recycleService;
			InitializeComponent();
		}

		private async void Page_Loaded(object sender, RoutedEventArgs e)
		{
			DisableFilters();

			await InitGarbageCollectionPointAsync();
			await InitCompaniesAsync();
			await InitTypeOfGarbageAsync();

			EnableFilters();
		}

		private void EnableFilters()
		{
			CBTypesFilter.IsEnabled = true;
			CBCompanyFilter.IsEnabled = true;
		}

		private void DisableFilters()
		{
			CBCompanyFilter.IsEnabled = false;
			CBTypesFilter.IsEnabled = false;
		}

		private async Task InitGarbageCollectionPointAsync()
		{
			_garbageCollectionPoints = await _recycleService.GetGarbageCollectionPointsAsync();
			LWGarbagePoints.ItemsSource = _garbageCollectionPoints.ToList();
		}

		private async Task InitTypeOfGarbageAsync()
		{
			_types = await _recycleService.GetTypeOfGarbageWithImageAsync();
			_types = _types.Prepend(new TypeOfGarbageDtoIn(-1, "Все")).ToList();

			CBTypesFilter.ItemsSource = _types;
			CBTypesFilter.SelectedIndex = 0;
		}

		private async Task InitCompaniesAsync()
		{
			_companies = await _recycleService.GetCompaniesAsync();
			_companies = _companies.Prepend(new CompanyDtoIn(-1, "Все")).ToList();

			CBCompanyFilter.ItemsSource = _companies;
			CBCompanyFilter.SelectedIndex = 0;
		}

		private void LWGarbagePoints_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var selectedItem = ContextHelper.GetListViewItem<GarbageCollectionPointDtoIn>(sender);

			TXBDescription.Text = selectedItem?.Description ?? "";

			SelectedImage.Source = ByteArrayConverter.ToImageSource(selectedItem?.Image);
		}

		private void CBCompanyFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Sort();
		}

		private void TBxStreet_LostFocus(object sender, RoutedEventArgs e)
		{
			Sort();
		}

		private void TBxBuilding_LostFocus(object sender, RoutedEventArgs e)
		{
			Sort();
		}

		private void CBTypesFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Sort();
		}

		private void Sort()
		{
			DisableFilters();

			var buf = _garbageCollectionPoints.ToList().AsQueryable();

			if (CBCompanyFilter.SelectedIndex > 0)
			{
				var company = CBCompanyFilter.SelectedItem as CompanyDtoIn;
				buf = buf.Where(p => p.IdCompany == company.Id);
			}

			if (CBTypesFilter.SelectedIndex > 0)
			{
				var typeOfGarbage = CBTypesFilter.SelectedItem as TypeOfGarbageDtoIn;

				buf = buf
					.Where(
						garbageCollectionPointDtoIn =>
							garbageCollectionPointDtoIn.GarbageTypeSets
								.Any(
									garbageTypeSetDtoIn =>
										garbageTypeSetDtoIn.IdTypeOfGarbage == typeOfGarbage.Id
								)
					);
			}

			if (!string.IsNullOrWhiteSpace(TBxStreet.Text))
			{
				buf = buf.Where(garbageCollectionPointDtoIn => garbageCollectionPointDtoIn.Street.ToLower().Contains(TBxStreet.Text.ToLower().Trim()));
			}

			if (!string.IsNullOrWhiteSpace(TBxBuilding.Text))
			{
				buf = buf.Where(garbageCollectionPointDtoIn => garbageCollectionPointDtoIn.Building.ToLower().Contains(TBxBuilding.Text.ToLower().Trim()));
			}

			LWGarbagePoints.ItemsSource = buf.ToList();

			EnableFilters();
		}

		private void BtnEdit_Click(object sender, RoutedEventArgs e)
		{
			var currentGCP = ContextHelper.GetButtonContext<GarbageCollectionPointDtoIn>(sender);

			NavigationService.Navigate(new GarbageCollectionPointEditPage(currentGCP, _recycleService));
		}

		private void BtnComment_Click(object sender, RoutedEventArgs e)
		{
			var currentGCP = ContextHelper.GetButtonContext<GarbageCollectionPointDtoIn>(sender);

			NavigationService.Navigate(new CommentsPage(currentGCP, _recycleService));
		}
	}
}