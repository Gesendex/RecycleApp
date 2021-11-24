﻿using Recycle.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
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
using System.Configuration;

namespace RecycleApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для GarbageCollectionPointsPage.xaml
    /// </summary>
    public partial class GarbageCollectionPointsPage : Page
    {
        public GarbageCollectionPointsPage()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LWGarbagePoints.ItemsSource = await RequestHandler.GetObjectFromRequestAsync<IEnumerable<GarbageCollectionPoint>>("GET", "/api/GarbageCollectionPoint/GetAll");
        }

        private void LWGarbagePoints_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TXBDescription.Text = ((sender as ListView).SelectedItem as GarbageCollectionPoint).Description;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var currentGCP = button.DataContext as GarbageCollectionPoint;
            NavigationService.Navigate(new GarbageCollectionPointEditPage(currentGCP));
        }

        private void BtnComment_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var currentGCP = button.DataContext as GarbageCollectionPoint;
            NavigationService.Navigate(new CommentsPage(currentGCP));
        }
    }
}
