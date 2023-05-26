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

namespace AutoShcool.Pages
{
    /// <summary>
    /// Interaction logic for Ter1Page.xaml
    /// </summary>
    public partial class Ter1Page : Page
    {
        public Ter1Page()
        {
            InitializeComponent();
        }

        private void PDDNavBack2(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new PDDPage());
        }
    }
}
