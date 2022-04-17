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
		private readonly AuthorizationPage _authorizationPage;


		public RegistrationPage(IRecycleService recycleService, AuthorizationPage authorizationPage)
		{
			_recycleService = recycleService;
			_authorizationPage = authorizationPage;
			InitializeComponent();
		}

		private bool FieldValidation()
		{
			if (string.IsNullOrWhiteSpace(TXBName.Text) || TXBName.Text.Length < 2)
				return false;
			if (CBRole.SelectedItem == null)
				return false;
			if (!FieldValidator.IsValidEmail(TXBEmail.Text) || string.IsNullOrWhiteSpace(TXBEmail.Text))
				return false;
			if (string.IsNullOrWhiteSpace(PSboxPassword.Password) || PSboxPassword.Password.Length < 6)
				return false;
			return true;
		}

		private async void BtnRegistration_Click(object sender, RoutedEventArgs e)
		{
			if (FieldValidation())
			{
				ClientDtoIn clientDtoIn = new ClientDtoIn()
				{
					Id = 0,
					Name = TXBName.Text,
					Surname = TXBSurname.Text,
					Middlename = TXBMiddlename.Text,
					Email = TXBEmail.Text,
					IdRole = CBRole.SelectedIndex + 1,
					Password = PSboxPassword.Password
				};

				var response = await RequestHandler.PutRequestAsync(clientDtoIn, "/api/ClientDtoIn/Registration");

				if (response)
				{
					_authorizationPage.SetEmail(clientDtoIn.Email);
					NavigationService.Navigate(_authorizationPage);
				}
			}
		}
	}
}