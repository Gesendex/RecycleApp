using System;
using RecycleApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RecycleApp.Services;

namespace RecycleApp.Pages
{
	/// <summary>
	/// Логика взаимодействия для CommentsPage.xaml
	/// </summary>
	public partial class CommentsPage : Page
	{
		private readonly GarbageCollectionPointDtoIn _currentGCP;
		private readonly IRecycleService _recycleService;

		public CommentsPage(GarbageCollectionPointDtoIn currentGCP, IRecycleService recycleService)
		{
			InitializeComponent();
			_currentGCP = currentGCP;
			_recycleService = recycleService;
		}

		private void CommentsPage_OnLoaded(object sender, RoutedEventArgs e)
		{
			TXBGCPCompany.Text += _currentGCP.Company.Name;
			TXBGCPAddress.Text += _currentGCP.FullAddress;
			UpdateSource();
		}

		private async void UpdateSource()
		{
			var comments = await _recycleService.GetAllCommentsByGcpId(_currentGCP.Id);

			LWComments.ItemsSource = comments.ToList();
		}

		private async void BtnWriteColumn_Click(object sender, RoutedEventArgs e)
		{
			this.IsEnabled = false;

			if (ValidateComment())
			{
				return;
			}

			var comment = new CommentDtoIn(
				id: 0,
				idClient: App.CurrentUser.Id,
				idGarbageCollectionPoint: _currentGCP.Id,
				text: TXBxCommentBody.Text,
				dateOfCreation: DateTimeOffset.UtcNow,
				client: null
			);

			var isCommentCreated = await _recycleService.PutComment(comment);

			if (isCommentCreated)
			{
				TXBxCommentBody.Text = "";
				UpdateSource();
			}

			this.IsEnabled = true;
		}

		private bool ValidateComment()
		{
			if (string.IsNullOrWhiteSpace(TXBxCommentBody.Text))
			{
				MessageBox.Show("Вы не ввели комментарий!", "Ошибка");
				this.IsEnabled = true;
				return true;
			}

			if (TXBxCommentBody.Text.Length > 255)
			{
				MessageBox.Show(
					$"Максимальная длинна комментария 255 символов, вы ввели - {TXBxCommentBody.Text.Length}",
					"Ошибка");
				this.IsEnabled = true;
				return true;
			}

			return false;
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