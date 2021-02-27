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
    /// Interaction logic for LinesSchedule.xaml
    /// </summary>
    public partial class LinesSchedule : Window
    {
        IBL bl;
        BO.Line currLine;
        public LinesSchedule(IBL _bL)
        {
            InitializeComponent();
            bl = _bL;

            cbLine.DisplayMemberPath = "NumberBus";//show only specific Property of object
            cbLine.SelectedValuePath = "LineId";//selection return only specific Property of object
            cbLine.SelectedIndex = 0; //index of the object to be selected

            cbLine.DataContext = bl.GetAllLines();//ObserListOfLines;

            lineTripDataGrid.IsReadOnly = true;
        }

        private void cbLine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currLine = (cbLine.SelectedItem as BO.Line);

            RefreshLineGrid();//get the line's details- the first and last station

            if (currLine != null)
            {
                RefreshAllLineTripsOfLineGrid();
            }
        }
        void RefreshAllLineTripsOfLineGrid()//get all lineTrips list of a line
        {
            lineTripDataGrid.DataContext = bl.GetAllLineTripPerLine(currLine.LineId);
        }

        void RefreshLineGrid()//get the line's details- the first and last station
        {
            grid1.DataContext = currLine;

        }
        //void RefreshAllLineGrid()
        //{
        //    grid1.DataContext = currLine;
        //     bl.GetAllLines().Where(l=>bl.GetAllLinesPerStation())
        //}
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource lineViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("lineViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // lineViewSource.Source = [generic data source]
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow myWin = new MainWindow(bl);
            myWin.Show();
            this.Close();
        }
    }
}

