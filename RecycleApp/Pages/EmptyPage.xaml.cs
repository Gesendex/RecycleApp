using Recycle.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
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

namespace RecycleApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmptyPage.xaml
    /// </summary>
    public partial class EmptyPage : Page
    {
        public EmptyPage()
        {
            InitializeComponent();
        }

        private async void btnTest_Click(object sender, RoutedEventArgs e)
        {
            GarbageCollectionPoint gcp = new GarbageCollectionPoint()
            {
                Building = "aaa",
                Street = "bbb",
                Id = 11,
                IdCompany = 2,
                Image = null
            };
            var response = await RequestHandler.PostRequestAsync<GarbageCollectionPoint>(gcp, "/api/GarbageCollectionPoint");
            int a = 1;
        }
    }
}
