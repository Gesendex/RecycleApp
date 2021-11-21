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
            if ((lw.SelectedItem as TypeOfGarbage).TypeImage.SubImage != null)
                SelectedImage.Source = new ImageSourceConverter().ConvertFrom((lw.SelectedItem as TypeOfGarbage).TypeImage.SubImage) as ImageSource;
            else
                SelectedImage.Source = null;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LWGarbageType.ItemsSource = await RequestHandler.GetObjectFromRequestAsync<IEnumerable<TypeOfGarbage>>("GET", "/api/TypeOfGarbage/GetAllWithImage");
        }
    }
}
