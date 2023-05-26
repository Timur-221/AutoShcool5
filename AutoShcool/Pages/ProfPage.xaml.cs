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
using System.Text.Json;
using System.Collections.ObjectModel;
using Microsoft.VisualBasic;
using System.Collections;

namespace AutoShcool.Pages
{
    /// <summary>
    /// Interaction logic for ProfPage.xaml
    /// </summary>
    public partial class ProfPage : Page
    {
        UserInfo UserInfo { get; set; }

        MongoClient Client { get; set; } = new MongoClient("mongodb://localhost:27017");
        public ProfPage(UserInfo userInfo)
        {
            InitializeComponent();
            IMongoDatabase database = Client.GetDatabase("AutoSchool");
            UserInfo = userInfo;
            Filtr(database,userInfo);
            t1.Text = UserInfo.Name;
            t2.Text = UserInfo.FName;
            t3.Text = UserInfo.Otchestvo;
            t4.Text = UserInfo.NumGroup;
            t5.Text = UserInfo.Category;
        }

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

        public async void Filtr(IMongoDatabase database,UserInfo userInfo)
        {
            var collection = database.GetCollection<BsonDocument>("Student");




            var filter = new BsonDocument { { "Login", userInfo.Login }, { "Password", userInfo.Password } };

            List<BsonDocument> users = await collection.Find(filter).ToListAsync();
            foreach (var user in users)
            {
                userInfo.Name = user["Name"].AsString;
                userInfo.FName= user["FName"].AsString;
                userInfo.Otchestvo = user["Otchestvo"].AsString;
                userInfo.NumGroup = user["NumGroup"].AsString;
                userInfo.Category = user["Category"].AsString;
      
            }   

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
