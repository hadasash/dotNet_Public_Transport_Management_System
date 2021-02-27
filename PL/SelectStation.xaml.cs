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
using System.Windows.Shapes;

using BLAPI;

namespace PL
{
    /// <summary>
    /// Interaction logic for SelectStation.xaml
    /// </summary>
    public partial class SelectStation : Window
    {
        BO.Station currStat;
        IBL bl;
        public SelectStation(IBL _bl)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            bl = _bl;
            CBChosenStat.DisplayMemberPath = "Name";//show only specific Property of object
            CBChosenStat.SelectedValuePath = "Code";//selection return only specific Property of object
            //CBChosenStat.SelectedIndex = 0; //index of the object to be selected

            CBChosenStat.DataContext = bl.GetAllStations();//ListOfStations;
        }

        private void CBChosenStat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currStat = (CBChosenStat.SelectedItem as BO.Station);
            StationSimulator win = new StationSimulator(currStat);//we sent the station
            win.ShowDialog();
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {

            MainWindow myWin = new MainWindow(bl);
            myWin.Show();
            this.Close();

        }
    }
}

