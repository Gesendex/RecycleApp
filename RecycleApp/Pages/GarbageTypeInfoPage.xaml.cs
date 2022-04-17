using RecycleApp.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RecycleApp.Pages
{
	/// <summary>
	/// Логика взаимодействия для GarbageTypeInfoPage.xaml
	/// </summary>
	public partial class GarbageTypeInfoPage : Page
	{
		public GarbageTypeInfoPage()
		{
			InitializeComponent();
		}

		private void LWGarbageType_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var lw = sender as ListView;
			var selectedItem = (lw.SelectedItem as TypeOfGarbageDtoIn);
			if (selectedItem.TypeImage.SubImage != null)
				SelectedImage.Source =
					new ImageSourceConverter().ConvertFrom(selectedItem.TypeImage.SubImage) as ImageSource;
			else
				SelectedImage.Source = null;
			TXBDescription.Text = selectedItem?.Description;
		}

		private async void Page_Loaded(object sender, RoutedEventArgs e)
		{
			LWGarbageType.ItemsSource =
				await RequestHandler.GetObjectFromRequestAsync<IEnumerable<TypeOfGarbageDtoIn>>("GET",
					"/api/TypeOfGarbageDtoIn/GetAllWithImage");
			LWGarbageType.SelectedIndex = 0;
		}
	}
}