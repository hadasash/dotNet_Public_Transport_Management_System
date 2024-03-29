﻿using System;
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
    /// Interaction logic for StationsWindow.xaml
    /// </summary>
    public partial class StationsWindow : Window
    {
        IBL bl;
        BO.Station curStation;

        public StationsWindow(IBL _bl)
        {

            InitializeComponent();
            bl = _bl;
            cbStationId.DisplayMemberPath = "Name";//show only specific Property of object
            cbStationId.SelectedValuePath = "Code";//selection return only specific Property of object
            cbStationId.SelectedIndex = 0; //index of the object to be selected
            RefreshAllStationComboBox();
            lineDataGrid.IsReadOnly = true;
        }

        public void RefreshAllStationComboBox()
        {
            cbStationId.DataContext = bl.GetAllStations(); //ObserListOfStudents;
        }
        void RefreshAllRegisteredLinesGrid()
        {
            lineDataGrid.DataContext = bl.GetAllLinesPerStation(curStation.Code);
        }
        private void cbStationId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            curStation = (cbStationId.SelectedItem as BO.Station);
            gridOneStation.DataContext = curStation;

            if (curStation != null)
            {
                //list of courses of selected student
                RefreshAllRegisteredLinesGrid();
                //list of all courses (that selected student is not registered to it)
                // RefreshAllNotRegisteredCoursesGrid();
            }
        }



        private void btUpdateStation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (curStation != null)
                    bl.UpdateStationPersonalDetails(curStation);
            }
            catch (BO.BadStationCodeException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void refresh(object sender, EventArgs e)
        {
            RefreshAllStationComboBox();
        }

        private void btAddStation_Click(object sender, RoutedEventArgs e)
        {

            AddNewStation newStatWin = new AddNewStation();
            newStatWin.Closed += refresh;
            newStatWin.Show();

        }

        private void btDeleteStation_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Delete selected station?", "Verification", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.No)
                return;

            try
            {
                if (curStation != null)
                {
                    bl.DeleteStation(curStation.Code);

                    RefreshAllRegisteredLinesGrid();
                    // RefreshAllNotRegisteredCoursesGrid();
                    RefreshAllStationComboBox();
                }
            }
            catch (BO.BadStationCodeLineIDException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (BO.BadStationCodeException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow myWin = new MainWindow(bl);
            myWin.Show();
            this.Close();
        }

        private void bLogOut_Click(object sender, RoutedEventArgs e)
        {
            User myWin = new User();
            myWin.Show();
            this.Close();
        }

        private void bLContactUs_Click(object sender, RoutedEventArgs e)
        {
            Contact_us myWin = new Contact_us();
            myWin.Show();
            this.Close();
        }

        private void btDeleteLine_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BO.Line scBO = ((sender as Button).DataContext as BO.Line);
                bl.DeleteStationInLine(scBO.LineId, curStation.Code);
                RefreshAllRegisteredLinesGrid();

            }
            catch (BO.BadStationCodeLineIDException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
