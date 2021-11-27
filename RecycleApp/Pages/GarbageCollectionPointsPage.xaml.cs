using Recycle.Models;
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
        IEnumerable<GarbageCollectionPoint> gcps;
        public GarbageCollectionPointsPage()
        {
            InitializeComponent();
            CBCompanyFilter.IsEnabled = false; 
            CBTypesFilter.IsEnabled = false;
        }
        
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            gcps = await RequestHandler.GetObjectFromRequestAsync<IEnumerable<GarbageCollectionPoint>>("GET", "/api/GarbageCollectionPoint/GetAll");
            LWGarbagePoints.ItemsSource = await RequestHandler.GetObjectFromRequestAsync<IEnumerable<GarbageCollectionPoint>>("GET", "/api/GarbageCollectionPoint/GetAll");
            
            var cmp = (await RequestHandler.GetObjectFromRequestAsync<IEnumerable<Company>>("GET", "/api/Company/GetAll")).ToList();
            cmp.Insert(0,new Company() {Id = 0, Name = "Все"});
            CBCompanyFilter.ItemsSource = cmp;
            CBCompanyFilter.SelectedIndex = 0;

            var types = (await RequestHandler.GetObjectFromRequestAsync<IEnumerable<TypeOfGarbage>>("GET", "/api/TypeOfGarbage/GetAll")).ToList();
            types.Insert(0, new TypeOfGarbage() { Id = 0, Type = "Все" });
            CBTypesFilter.ItemsSource = types;
            CBTypesFilter.SelectedIndex = 0;
            CBTypesFilter.IsEnabled = true;
            CBCompanyFilter.IsEnabled = true;
        }

        private void LWGarbagePoints_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (sender as ListView).SelectedItem as GarbageCollectionPoint;
            TXBDescription.Text = selectedItem?.Description;
            if (selectedItem?.Image != null)
            {
                SelectedImage.Source = new ImageSourceConverter().ConvertFrom(selectedItem.Image) as ImageSource;
            }
            else
            {
                SelectedImage.Source = null;
            }
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
        private void Filt()
        {
            var buf = gcps;
            buf.ToList().Clear();
            
            if (CBCompanyFilter.SelectedIndex != 0 && CBCompanyFilter.SelectedIndex != -1)
            {
                buf = buf.Where(p => p.IdCompany == (CBCompanyFilter.SelectedItem as Company).Id);
            }

            if (CBTypesFilter.SelectedIndex != 0 && CBTypesFilter.SelectedIndex != -1)
            {
                buf = buf.Where(p => p.GarbageTypeSets.FirstOrDefault(g => g.IdTypeOfGarbage == (CBTypesFilter.SelectedItem as TypeOfGarbage).Id) != null);
            }

            if (!string.IsNullOrWhiteSpace(TBxStreet.Text))
            {
                buf = buf.Where(p => p.Street.ToLower().Contains(TBxStreet.Text.ToLower().Trim()));
            }
            if (!string.IsNullOrWhiteSpace(TBxBuilding.Text))
            {
                buf = buf.Where(p => p.Building.ToLower().Contains(TBxBuilding.Text.ToLower().Trim()));
            }
            LWGarbagePoints.ItemsSource = buf;
        }
        private void CBCompanyFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filt();
        }
        
        private void TBxStreet_LostFocus(object sender, RoutedEventArgs e)
        {
            Filt();
        }

        private void TBxBuilding_LostFocus(object sender, RoutedEventArgs e)
        {
            Filt();
        }

        private void CBTypesFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filt();
        }
    }
}
