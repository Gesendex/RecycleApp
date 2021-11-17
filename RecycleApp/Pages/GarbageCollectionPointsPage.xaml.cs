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
        public GarbageCollectionPointsPage()
        {
            InitializeComponent();
            string text = ConfigurationManager.AppSettings.Get("HostURL");
        }

        private async Task<GarbageCollectionPoint> GetGarbageCollectionPointAsync()
        {
            JsonSerializerOptions options = new JsonSerializerOptions {  PropertyNameCaseInsensitive = true };
            WebRequest request = HttpWebRequest.Create($"https://localhost:44373/api/GarbageCollectionPoint/GetById/1");
            request.Method = "GET";
            var response = await request.GetResponseAsync();
            return await JsonSerializer.DeserializeAsync<GarbageCollectionPoint>(response.GetResponseStream(), options);
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var a = await GetGarbageCollectionPointAsync();
        }
    }
}
