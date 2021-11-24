﻿using Recycle.Models;
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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
            //TODO: Удалить данные для быстрого входа
            TXBEmail.Text = "Gireev2003@mail.ru";
            PSboxPassword.Password = "123456";
        }
        public AuthorizationPage(string email)
        {
            InitializeComponent();
            TXBEmail.Text = email;
        }
        private bool FieldValidation()
        {
            if (!FieldValidator.IsValidEmail(TXBEmail.Text) || string.IsNullOrWhiteSpace(TXBEmail.Text))
                return false;
            if (string.IsNullOrWhiteSpace(PSboxPassword.Password) || PSboxPassword.Password.Length < 6)
                return false;
            return true;
        }
        private async void BtnAuthorization_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            if(!FieldValidation())
            {
                MessageBox.Show("Некорректный логин или пароль", "");
                this.IsEnabled = true;
                return;
            }
            string[] userData = { TXBEmail.Text, PSboxPassword.Password };
            var response = await RequestHandler.PostRequestAsync<Client, string[]>(userData, "/api/Client/Authorization","POST");
            if(response != null)
            {
                App.CurrentUser = response;
                Window window = new MainWindow();
                window.Show();
                Window.GetWindow(this).Close();
            }
            this.IsEnabled = true;
        }
    }
}
