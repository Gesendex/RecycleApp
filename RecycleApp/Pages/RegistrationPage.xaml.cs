using Recycle.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RecycleApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }
        private bool FieldValidation()
        {
            if (string.IsNullOrWhiteSpace(TXBName.Text) || TXBName.Text.Length < 2)
                return false;
            if (CBRole.SelectedItem == null )
                return false;
            if (!FieldValidator.IsValidEmail(TXBEmail.Text) || string.IsNullOrWhiteSpace(TXBEmail.Text))
                return false;
            if (string.IsNullOrWhiteSpace(PSboxPassword.Password) || PSboxPassword.Password.Length < 6)
                return false;
            return true;
        }
        private async void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            if(FieldValidation())
            {
                Client client = new Client()
                {
                    Id = 0,
                    Name = TXBName.Text,
                    Surname = TXBSurname.Text,
                    Middlename = TXBMiddlename.Text,
                    Email = TXBEmail.Text,
                    IdRole = CBRole.SelectedIndex + 1,
                    Password = PSboxPassword.Password
                };
                var response = await RequestHandler.PutRequestAsync(client, "/api/Client/Registration");
                if (response)
                {
                    NavigationService.Navigate(new AuthorizationPage(client.Email));
                }
            }
            



            
        }    
    }
}