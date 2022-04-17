using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RecycleApp.Pages;

namespace RecycleApp
{
	/// <summary>
	/// Логика взаимодействия для AuthorizationWindow.xaml
	/// </summary>
	public partial class AuthorizationWindow : Window
	{
		public AuthorizationWindow(AuthorizationPage authorizationPage)
		{
			InitializeComponent();
			FrameMain.NavigationService.Navigate(authorizationPage);
		}

		public AuthorizationWindow()
		{
			this.Close();
		}

		private void RegistrationLink_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
		}
	}
}