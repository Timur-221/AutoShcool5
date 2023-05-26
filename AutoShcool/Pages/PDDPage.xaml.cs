using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace AutoShcool.Pages
{
    /// <summary>
    /// Interaction logic for PDDPage.xaml
    /// </summary>
    public partial class PDDPage : Page
    {
        public PDDPage()
        {
            InitializeComponent();
        }

        private void AccNav(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AccStud());
        }

        private void ProfNav(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ProfPage());
        }

        private void TerNav1(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Ter1Page());
        }

        private void TerNav2(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Ter2Page());
        }

        private void WebPDD(object sender, MouseButtonEventArgs e)
        {
            string pddUrl = "http://www.pdd24.com/";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = pddUrl,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                // Обработка ошибки
                MessageBox.Show($"Ошибка при открытии URL-адреса: {ex.Message}");
            }
        }
    }
}
