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
    /// Логика взаимодействия для OwnPointsPage.xaml
    /// </summary>
    public partial class OwnPointsPage : Page
    {
        private Client _currentClient; 
        public OwnPointsPage(Client client)
        {
            InitializeComponent();
            _currentClient = client;
        }

        private async void  Page_Loaded(object sender, RoutedEventArgs e)
        {
            string parametrs = "/" + _currentClient.Id.ToString();
            LWGarbagePoints.ItemsSource = await RequestHandler.GetObjectFromRequestAsync<IEnumerable<GarbageCollectionPoint>>("GET", "/api/GarbageCollectionPoint/GetByClientId", parametrs);
        }

        private void LWGarbagePoints_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = ((sender as ListView).SelectedItem as GarbageCollectionPoint);
            TXBDescription.Text = selectedItem.Description;
            if(selectedItem.Image != null)
                SelectedImage.Source = new ImageSourceConverter().ConvertFrom(selectedItem.Image) as ImageSource;
            
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

        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            var button = sender as Button;
            var currentGCP = button.DataContext as GarbageCollectionPoint;
            await RequestHandler.DeleteRequestAsync("/api/GarbageCollectionPoint/DeleteGCP", "/" + currentGCP.Id); 
            string parametrs = "/" + _currentClient.Id.ToString();
            LWGarbagePoints.ItemsSource = await RequestHandler.GetObjectFromRequestAsync<IEnumerable<GarbageCollectionPoint>>("GET", "/api/GarbageCollectionPoint/GetByClientId", parametrs);
            this.IsEnabled = true;
        }
    }
}
