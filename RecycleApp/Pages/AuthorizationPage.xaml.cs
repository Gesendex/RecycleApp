using Autofac;
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
		private readonly MainWindow _mainWindow;


		public AuthorizationPage(IRecycleService recycleService, MainWindow mainWindow)
		{
			_recycleService = recycleService;
			_mainWindow = mainWindow;
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
				password: PSboxPassword.Password);

			if (model == null)
			{
				MessageBox.Show("Некорректный логин или пароль", "");
				this.IsEnabled = true;
				return;
			}

			var response = await _recycleService.AuthorizeAsync(model);

			if (response != null)
			{
				App.CurrentUser = response;

				_mainWindow.Show();
				Window.GetWindow(this)?.Close();
			}

			this.IsEnabled = true;
		}

		public void SetEmail(string email)
		{
			TXBEmail.Text = email;
		}
	}
}