using Microsoft.Win32;
using RecycleApp.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using RecycleApp.Converters;
using RecycleApp.Helpers;
using RecycleApp.RecycleApiService;
using RecycleApp.Services;

namespace RecycleApp.Pages
{
	/// <summary>
	/// Логика взаимодействия для EditGarbageCollectionPointEditPage.xaml
	/// </summary> 
	public partial class GarbageCollectionPointEditPage : Page
	{
		private readonly IRecycleService _recycleService;

		private readonly GarbageCollectionPointDtoIn _currentGarbageCollectionPoint;

		private byte[] _mainImageData;
		private IList<TypeOfGarbageDtoIn> _typesOfGarbage;
		private IList<CompanyDtoIn> _companies;

		public GarbageCollectionPointEditPage(IRecycleService recycleService)
		{
			_recycleService = recycleService;
			InitializeComponent();
		}

		public GarbageCollectionPointEditPage(
			GarbageCollectionPointDtoIn garbageCollectionPoint,
			IRecycleService recycleService
		)
		{
			_currentGarbageCollectionPoint = garbageCollectionPoint;
			_recycleService = recycleService;

			InitializeComponent();
		}

		private async void Page_Loaded(object sender, RoutedEventArgs e)
		{
			_typesOfGarbage = await _recycleService.GetTypeOfGarbageAsync();

			if (_currentGarbageCollectionPoint != null)
			{
				CBCompany.IsEnabled = false;
				_mainImageData = _currentGarbageCollectionPoint.Image;
				TBBuilding.Text = _currentGarbageCollectionPoint.Building;
				TBStreet.Text = _currentGarbageCollectionPoint.Street;
				TBxDescription.Text = _currentGarbageCollectionPoint?.Description;
				ImageGC.Source = ByteArrayConverter.ToImageSource(_currentGarbageCollectionPoint.Image);
				CBCompany.ItemsSource = new[] {_currentGarbageCollectionPoint.Company};
				await InitTypeSetAsync();
			}
			else
			{
				await SetCompanysAsync();
			}
		}

		private async Task InitTypeSetAsync()
		{
			var garbageTypes = await _recycleService
				.GetTypeOfGarbageByGarbageCollectionPointIdAsync(_currentGarbageCollectionPoint.Id);

			garbageTypes?.ToList()
				.ForEach(
					item =>
						SetCheckBox(item.Id)
				);
		}

		private async Task SetCompanysAsync()
		{
			_companies = await _recycleService.GetCompaniesAsync();
			CBCompany.ItemsSource = _companies.ToList();
			CBCompany.SelectedIndex = 1;
		}

		private void BtnSelectImage_Click(object sender, RoutedEventArgs e)
		{
			var ofd = new OpenFileDialog
			{
				Filter = "Image | *.png; *.jpg; *.jpeg"
			};

			if (ofd.ShowDialog() == true)
			{
				_mainImageData = File.ReadAllBytes(ofd.FileName);
				ImageGC.Source = ByteArrayConverter.ToImageSource(_mainImageData);
			}
		}

		private async void BtnSave_Click(object sender, RoutedEventArgs e)
		{
			this.IsEnabled = false;

			if (!RequiredFieldsCheck())
			{
				this.IsEnabled = true;
				return;
			}

			if (_currentGarbageCollectionPoint == null)
			{
				await CreateGarbageCollectionPoint();
			}
			else
			{
				await UpdateCurrentGarbageCollectionPointAsync();
			}

			this.IsEnabled = true;
		}

		private async Task CreateGarbageCollectionPoint()
		{
			var typeSet = GetTypeSet();
			var company = _companies
				.FirstOrDefault(
					company =>
						company.ClientId.HasValue
						&& company.ClientId.Value == App.CurrentUser.Id
				);

			var gcp = new GarbageCollectionPointDtoIn()
			{
				Id = 0,
				Building = TBBuilding.Text,
				Street = TBStreet.Text,
				Image = _mainImageData,
				Description = TBxDescription.Text,
				IdCompany = company?.Id ?? 1,
				GarbageTypeSets = typeSet
			};

			var isGcpCreated =
				await RequestHandler.PutRequestAsync(gcp, "/api/GarbageCollectionPointDtoIn/CreateGCP");

			if (isGcpCreated)
			{
				MessageBox.Show("Данные успешно сохранены!", "Уведомление");
			}
		}

		private async Task UpdateCurrentGarbageCollectionPointAsync()
		{
			var typeSet = GetTypeSet();
			var company = ContextHelper.GetListViewItem<Company>(CBCompany);

			var garbageCollectionPoint = new GarbageCollectionPointDtoIn()
			{
				Id = _currentGarbageCollectionPoint.Id,
				Building = TBBuilding.Text,
				Street = TBStreet.Text,
				Image = _mainImageData,
				Description = TBxDescription.Text,
				IdCompany = company.Id,
				GarbageTypeSets = typeSet
			};

			var response = await _recycleService.UpdateGarbageCollectionPoint(garbageCollectionPoint);
			if (response)
			{
				MessageBox.Show("Данные успешно сохранены!", "Уведомление");
			}
		}

		private IList<GarbageTypeSetDtoIn> GetTypeSet()
		{
			var typeSet = new List<GarbageTypeSetDtoIn>();
			if (glassCHbx.IsChecked.Value)
				typeSet.Add(new GarbageTypeSetDtoIn()
					{IdGarbageCollectionPoint = _currentGarbageCollectionPoint.Id, IdTypeOfGarbage = 1});
			if (plasticCHbx.IsChecked.Value)
				typeSet.Add(new GarbageTypeSetDtoIn()
					{IdGarbageCollectionPoint = _currentGarbageCollectionPoint.Id, IdTypeOfGarbage = 2});
			if (paperCHbx.IsChecked.Value)
				typeSet.Add(new GarbageTypeSetDtoIn()
					{IdGarbageCollectionPoint = _currentGarbageCollectionPoint.Id, IdTypeOfGarbage = 3});
			if (metalCHbx.IsChecked.Value)
				typeSet.Add(new GarbageTypeSetDtoIn()
					{IdGarbageCollectionPoint = _currentGarbageCollectionPoint.Id, IdTypeOfGarbage = 4});
			if (pacCHbx.IsChecked.Value)
				typeSet.Add(new GarbageTypeSetDtoIn()
					{IdGarbageCollectionPoint = _currentGarbageCollectionPoint.Id, IdTypeOfGarbage = 5});
			if (dangCHbx.IsChecked.Value)
				typeSet.Add(new GarbageTypeSetDtoIn()
					{IdGarbageCollectionPoint = _currentGarbageCollectionPoint.Id, IdTypeOfGarbage = 6});
			return typeSet;
		}

		private bool RequiredFieldsCheck()
		{
			if (string.IsNullOrWhiteSpace(TBStreet.Text))
			{
				MessageBox.Show("Улица не указана", "Ошибка", MessageBoxButton.OK);
				return false;
			}

			if (string.IsNullOrWhiteSpace(TBBuilding.Text))
			{
				MessageBox.Show("Дом не указан", "Ошибка", MessageBoxButton.OK);
				return false;
			}

			if (CBCompany.SelectedItem == null)
			{
				MessageBox.Show("Компания не выбрана", "Ошибка", MessageBoxButton.OK);
				return false;
			}

			return true;
		}

		private void BtnBack_Click(object sender, RoutedEventArgs e)
		{
			if (NavigationService.CanGoBack)
			{
				NavigationService.GoBack();
			}
		}

		private void SetCheckBox(int id)
		{
			if (id == 1)
				glassCHbx.IsChecked = true;
			else if (id == 2)
				plasticCHbx.IsChecked = true;
			else if (id == 3)
				paperCHbx.IsChecked = true;
			else if (id == 4)
				metalCHbx.IsChecked = true;
			else if (id == 5)
				pacCHbx.IsChecked = true;
			else if (id == 6)
				dangCHbx.IsChecked = true;
		}
	}
}