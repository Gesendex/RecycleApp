using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using RecycleApp.Models;
using RecycleApp.Services;

namespace RecycleApp.Pages
{
	/// <summary>
	/// Логика взаимодействия для RegistrationPage.xaml
	/// </summary>
	public partial class RegistrationPage : Page
	{
		private readonly IRecycleService _recycleService;
		public AuthorizationPage AuthorizationPage { get; set; }

		public RegistrationPage(IRecycleService recycleService)
		{
			_recycleService = recycleService;
			InitializeComponent();
		}

		private bool FieldValidation()
		{
			if (string.IsNullOrWhiteSpace(TXBName.Text) || TXBName.Text.Length < 2)
				return false;

			if (CBRole.SelectedItem == null)
				return false;

			if (!FieldValidationHelper.IsValidEmail(TXBEmail.Text) || string.IsNullOrWhiteSpace(TXBEmail.Text))
				return false;

			if (string.IsNullOrWhiteSpace(PSboxPassword.Password) || PSboxPassword.Password.Length < 6)
				return false;

			return true;
		}

		private async void BtnRegistration_Click(object sender, RoutedEventArgs e)
		{
			if (!FieldValidation())
			{
				return;
			}

			var clientDtoIn = new ClientDtoIn()
			{
				Id = 0,
				Name = TXBName.Text,
				Surname = TXBSurname.Text,
				Middlename = TXBMiddlename.Text,
				Email = TXBEmail.Text,
				IdRole = CBRole.SelectedIndex + 1,
				Password = PSboxPassword.Password
			};

			var response = await _recycleService.Register(clientDtoIn);

			if (!response)
			{
				return;
			}

			AuthorizationPage.SetEmail(clientDtoIn.Email);
			NavigationService.Navigate(AuthorizationPage);
		}

		private void Hyperlink_OnClick(object sender, RoutedEventArgs e)
		{
			NavigationService.GoBack();
		}
	}
}