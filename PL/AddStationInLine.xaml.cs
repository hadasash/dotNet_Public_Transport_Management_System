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
    /// Interaction logic for AddStationInLine.xaml
    /// </summary>
    public partial class AddStationInLine : Window
    {
        public BO.Station curSLBO;
        IBL bl;

        public AddStationInLine(BO.Station sLBO, BO.Line curLine)
        {
            InitializeComponent();
            //curSLBO = sLBO;
            //bl.AddStationInLine(curSLBO.Code,curLine.LineId);
            //DataContext = curSLBO;
            //cbStations.DataContext = bl.GetAllStations();
        }


        private void badd_Click(object sender, RoutedEventArgs e)
        {
            LinesWindow newStatWin = new LinesWindow(bl);
            newStatWin.Show();
            this.Close();
        }
    }
}


    