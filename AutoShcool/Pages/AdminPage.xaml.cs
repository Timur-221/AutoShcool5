using System;
using System.Collections;
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
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        MonD Mon { get; set; }

        UserInfo UserInfo { get; set; }

        MongoClient Client { get; set; }  = new MongoClient("mongodb://localhost:27017");
        

        List<string> Names = new List<string>();
        public AdminPage()
        {
            InitializeComponent();
            IMongoDatabase database  = Client.GetDatabase("AutoSchool");
            DBList(database);
            Mon = new MonD();
            UserInfo = new UserInfo();
        }

        private void ExNav(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AuthPage());
        }

        private void AddStud(object sender, RoutedEventArgs e)
        {
            UserInfo.Login = usernameTextBox.Text;
            UserInfo.Password = passwordBox.Password;
            UserInfo.NumGroup = GroupText.Text;
            UserInfo.Category = CategoryText.Text;
            UserInfo.Name = NameText.Text;
            UserInfo.FName = FNameText.Text;
            UserInfo.Otchestvo = OtcText.Text;

            Mon.AddUser(UserInfo);
            string fullName = $"{FNameText.Text} {NameText.Text}";
            Names.Add(fullName);
            userListBox.ItemsSource = Names.ToList();
            MessageBox.Show("Добавлен Ученик!");

            usernameTextBox.Text = string.Empty;
            passwordBox.Password = string.Empty;
            GroupText.Text = string.Empty;
            CategoryText.Text = string.Empty;
            NameText.Text = string.Empty;
            FNameText.Text = string.Empty ;
            OtcText.Text = string.Empty ;

            

            

            // Привязка обновленных данных к ItemsSource свойству ListBox

        }


        

        public void DBList(IMongoDatabase database)
        {
            var collection = database.GetCollection<BsonDocument>("Student");

            var filter = Builders<BsonDocument>.Filter.Empty;
            var projection = Builders<BsonDocument>.Projection.Include("Name").Include("FName");

            var cursor = collection.Find(filter).Project(projection).ToCursor();

            List<string> names = new List<string>();
            foreach (var document in cursor.ToEnumerable())
            {
                string firstName = document.GetValue("Name", "").AsString;
                string lastName = document.GetValue("FName", "").AsString;

                string fullName = $"{firstName} {lastName}";
                names.Add(fullName);
            }

            Names = names;

            userListBox.ItemsSource = Names.ToList();
        }
    }
}
