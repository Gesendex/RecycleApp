using Microsoft.Win32;
using Recycle.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для EditGarbageCollectionPointEditPage.xaml
    /// </summary> 
    
    public partial class EditGarbageCollectionPointEditPage : Page
    {
        private GarbageCollectionPoint _currentGCP = null;
        private byte[] _mainImageData;
        public EditGarbageCollectionPointEditPage()
        {
            InitializeComponent();
        }
        public EditGarbageCollectionPointEditPage(GarbageCollectionPoint GCP)
        {
            InitializeComponent();
            _currentGCP = GCP;
            SetCompanyAsync();
            TBBuilding.Text = _currentGCP.Building;
            TBStreet.Text = _currentGCP.Street;
            TBxDescription.Text = _currentGCP.Description;
            CBCompany.IsEnabled = false;
            if(_currentGCP.Image != null)
            {
                ImageGC.Source = new ImageSourceConverter().ConvertFrom(_currentGCP.Image) as ImageSource;
            }
        }
        private async void SetCompanyAsync()
        {
            CBCompany.ItemsSource = await RequestHandler.GetObjectFromRequestAsync<IEnumerable<Company>>("GET", "/api/Company/GetAll");
            CBCompany.SelectedIndex = CBCompany.ItemsSource.OfType<Company>().ToList().FindIndex(p => p.Id == _currentGCP.IdCompany);
        }

        private void BtnSelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image | *.png; *.jpg; *.jpeg";
            if (ofd.ShowDialog() == true)
            {
                _mainImageData = File.ReadAllBytes(ofd.FileName);
                ImageGC.Source = new ImageSourceConverter().ConvertFrom(_mainImageData) as ImageSource;
            }
        }
        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if(RequeredFieldsCheck())
            {
                if (_currentGCP != null)
                {
                    GarbageCollectionPoint gcp = new GarbageCollectionPoint()
                    {
                        Building = TBBuilding.Text,
                        Street = TBStreet.Text,
                        Image = _mainImageData,
                        Description = TBxDescription.Text,
                        IdCompany = (CBCompany.SelectedItem as Company).Id,
                        Id = _currentGCP.Id
                    };
                    var response = await RequestHandler.PostRequestAsync<GarbageCollectionPoint>(gcp, "/api/GarbageCollectionPoint");
                }
            }
            
        }
        private bool RequeredFieldsCheck()
        {
            if (string.IsNullOrWhiteSpace(TBStreet.Text))
            {
                MessageBox.Show("Улица не указана", "Ошибка", MessageBoxButton.OK);
                return false;
            }
            if (string.IsNullOrWhiteSpace(TBBuilding.Text))
            {
                MessageBox.Show("Дом не указан", "Ошибка", MessageBoxButton.OK);
                return false;
            }
            if (CBCompany.SelectedItem == null)
            {
                MessageBox.Show("Компания не выбрана", "Ошибка", MessageBoxButton.OK);
                return false;
            }
            return true;
        }
    }
}
