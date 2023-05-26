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
using MongoDB.Driver;

namespace AutoShcool.Pages
{
    /// <summary>
    /// Interaction logic for AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        Account Account { get; set; }
        MonD Mon { get; set; }

        UserInfo UserInfo { get; set; }

        public AuthPage()
        {
            InitializeComponent();
            Mon= new MonD();
            Account = new Account();
            UserInfo = new UserInfo();

        }
        public void LogNav(object sender, RoutedEventArgs e)
        {
            Account.AdLogin = txtUsername.Text;
            Account.AdPassword = txtPassword.Password;

            bool isAccountValid = Mon.CheckDataExists(Account.AdLogin, Account.AdPassword);
            if (isAccountValid)
            {
                NavigationService.Navigate(new AdminPage());
            }
            else
            {
                UserInfo.Login = txtUsername.Text;
                UserInfo.Password = txtPassword.Password;

                bool isStudentValid = Mon.CheckStudentExists(UserInfo.Login, UserInfo.Password);
                if (isStudentValid)
                {
                    NavigationService.Navigate(new AccStud(UserInfo));
                }
                else
                {
                    MessageBox.Show("Неверные учетные данные!");
                }
            }

            //NavigationService.Navigate(new AccStud());
        }
    }
}
