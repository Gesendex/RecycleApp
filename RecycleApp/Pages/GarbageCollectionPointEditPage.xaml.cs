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
    
    public partial class GarbageCollectionPointEditPage : Page
    {
        private GarbageCollectionPoint _currentGCP = null;
        private byte[] _mainImageData;
        private TypeOfGarbage[] _types;
        public GarbageCollectionPointEditPage()
        {
            InitializeComponent();
            SetAllCompanyAsync();
            CBCompany.IsEnabled = false;
        }
        public GarbageCollectionPointEditPage(GarbageCollectionPoint GCP)
        {
            InitializeComponent();
            _currentGCP = GCP;
            SetCompanyAsync();
            SetTypeSet();
            TBBuilding.Text = _currentGCP.Building;
            TBStreet.Text = _currentGCP.Street;
            TBxDescription.Text = _currentGCP?.Description;
            _mainImageData = GCP.Image;
            CBCompany.IsEnabled = false;
            if(_currentGCP.Image != null)
            {
                ImageGC.Source = new ImageSourceConverter().ConvertFrom(_currentGCP.Image) as ImageSource;
            }
        }

        private void SetCheckBox(int id)
        {
            switch (id)
            {
                case 1:
                    {
                        glassCHbx.IsChecked = true;
                        break;
                    }
                case 2:
                    {
                        plasticCHbx.IsChecked = true;
                        break;
                    }
                case 3:
                    {
                        paperCHbx.IsChecked = true;
                        break;
                    }
                case 4:
                    {
                        metalCHbx.IsChecked = true;
                        break;
                    }
                case 5:
                    {
                        pacCHbx.IsChecked = true;
                        break;
                    }
                case 6:
                    {
                        dangCHbx.IsChecked = true;
                        break;
                    }

            }
        }
        private async void SetTypeSet()
        {
            string parametrs = "/" + _currentGCP.Id.ToString();
            var gcpTypes = await RequestHandler.GetObjectFromRequestAsync<IEnumerable<TypeOfGarbage>>("GET", "/api/TypeOfGarbage/GetByCollectionPointId", parametrs);
            if (gcpTypes != null)
                foreach (var item in gcpTypes)
                {
                    SetCheckBox(item.Id);
                }
        }

        private async void SetAllCompanyAsync()
        {
            CBCompany.ItemsSource = await RequestHandler.GetObjectFromRequestAsync<IEnumerable<Company>>("GET", "/api/Company/GetAll");
            CBCompany.SelectedIndex = CBCompany.ItemsSource.OfType<Company>().ToList().FindIndex(p => p.ClientId == App.CurrentUser.Id);
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
            this.IsEnabled = false;
            if(RequeredFieldsCheck())
            {
                if (_currentGCP != null)
                {
                    List<GarbageTypeSet> typeSet = new List<GarbageTypeSet>();
                    if ((bool)glassCHbx.IsChecked)
                        typeSet.Add(new GarbageTypeSet() { IdGarbageCollectionPoint = _currentGCP.Id, IdTypeOfGarbage = 1 });
                    if ((bool)plasticCHbx.IsChecked)
                        typeSet.Add(new GarbageTypeSet() { IdGarbageCollectionPoint = _currentGCP.Id, IdTypeOfGarbage = 2 });
                    if ((bool)paperCHbx.IsChecked)
                        typeSet.Add(new GarbageTypeSet() { IdGarbageCollectionPoint = _currentGCP.Id, IdTypeOfGarbage = 3 });
                    if ((bool)metalCHbx.IsChecked)
                        typeSet.Add(new GarbageTypeSet() { IdGarbageCollectionPoint = _currentGCP.Id, IdTypeOfGarbage = 4 });
                    if ((bool)pacCHbx.IsChecked)
                        typeSet.Add(new GarbageTypeSet() { IdGarbageCollectionPoint = _currentGCP.Id, IdTypeOfGarbage = 5 });
                    if ((bool)dangCHbx.IsChecked)
                        typeSet.Add(new GarbageTypeSet() { IdGarbageCollectionPoint = _currentGCP.Id, IdTypeOfGarbage = 6 });
                    GarbageCollectionPoint gcp = new GarbageCollectionPoint()
                    {
                        Building = TBBuilding.Text,
                        Street = TBStreet.Text,
                        Image = _mainImageData,
                        Description = TBxDescription.Text,
                        IdCompany = (CBCompany.SelectedItem as Company).Id,
                        Id = _currentGCP.Id,
                        GarbageTypeSets = typeSet
                    };
                    var response = await RequestHandler.PostRequestAsync<GarbageCollectionPoint>(gcp, "/api/GarbageCollectionPoint/update");
                    if(response)
                    {
                        MessageBox.Show("Данные успешно сохранены!", "Уведомление");
                    }
                }
                else
                {
                    List<GarbageTypeSet> typeSet = new List<GarbageTypeSet>();
                    if ((bool)glassCHbx.IsChecked)
                        typeSet.Add(new GarbageTypeSet() { IdGarbageCollectionPoint = 0, IdTypeOfGarbage = 1 });
                    if ((bool)plasticCHbx.IsChecked)
                        typeSet.Add(new GarbageTypeSet() { IdGarbageCollectionPoint = 0, IdTypeOfGarbage = 2 });
                    if ((bool)paperCHbx.IsChecked)
                        typeSet.Add(new GarbageTypeSet() { IdGarbageCollectionPoint = 0, IdTypeOfGarbage = 3 });
                    if ((bool)metalCHbx.IsChecked)
                        typeSet.Add(new GarbageTypeSet() { IdGarbageCollectionPoint = 0, IdTypeOfGarbage = 4 });
                    if ((bool)pacCHbx.IsChecked)
                        typeSet.Add(new GarbageTypeSet() { IdGarbageCollectionPoint = 0, IdTypeOfGarbage = 5 });
                    if ((bool)dangCHbx.IsChecked)
                        typeSet.Add(new GarbageTypeSet() { IdGarbageCollectionPoint = 0, IdTypeOfGarbage = 6 });
                    GarbageCollectionPoint gcp = new GarbageCollectionPoint()
                    {
                        Id = 0,
                        Building = TBBuilding.Text,
                        Street = TBStreet.Text,
                        Image = _mainImageData,
                        Description = TBxDescription.Text,
                        IdCompany = CBCompany.ItemsSource.OfType<Company>().FirstOrDefault(p => p.ClientId == App.CurrentUser.Id).Id,
                        GarbageTypeSets = typeSet
                    };
                    var response = await RequestHandler.PutRequestAsync(gcp, "/api/GarbageCollectionPoint/CreateGCP");
                    if (response)
                    {
                        MessageBox.Show("Данные успешно сохранены!", "Уведомление");
                    }
                }
            }
            this.IsEnabled = true;

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

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _types = (await RequestHandler.GetObjectFromRequestAsync<IEnumerable<TypeOfGarbage>>("GET", "/api/TypeOfGarbage/GetAll", "")).ToArray();

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
        }
    }
}
