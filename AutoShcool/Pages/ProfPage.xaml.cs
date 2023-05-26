using AutoShcool.MyClass;
using MongoDB.Bson;
using MongoDB.Driver;
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
using AutoShcool.DB;
using AutoShcool.MyClass;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AutoShcool.Pages
{
    /// <summary>
    /// Interaction logic for ProfPage.xaml
    /// </summary>
    public partial class ProfPage : Page
    {
        public ProfPage()
        {
            InitializeComponent();
        }

        private void AccNav(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AccStud());
        }

        private void ExNAv(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AuthPage());
        }

        //private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        //{
        //    var connectionString = "mongodb://localhost:27017";
        //    var client = new MongoClient(connectionString);
        //    var database = client.GetDatabase("AutoSchool");
        //    var collection = database.GetCollection<BsonDocument>("Student");

        //    var filter = Builders<BsonDocument>.Filter.Eq("Name", "ваше имя");
        //    var document = collection.Find(filter).FirstOrDefault();

        //    var name = document["Name"].ToString();

        //    Nametext.Text = name;
        //}
    }
}
