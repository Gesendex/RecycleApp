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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void LWGarbagePoints_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnComment_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
