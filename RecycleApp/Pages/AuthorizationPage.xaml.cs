using RecycleApp.Helpers;
using RecycleApp.Services;
using System.Windows;
using System.Windows.Controls;

namespace RecycleApp.Pages
{
	/// <summary>
	/// Логика взаимодействия для AuthorizationPage.xaml
	/// </summary>
	public partial class AuthorizationPage : Page
	{
		private readonly IRecycleService _recycleService;

		public AuthorizationPage(IRecycleService recycleService)
		{
			_recycleService = recycleService;
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
				MessageBox.Show("Некорректный логин или пароль", "");
				this.IsEnabled = true;
				return;
			}

			var response = await _recycleService.AuthorizeAsync(model);

			App.CurrentUser = response;

			if (response != null)
			{
				App.GetNewWindow().Show();
				App.AppAuthorizationWindow.Visibility = Visibility.Collapsed;
			}

			this.IsEnabled = true;
		}

		public void SetEmail(string email)
		{
			TXBEmail.Text = email;
			PSboxPassword.Password = "";
		}
	}
}