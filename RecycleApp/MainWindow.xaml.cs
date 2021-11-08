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
using System.Net;
using System.IO;
using System.Text.Json;

namespace RecycleApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void getRequest_Click(object sender, RoutedEventArgs e)
        {
            WebRequest reqGet = WebRequest.Create(@"https://localhost:44312/api/Values");
            WebResponse resp = reqGet.GetResponse();

            Stream stream = resp.GetResponseStream();
            StreamReader sr = new System.IO.StreamReader(stream);
            string s = sr.ReadToEnd();
            response.Text = s;
            /*var rng = new Random();
            var a = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = "chill"
            })
            .ToArray();
            var serealize = JsonSerializer.Serialize(a);
            deserialize.Text = serealize;
            var deserialized = JsonSerializer.Deserialize<IEnumerable<WeatherForecast>>(s).ToList();
            foreach (var item in deserialized)
            {
                deserialize.Text += item.Date + "\n" + item.TemperatureC + "\n" + item.TemperatureF + "\n" + item.Summary + "\n----------------\n";
            }
            */
        }
    }
}
