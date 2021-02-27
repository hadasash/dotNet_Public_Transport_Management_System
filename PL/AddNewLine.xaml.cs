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
using BO;

namespace PL
{
    /// <summary>
    /// Interaction logic for AddNewLine.xaml
    /// </summary>
    public partial class AddNewLine : Window
    {

        IBL bl;
        DO.Line s = new DO.Line();
        public AddNewLine( IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
            areaComboBox.ItemsSource = Enum.GetValues(typeof(BO.Areas));
            grid1.DataContext = s;
            //lastStationComboBox.DataContext = bl.GetAllStations();
            //firstStationComboBox.DataContext = bl.GetAllStations();
        }

        private void AddStation_Click(object sender, RoutedEventArgs e)
        {
            //MB

            //try
            //{

            bl.AddLine(s);
            this.Close();
            //}
            // catch ()//(BO.)

            //{
            //    //MB
            //}
        }
        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            LinesWindow myWin = new LinesWindow(bl);
            myWin.Show();
            this.Close();
        }
    }
}
