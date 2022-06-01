using System;
using RecycleApp.Helpers;
using RecycleApp.Services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace RecycleApp.Pages
{
	/// <summary>
	/// Логика взаимодействия для AuthorizationPage.xaml
	/// </summary>
	public partial class AuthorizationPage : Page
	{
		private readonly IRecycleService _recycleService;
		private readonly RegistrationPage _registrationPage;

		public AuthorizationPage(IRecycleService recycleService, RegistrationPage registrationPage)
		{
			_recycleService = recycleService;
			_registrationPage = registrationPage;
			InitializeComponent();
			//TODO: Удалить данные для быстрого входа
			TXBEmail.Text = "info@p-w.ru";
			PSboxPassword.Password = "123456";
		}

		private async void BtnAuthorization_Click(object sender, RoutedEventArgs e)
		{
			this.IsEnabled = false;

			var model = AuthorizationHelper.GetAuthorizationModel(
				email: TXBEmail.Text,
				password: PSboxPassword.Password
			);

			if (model == null)
			{
				MessageBox.Show("Отсутствует логин или пароль", "Ошибка");
				this.IsEnabled = true;
				return;
			}

			var response = await _recycleService.AuthorizeAsync(model);

			App.CurrentUser = response;

			if (response == null)
			{
				MessageBox.Show("Некорректный логин или пароль", "Ошибка");
				this.IsEnabled = true;
				return;
			}

			App.GetNewWindow().Show();
			App.AppAuthorizationWindow.Visibility = Visibility.Collapsed;
			this.IsEnabled = true;
		}

		public void SetEmail(string email)
		{
			TXBEmail.Text = email;
			PSboxPassword.Password = "";
		}

		private void RegistrationLink_OnClick(object sender, RoutedEventArgs e)
		{
			_registrationPage.AuthorizationPage = this;
			NavigationService.Navigate(_registrationPage);
		}
	}
}