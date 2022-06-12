using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using NbaLibrary.Models;

namespace WPF.Pages
{
    /// <summary>
    /// Interaktionslogik für StartShopping.xaml
    /// </summary>
    public partial class StartShopping : Page
    {
        public StartShopping()
        {
            InitializeComponent();
        }

        private async void btn_AddJerseyToCart_Click(object sender, RoutedEventArgs e)
        {
            //Jersey newJ = new Jersey { JerseyID = 0, Gender = tbGender.Text, Size = tbSize.Text, Name = tbName.Text, Number = Convert.ToInt32(tbNumber.Text) };
            //IEnumerable<Jersey> newJJ = await RestHelper.Method_btnNewJersey_Click(newJ);
            //lbjersey.ItemsSource = newJJ;
            //lbjersey.Items.Refresh();
        }

        private async void cbCoast_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbCoast.SelectedIndex == 0)
            {
                IEnumerable<string> eastteams = await RestHelper.GetTeamNameFromEast();
                cbTeam.ItemsSource = eastteams;
            }
            else if ((cbCoast.SelectedIndex == 1))
            {
                IEnumerable<string> westteams = await RestHelper.GetTeamNameFromWest();
                cbTeam.ItemsSource = westteams;
            }
        }

    }
}
