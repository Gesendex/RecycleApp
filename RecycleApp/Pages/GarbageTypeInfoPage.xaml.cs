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
    /// Логика взаимодействия для GarbageTypeInfoPage.xaml
    /// </summary>
    public partial class GarbageTypeInfoPage : Page
    {
        public GarbageTypeInfoPage()
        {
            InitializeComponent();
        }

        private void LWGarbageType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lw = sender as ListView;
            var selectedItem = (lw.SelectedItem as TypeOfGarbage);
            if (selectedItem.TypeImage.SubImage != null)
                SelectedImage.Source = new ImageSourceConverter().ConvertFrom(selectedItem.TypeImage.SubImage) as ImageSource;
            else
                SelectedImage.Source = null;
            TXBDescription.Text = selectedItem?.Description;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LWGarbageType.ItemsSource = await RequestHandler.GetObjectFromRequestAsync<IEnumerable<TypeOfGarbage>>("GET", "/api/TypeOfGarbage/GetAllWithImage");
            LWGarbageType.SelectedIndex = 0;
        }
    }
}
