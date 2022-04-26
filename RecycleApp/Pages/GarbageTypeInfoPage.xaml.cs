using RecycleApp.Models;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using RecycleApp.Converters;
using RecycleApp.Helpers;
using RecycleApp.Services;

namespace RecycleApp.Pages
{
	/// <summary>
	/// Логика взаимодействия для GarbageTypeInfoPage.xaml
	/// </summary>
	public partial class GarbageTypeInfoPage : Page
	{
		private readonly IRecycleService _recycleService;

		public GarbageTypeInfoPage(IRecycleService recycleService)
		{
			_recycleService = recycleService;
			InitializeComponent();
		}

		private void LWGarbageType_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var selectedItem = ContextHelper.GetListViewItem<TypeOfGarbageDtoIn>(sender);

			var subImage = selectedItem?.TypeImage?.SubImage;
			SelectedImage.Source = ByteArrayConverter.ToImageSource(subImage);

			TXBDescription.Text = selectedItem?.Description;
		}

		private async void Page_Loaded(object sender, RoutedEventArgs e)
		{
			await InitTypeOfGarbageAsync();
		}

		private async Task InitTypeOfGarbageAsync()
		{
			LWGarbageType.ItemsSource = await _recycleService.GetTypeOfGarbageWithImageAsync();
			LWGarbageType.SelectedIndex = 0;
		}
	}
}