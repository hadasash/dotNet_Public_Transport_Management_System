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
using dotNet5781_02_1165_8980;

namespace dotNet5781_03A_1165_8980
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        static Random rand = new Random(DateTime.Now.Millisecond);
        static Random r = new Random();

        allBusLines busline = new allBusLines();

        private lineBus currentDisplayBusLine;
        public MainWindow()
        {
           initialization1();
            InitializeComponent();
            cbBusLines.ItemsSource = busline;
            cbBusLines.DisplayMemberPath = "NumberBus";
            cbBusLines.SelectedIndex = 0;
        }
        private void ShowBusLine (int index)
        {
            currentDisplayBusLine = busline[index];
            UpGrid.DataContext = currentDisplayBusLine;
            lbBusLineStations.DataContext = currentDisplayBusLine.stations;
        }
        public void initialization1()
        { 
            int myNumBus;
            for (int i=0 ; i<10 ; i++)
            {
                lineBus busToInitial = new lineBus();
                myNumBus = r.Next(10, 200);
                busToInitial.NumberBus = myNumBus;
                for (int j=0;j<4;j++)
                {
                    busLineStation busLineToInitial = new busLineStation();
                  
                    busToInitial.stations.Add(busLineToInitial);
                    if (j==0)
                    {
                        busToInitial.FirstStation = busLineToInitial;
                    }
                    if (j==3)
                    {
                        busToInitial.LastStation = busLineToInitial;
                    }

                }
                int a = r.Next(0, 4);
                busToInitial.Area = (Areas)a;
                busline.Buses.Add(busToInitial);

            }
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbBusLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowBusLine((cbBusLines.SelectedValue as lineBus).NumberBus);
        }
    }
}
