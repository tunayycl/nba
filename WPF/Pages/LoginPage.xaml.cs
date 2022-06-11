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
using NbaLibrary;

namespace WPF.Pages
{
    /// <summary>
    /// Interaktionslogik für LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void lbCustomers_Loaded(object sender, RoutedEventArgs e)
        {
            lbCustomers.ItemsSource = await RestHelper.Method_WindowLoaded();
            lbCustomers.Items.Refresh();
            lbCustomers.SelectedIndex = 0;
        }
    }
}
