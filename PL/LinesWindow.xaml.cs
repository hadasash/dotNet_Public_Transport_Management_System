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
    public partial class LinesWindow : Window
    {
        IBL bl;
        BO.Line curLine;
        public LinesWindow(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
            
            cbLineId.DisplayMemberPath = "NumberBus";//show only specific Property of object
            cbLineId.SelectedValuePath = "LineId";//selection return only specific Property of object
            cbLineId.SelectedIndex = 0; //index of the object to be selected
            RefreshAllLinesComboBox();
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
        public void RefreshAllLinesComboBox()
        {
            cbLineId.DataContext = bl.GetAllLines(); //ObserListOfStudents;
        }
        void RefreshAllRegisteredLineStationGrid()
        {
            //stationDataGrid.DataContext = curLine.LineStations;
        }
        private void cbLineId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            curLine = (cbLineId.SelectedItem as BO.Line);
            gridOneLine.DataContext = curLine;

            if (curLine != null)
            {
                //list of courses of selected student
               // RefreshAllLinesComboBox();
                //list of all courses (that selected student is not registered to it)
                // RefreshAllNotRegisteredCoursesGrid();
            }
        }

        private void bLContact_Click(object sender, RoutedEventArgs e)
        {
            Contact_us myWin = new Contact_us();
            myWin.Show();
            this.Close();
        }
    }
}
