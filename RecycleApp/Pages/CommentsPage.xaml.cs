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
    /// Логика взаимодействия для CommentsPage.xaml
    /// </summary>
    public partial class CommentsPage : Page
    {
        private readonly GarbageCollectionPoint _currentGCP;
        public CommentsPage(GarbageCollectionPoint currentGCP)
        {
            InitializeComponent();
            _currentGCP = currentGCP;
            TXBGCPCompany.Text += _currentGCP.IdCompanyNavigation.Name;
            TXBGCPAddress.Text += _currentGCP.Address;
            UpdateSource();

        }
        private async void UpdateSource()
        {
            string parametr = "/" + _currentGCP.Id.ToString();
            LWComments.ItemsSource = await RequestHandler.GetObjectFromRequestAsync<IEnumerable<Comment>>("GET", "/api/Comment/GetAllByGCPId", parametr);
        }

        private async void BtnWriteColumn_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            if(string.IsNullOrWhiteSpace(TXBxCommentBody.Text))
            {
                MessageBox.Show("Вы не ввели комментарий!","Ошибка");
                this.IsEnabled = true;
                return;
            }
            if(TXBxCommentBody.Text.Length > 255)
            {
                MessageBox.Show($"Максимальная длинна комментария 255 символов, вы ввели - {TXBxCommentBody.Text.Length}", "Ошибка"); 
                this.IsEnabled = true;
                return;
            }
            var com = new Comment()
            {
                Id = 0,
                IdClient = App.CurrentUser.Id,
                IdGarbageCollectionPoint = _currentGCP.Id,
                Text = TXBxCommentBody.Text
            };
            var response = await RequestHandler.PutRequestAsync(com, "/api/Comment/WriteComment");
            if(response)
            {
                TXBxCommentBody.Text = "";
                UpdateSource();
            }
            this.IsEnabled = true;
        }
    }
}
