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

        }

        void RefreshAllStationComboBox()
        {
            cbStationId.DataContext = bl.GetAllStations().ToList(); //ObserListOfStudents;
        }
        private void cbStationId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            curStation = (cbStationId.SelectedItem as BO.Station);
            gridOneStation.DataContext = curStation;
           // lineDataGrid.DataContext =    bl.GetLines(curStation.Code);

            if (curStation != null)
            {
                //list of courses of selected student
               // RefreshAllRegisteredCoursesGrid();
                //list of all courses (that selected student is not registered to it)
               // RefreshAllNotRegisteredCoursesGrid();
            }
        }

    }
}
