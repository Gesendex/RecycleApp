using RecycleApp.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace RecycleApp.Pages
{
	/// <summary>
	/// Логика взаимодействия для CommentsPage.xaml
	/// </summary>
	public partial class CommentsPage : Page
	{
		private readonly GarbageCollectionPointDtoIn _currentGCP;

		public CommentsPage(GarbageCollectionPointDtoIn currentGCP)
		{
			InitializeComponent();
			_currentGCP = currentGCP;
			TXBGCPCompany.Text += _currentGCP.Company.Name;
			TXBGCPAddress.Text += _currentGCP.FullAddress;
			UpdateSource();
		}

		private async void UpdateSource()
		{
			string parametr = "/" + _currentGCP.Id.ToString();
			LWComments.ItemsSource =
				await RequestHandler.GetObjectFromRequestAsync<IEnumerable<CommentDtoIn>>("GET",
					"/api/Comment/GetAllByGCPId", parametr);
		}

		private async void BtnWriteColumn_Click(object sender, RoutedEventArgs e)
		{
			this.IsEnabled = false;
			if (string.IsNullOrWhiteSpace(TXBxCommentBody.Text))
			{
				MessageBox.Show("Вы не ввели комментарий!", "Ошибка");
				this.IsEnabled = true;
				return;
			}

			if (TXBxCommentBody.Text.Length > 255)
			{
				MessageBox.Show(
					$"Максимальная длинна комментария 255 символов, вы ввели - {TXBxCommentBody.Text.Length}",
					"Ошибка");
				this.IsEnabled = true;
				return;
			}

			var com = new CommentDtoIn()
			{
				Id = 0,
				IdClient = App.CurrentUser.Id,
				IdGarbageCollectionPoint = _currentGCP.Id,
				Text = TXBxCommentBody.Text
			};
			var response = await RequestHandler.PutRequestAsync(com, "/api/Comment/WriteComment");
			if (response)
			{
				TXBxCommentBody.Text = "";
				UpdateSource();
			}

			this.IsEnabled = true;
		}

		private void BtnBack_Click(object sender, RoutedEventArgs e)
		{
			if (NavigationService.CanGoBack)
			{
				NavigationService.GoBack();
			}
		}
	}
}